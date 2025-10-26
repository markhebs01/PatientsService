# PatientsService API

A simple .NET 8 Web API demonstrating the **Mediator pattern (CQRS)** using **MediatR** with an **in-memory data source**.

---

## Overview

This API exposes a single endpoint to retrieve a patient's details by ID.

- Built with **ASP.NET Core**
- Implements **Mediator pattern (CQRS)** using MediatR
- Uses an **in-memory repository** (no database)
- Includes **logging** and example **unit tests**
- Follows **Clean Architecture** principles

---

## Endpoint

**GET /api/patients/{id}**

Returns the patient details if found, or a 404 response if not.

Example request (curl):

```bash
curl -k https://localhost:5001/api/patients/1
```

Example JSON response (200):

```json
{
  "id": 1,
  "nhsNumber": "1234567890",
  "name": "Alice Johnson",
  "dateOfBirth": "1985-01-23T00:00:00",
  "gpPractice": "London Health Centre"
}
```

If the patient is not found, the API returns `404 Not Found` with a small message body, for example:

```json
{
  "message": "Patient with ID 999 not found."
}
```

---

## Running the Project

From the project root:

```bash
cd src/PatientsService.Api
dotnet run
```

- Swagger UI is available at:

```text
https://localhost:59745/
```

---

## Project Structure

```text
PatientsService.sln
README.md
src/
  PatientsService.Api/
  PatientsService.Application/
  PatientsService.Domain/
  PatientsService.Infrastructure/
tests/
  PatientsService.Tests/
```

---

## Notes

- The API uses **Clean Architecture** separation (API, Application, Domain, Infrastructure).
- **CQRS** is applied through `GetPatientByIdQuery` and its handler.
- The repository is **in-memory**, populated with a few example patients.
- No DTOs are used for simplicity in this exercise, but would be used in prodution.
- Logging is configured with the built-in .NET `ILogger`.


## Next Steps

If this project were to be developed further for production use, the following enhancements would be added:

- **DTOs (Data Transfer Objects)**  
  To separate API calls from internal domain models, improving maintainability and versioning flexibility.

- **Enhanced Logging (Serilog)**  
  Replace the built-in `ILogger` with **Serilog**, supporting structured logs, rolling files, and integration with monitoring tools like Seq or Application Insights.

- **Environment-Specific Configuration**  
  Use `appsettings.{Environment}.json` and environment variables for clean separation of development, staging, and production settings.

- **Validation Layer**  
  Add model validation with **FluentValidation** or built-in `DataAnnotations` to enforce input correctness.

- **API Versioning & Documentation**  
  Introduce versioned routes and expand Swagger documentation for better API lifecycle management.

- **Persistence Layer**  
  Replace the in-memory repository with a database (e.g., Entity Framework Core, PostgreSQL, MongoDB, CosmosDB) for persistent storage.

- **Integration & Unit Tests**  
  Expand test coverage to include API-level (integration) tests and richer domain logic validation.

  - **Integration & Unit Tests**  
  Expand test coverage to include API-level (integration) tests and richer domain logic validation.
	
- **Authentication & Authorization**  
  Implement secure access to the API endpoints.  
  Use **JWT Bearer tokens** or **OAuth 2.0** to authenticate clients.  
  Apply **role-based or policy-based authorization** to control which users can access certain endpoints. 