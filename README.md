**EnterpriseERP**
A Modular Enterprise Resource Planning System built with ASP.NET Core and .NET 8

EnterpriseERP is an ERP application designed using Clean Architecture principles to support maintainable, scalable, and well-structured business operations.

**🚀 Technology Stack**
Backend: ASP.NET Core Web API
Framework: .NET 8
Language: C#
ORM: Entity Framework Core
Database: SQL Server
Authentication: ASP.NET Core Identity & JWT
Validation: FluentValidation
Object Mapping: AutoMapper
Logging: Serilog
Testing: .NET Testing Framework
Containerization: Docker
✨ Features
Company Management
Branch Management
Department Management
JWT-based Authentication
User Identity Management
Generic Repository Pattern
Pagination
Global Exception Handling
Structured Request Logging
DTO Validation
Separation of Concerns through Clean Architecture
🏗️ Architecture
The solution follows Clean Architecture principles, separating business logic from infrastructure and presentation concerns.
#EnterpriseERP

CI PipeLine Test Completed

Layer	Responsibility
Domain	Core business entities and domain logic
Application	Application services, DTOs, interfaces, mappings, and validation
Infrastructure	Database access, repositories, and identity implementation
Web API	HTTP endpoints, authentication, middleware, and dependency injection
📁 Project Structure

**EnterpriseERP/
├── EnterpriseERP.Domain/
├── EnterpriseERP.Insfrastructure/
├── EnterpriseERP.Infrastructure.Test/
├── EnterpriseERP.Webapis/
├── EnterpriseERP/
├── EnterpriseERP.slnx**

⚙️ Prerequisites
Make sure the following tools are installed:

.NET 8 SDK
SQL Server
Git
Visual Studio 2026 or Visual Studio Code
Docker (optional)
🛠️ Getting Started
1. Clone the Repository

git clone https://github.com/danish-del/EnterpriseERP.git
cd EnterpriseERP
2. Configure the Database
Configure the SQL Server connection string using your local configuration or .NET User Secrets.

Do not commit database passwords, JWT signing keys, or other sensitive credentials to source control.

3. Restore Dependencies

dotnet restore EnterpriseERP.slnx
4. Build the Solution

dotnet build EnterpriseERP.slnx
5. Run Tests

dotnet test EnterpriseERP.slnx
6. Run the Web API

dotnet run --project EnterpriseERP.Webapis/EnterpriseERP.Webapi.csproj
Swagger documentation is available in the Development environment when enabled and correctly configured. Check the application launch settings for the local URL.

🧪 Testing
The solution includes .NET test projects. Run the test suite with:


dotnet test EnterpriseERP.slnx

🔒 Security
JWT-based authentication
ASP.NET Core Identity integration
Configuration-based secrets management
Centralized exception handling
🗺️ Roadmap
Expand ERP business modules
Improve automated test coverage
Enhance API documentation
Add CI/CD automation
👨‍💻 Author
Danish Kumar Mehra

GitHub: @danish-del

📄 License
No license has been specified yet. A license can be added when the project's distribution and reuse terms are decided.
