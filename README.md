# World Cities API
A relational ASP.NET Core Web API for managing Countries and Cities, built with Entity Framework Core, SQL Server, and a focus on maintainability, normalization, and predictable REST behavior.

## Features
### Cities
- Create, read, update, and delete cities
- Automatically normalizes country names when creating cities
- Ensures each city belongs to a valid country
- If the country does not exist, it is created automatically

### Countries
- Full CRUD for countries
- Prevents deleting a country that still has cities
- Supports clean update logic with validation
- Prevents invalid updates and duplicate names

## Setup Instructions
- Clone the repository
- Update (if needed) appsettings.json with your SQL Server connection string
- Run migrations: `dotnet ef database update`
- Run the project: `dotnet run`

 ## Future Enhancements
- return Country + Cities combined if requested by user

