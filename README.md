# Production Management System
</br>
![]("https://github.com/rbuwaENG/Production_Management/blob/main/Screenshots/login.JPG?raw=true")

A simple C# console application for managing production data and interacting with a SQL Server database.

## Overview

The Production Management System is a console-based application built in C# that allows users to manage and track production records. It facilitates the addition of new production entries, which include details such as Production ID, Production Name, Date, and Client ID. The application interacts with a SQL Server database to store and retrieve data efficiently.

## Features

- **Add Production Records:** Users can add new production records to the database, providing essential details like Production ID, Production Name, Date, and Client ID.

- **Display Client Data:** The application can retrieve and display client data from the SQL Server database, offering insights into the existing client base.

- **User-Friendly Interface:** The console-based interface ensures simplicity and ease of use, making it accessible to users with varying levels of technical expertise.

## Prerequisites

- .NET Core or .NET 5+
- SQL Server
- Visual Studio or any other C# IDE

## Getting Started

1. **Clone the Repository:**

    ```bash
    git clone https://github.com/your-username/production-management-system.git
    cd production-management-system
    ```

2. **Open the Project in Visual Studio:**

    Open the solution file (`ProductionManagementSystem.sln`) in Visual Studio.

3. **Database Configuration:**

    - Ensure you have a SQL Server database set up.
    - Update the connection string in the `App.config` file with your database connection details.

4. **Build and Run:**

    Build and run the project in Visual Studio.

## Usage

- Use the console application to add new production records.
- View client data and production records from the SQL Server database.

## Contributing

Feel free to contribute to the project. Follow these steps:

1. Fork the project.
2. Create a new branch (`git checkout -b feature/new-feature`).
3. Commit your changes (`git commit -m 'Add new feature'`).
4. Push to the branch (`git push origin feature/new-feature`).
5. Open a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- The project is inspired by the need for a simple production management tool with a database backend.
- Special thanks to [contributors](CONTRIBUTORS.md) who have participated in this project.
