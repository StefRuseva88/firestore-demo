using Firestore_Demo.Models;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Text.Json;
using static Google.Cloud.Firestore.V1.StructuredQuery.Types;

namespace Firestore_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string projectId;
        private readonly FirestoreDb database;

        public HomeController(ILogger<HomeController> logger,
            IConfiguration configuration)
        {
            var filePath = Path.GetFullPath("./your_firebase_private_key_file_path.json");
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            _logger = logger;
            _configuration = configuration;
            projectId = _configuration.GetValue<string>("Firestore_API:project_id");
            database = FirestoreDb.Create(projectId);
        }

        public async Task<IActionResult> Index()
        {
            Query notesQuery = database.Collection("Notes");
            QuerySnapshot notesSnapshot = await notesQuery.GetSnapshotAsync();
            List<Note> notes = new List<Note>();

            foreach (DocumentSnapshot noteData in notesSnapshot.Documents)
            {
                if (noteData.Exists)
                {
                    Dictionary<string, object> currentNotes = noteData.ToDictionary();
                    string json = JsonSerializer.Serialize(currentNotes);
                    Note currentNote = JsonSerializer.Deserialize<Note>(json);
                    currentNote.NoteId = noteData.Id;
                    notes.Add(currentNote);
                }
            }
            return View(notes); 
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Note());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Note model)
        {
            CollectionReference notes = database.Collection("Notes");

            if(string.IsNullOrWhiteSpace(model.Title) &&
                string.IsNullOrWhiteSpace(model.Description))
            {
                return View(model);
            }
            await notes.AddAsync(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
