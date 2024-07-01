# Contact Management System

A console-based Contact Management System built with C#. This application allows users to manage contacts by adding, updating, deleting, and displaying contact information. It also supports searching for contacts by name and persists data using file handling to save and load contacts.

## Features

- **Add New Contacts**: Add new contacts with name, phone number, email, and address.
- **Update Existing Contacts**: Update details of existing contacts.
- **Delete Contacts**: Remove contacts from the system.
- **Display All Contacts**: Display a list of all contacts.
- **Search Contacts by Name**: Search for contacts using a name query.
- **Persistent Storage**: Save contacts to a file and load them on startup.

## Getting Started

Follow these instructions to set up and run the Contact Management System on your local machine.

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Visual Studio Code](https://code.visualstudio.com/)
- C# extension for Visual Studio Code

### Installation

1. **Clone the repository**:
   ```sh
   git clone https://github.com/Mustafaahmed00/Contact-Management-System.git
   cd contact-management-system

2. Open the project in VS Code:
   code .

3. Build the project:
   Open the terminal in VS Code (`Ctrl+``).

4. Run the following command to build the project:
   dotnet build
5. Run the project:
   dotnet run

## Usage
When you run the application, you will be presented with a menu to manage contacts:

### Add Contact:

Enter the name, phone number, email, and address to add a new contact.
### Update Contact:

Enter the contact ID to update, followed by the new details.
### Delete Contact:

Enter the contact ID to delete the contact.
### Display Contacts:

Displays a list of all contacts.
### Search Contact:

Enter the name to search for matching contacts.
### Exit:

Exit the application.
## Example

Contact Management System
1. Add Contact
2. Update Contact
3. Delete Contact
4. Display Contacts
5. Search Contact
6. Exit
Choose an option: 1

Enter Name: Ahmed 
Enter Phone Number: 123-456-7890
Enter Email: Ahmed@example.com
Enter Address: 123 Main St

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

### Fork the repository.
Create a new branch (git checkout -b feature/your-feature).
Commit your changes (git commit -am 'Add some feature').
Push to the branch (git push origin feature/your-feature).
Create a new pull request.

## License
This project is licensed under the MIT License.
