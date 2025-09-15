# CONTACT MANAGER
A layered .NET Core solution for managing contacts. This project follows a clean architecture approach with separation of concerns across different layers.

This project is developed to understand the modern way of programming using .Net Core as backend programming and React as frontend.

---

## Project Structure
ContactManager.sln
    /ContactApi     <-- Web API (presentation)
    /Domain         <-- Domain models, value objects, exceptions
    /Application    <-- DTOs, commands/queries, interfaces, handlers (business rules)
    /Persistence    <-- EF Core DbContext, Migrations, repository implementations, UoW

---

## Getting Started

### 1. Create Solution and Project Structure

# Create solution folder
mkdir ContactManager && cd ContactManager
dotnet new sln -n ContactManager

# Create Projects
dotnet new webapi -n ContactApi
dotnet new classlib -n Domain
dotnet new classlib -n Application
dotnet new classlib -n Persistence

# Add project to solution
dotnet sln add ContactApi
dotnet sln add Domain
dotnet sln add Application
dotnet sln add Persistence

