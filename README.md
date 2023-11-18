# Roanna

## Introduction
Experimenting...



Repository Structure
Root Directory ('Roanna')

README.md: 
Project documentation, setup instructions, and general information.

.gitignore: Git ignore file to exclude unnecessary files from version control.
solution.sln: Solution file for the entire project.
Src (Source Code)

## Roanna.Web
ASP.NET Core Web Application (APIs, Controllers).
* Controllers
* Views
* wwwroot (Static files, JavaScript, CSS)
## Roanna.Core
Core business logic.
* Models
* Services
* Interfaces

## Roanna.Infrastructure
Data Access Layer, Entity Framework Core context, migrations.
* Data
* Repositories
* Migrations

## Roanna.Common
Common utilities and shared resources.
* Helpers
* Constants

## Tests (Unit and Integration Tests)

* Roanna.Web.Tests
* Roanna.Core.Tests
* Roanna.Infrastructure.Tests

Docs (Documentation)

Project specifications, API documentation, etc.
Scripts (Build scripts, database scripts)

build_scripts
db_scripts
Lib (External libraries not included via package managers)