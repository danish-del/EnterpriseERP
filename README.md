**EnterpriseERP**
**Enterprise Resource Planning (ERP) system** built with ASP.NET Core and .NET 8, following Clean Architecture principles.

Technologies
C#
ASP.NET Core Web API
.NET 8
Entity Framework Core
SQL Server
ASP.NET Core Identity
JWT Authentication
Pagination
FluentValidation
AutoMapper
Serilog
Clean Architecture
Domain
Application
Infrastructure
Web API
Unit Testing
Features
Company management
Branch management
Department management
JWT-based authentication
User identity management
Generic repository pattern
Global exception handling
Request logging
DTO validation
Prerequisites
.NET 8 SDK
SQL Server
Git
Getting Started
Clone the repository:


git clone https://github.com/danish-del/EnterpriseERP.git
cd EnterpriseERP
Restore dependencies:


dotnet restore EnterpriseERP.slnx
Configure the SQL Server connection string in your local configuration.

Build the project:


dotnet build EnterpriseERP.slnx
Run tests:


dotnet test EnterpriseERP.slnx
API Documentation
Swagger is enabled in the Development environment, if configured correctly.

Author
Danish Kumar Mehra

GitHub: https://github.com/danish-del
