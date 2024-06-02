# FullStack Web Application

## Description

This is the front-end user interface for the FullStack application, built using Angular. It provides a user-friendly interface for managing employees.

## Features

- Add new employees with their details such as name, email, phone, age, salary, and department.
- View a list of all employees with their details.
- Update existing employee details.
- Delete employees from the system.

## Technologies Used

- Angular: Front-end framework for building the user interface.
- Tailwind CSS: A utility-first CSS framework used for styling the UI components.
- HttpClient: Angular's built-in module for making HTTP requests to the server.
- RxJS: Reactive Extensions for JavaScript used for handling asynchronous operations.
- FormsModule, ReactiveFormsModule: Angular modules for working with forms and form validation.
- ASP.NET Core: Backend framework for building the Web API.



## Getting Started

### Prerequisites

- Node.js and npm installed on your machine.
- Angular CLI installed globally (`npm install -g @angular/cli`).

### Installation

1. Clone the repository:

```bash
git clone <repository_url>
```

2. Navigate to the project directory:

```bash
cd FullStackUI
```

3. Install dependencies:

```bash
npm install
```

### Usage

1. Start the development server:

```bash
ng serve
```

2. Open your browser and visit `http://localhost:4200` to view the application.

### Configuration

- The base URL for API requests is set to `https://localhost:7048/api` in the `environment.ts` file. You may need to change this URL according to your backend server configuration.

### Deployment

- To build the production-ready version of the application, run:

```bash
ng build --prod
```

This will create a `dist` folder with the compiled assets.

## API Details

### Description

This project is integrated with a backend ASP.NET Web API for managing employee data.

### Technologies Used

- ASP.NET Core: Backend framework for building the Web API.
- Entity Framework Core: ORM (Object-Relational Mapping) framework for interacting with the database.
- Microsoft.AspNetCore.Mvc: Library for building HTTP services and APIs.

### API Endpoints

- **GET /api/employees**: Get all employees.
- **POST /api/employees**: Add a new employee.
- **GET /api/employees/{id}**: Get employee details by ID.
- **PUT /api/employees/{id}**: Update employee details by ID.
- **DELETE /api/employees/{id}**: Delete an employee by ID.

### Data Model

The API uses the following data model for employees:

```csharp
public class Employee
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int Age { get; set; }
    public decimal Salary { get; set; }
    public string Department { get; set; }
}
```

## Contributing

Contributions are welcome! Please fork the repository and create a pull request with your changes.

## License

This project is licensed under the [MIT License](LICENSE).
