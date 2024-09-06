# Remote Databases Project with Firebase
[![JavaScript](https://img.shields.io/badge/Made%20with-JavaScript-F7DF1E.svg)](https://developer.mozilla.org/en-US/docs/Web/JavaScript)
[![C#](https://img.shields.io/badge/Made%20with-C%23-239120.svg)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![.NET](https://img.shields.io/badge/.NET-5C2D91.svg)](https://dotnet.microsoft.com/)
[![Firebase](https://img.shields.io/badge/Powered%20by-Firebase-FFCA28.svg)](https://firebase.google.com/)

### This is a test project for **Front-End Technologies** May 2024 Course @ SoftUni

---

## About
This repository showcases the integration of Firebase Firestore (Cloud Firestore) for a responsive login form, with demos using both JavaScript and C#. It demonstrates CRUD (Create, Read, Update, Delete) operations with a remote database using Firebase, providing a practical example of database management in front-end and back-end projects.

## Key Features

- **Responsive Login Form**: A form that adjusts smoothly across different screen sizes.
- **Firebase Firestore Integration**: Real-time database operations via Firebase, with both JavaScript and C# demos.
- **CRUD Operations**: Demonstrates creating, reading, updating, and deleting documents in a Firestore database.

## Prerequisites

To work with this project, ensure you have the following set up:

- You have a [Google account](https://accounts.google.com/).
- You have installed [Node.js](https://nodejs.org/) (for the JavaScript demo).
- You have installed [.NET Core SDK](https://dotnet.microsoft.com/download) (for the C# demo).
- You have set up a Firebase project in the [Firebase Console](https://console.firebase.google.com/).

## Installation

### Firebase Setup

1. **Create a Firebase Project:**
- Go to the [Firebase Console](https://console.firebase.google.com/).
- Click "Add project" and follow the setup instructions.
- Once the project is created, enable Firestore under the Database section.

2. **Configure Firebase Firestore Rules:**
Firestore security rules determine who can read or write to your database. Initially, Firebase locks these rules, preventing external access. To allow public access for testing purposes (you may restrict these later), follow these steps:
- Navigate to the Firestore tab in your Firebase project.
- Under the Rules section, modify the security rules to allow read and write access to all users:

```json
service cloud.firestore {
  match /databases/{database}/documents {
    match /{document=**} {
      allow read, write: if true;
    }
  }
}
```
- Note: This rule allows unrestricted access to the database. Make sure to update the rules in production environments for security purposes.
## Content:

- Firestore Demo project using JavaScript
- Firestore Demo project using C#
  
## Contributing
Contributions are welcome! If you have any improvements or bug fixes, feel free to open a pull request.

## License
This project is licensed under the [MIT License](LICENSE). See the [LICENSE](LICENSE) file for details.

## Contact
For any questions or suggestions, please open an issue in the repository.
