# CONTACT MANAGER
A layered .NET Core solution for managing contacts. This project follows a clean architecture approach with separation of concerns across different layers.

This project is developed to understand the modern way of programming using .Net Core as backend programming and React as frontend.

---

## :open_file_folder: Project Structure
### **ContactManager**<br/>
> **/ContactApi**      `Web API (presentation)`<br/>
> **/Domain**          `Domain models, value objects, exceptions`<br/>
> **/Application**     `DTOs, commands/queries, interfaces, handlers (business rules)`<br/>
> **/Persistence**     `EF Core DbContext, Migrations, repository implementations, UoW`<br/>

---

## :rocket: Getting Started

### 1. Create Solution and Project Structure
```bash
# Create solution folder
mkdir ContactManager && cd ContactManager
dotnet new sln -n ContactManager

# Create Projects
dotnet new webapi -n ContactApi
dotnet new classlib -n Domain
dotnet new classlib -n Application
dotnet new classlib -n Persistence
```

### 2. Add Projects to Solution
```bash
dotnet sln add ContactApi
dotnet sln add Domain
dotnet sln add Application
dotnet sln add Persistence
```

### 3. Add Project References (Dependencies)
```bash
dotnet add Application reference Domain
dotnet add Persistence reference Domain
dotnet add Persistence reference Application
dotnet add ContactApi reference Application
dotnet add ContactApi reference Domain
```

### 4. Add EF Core Packages (Persistence Layer)
```bash
dotnet add Persistence package Microsoft.EntityFrameworkCore
dotnet add Persistence package Microsoft.EntityFrameworkCore.SqlServer
dotnet add Persistence package Microsoft.EntityFrameworkCore.Design
```

## :hammer_and_wrench: Recommended VS Code Extensions
1. C# Dev Kit
2. NuGet Gallery
3. SQLite Viewer

## :globe_with_meridians: GIT Setup
### 1. Configure GIT User
```bash
git config --global user.name "DeadpoolDebugger"
git config --global user.email "<Add email here>"
```

### 2. Generate SSH Key and Add to GitHub
```bash
ssh-keygen -t rsa -C "<Add email here>"
```
* Copy the public key from the contents of the newly-created **id_rsa.pub** file.
* Go to GitHub -> Settings -> SSH and GPG Keys(left menu)
* Click New SSH Key
* Add Label(e.g. Office Laptop) and paste the public key

  
**Verify SSH connection:**
```bash
ssh -T git@github.com
```

### 3. Add Remote Repository
```bash
git remote add origin git@github.com:DeadpoolDebugger/ContactManager
```
