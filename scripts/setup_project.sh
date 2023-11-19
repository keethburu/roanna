#!/bin/bash

# Define your root project directory
ROOT_DIR="roanna"

# Create the main project folder
mkdir $ROOT_DIR
cd $ROOT_DIR

# Create the solution file
dotnet new sln -n $ROOT_DIR

# Create src and tests directories
mkdir src
mkdir tests

# Inside src, create individual projects
cd src
dotnet new webapi -controllers -n Roanna.Web
dotnet new classlib -n Roanna.Core
dotnet new classlib -n Roanna.Infrastructure
dotnet new classlib -n Roanna.Common

# Navigate back to the root directory
cd ..

# Add projects to the solution
dotnet sln $ROOT_DIR.sln add src/Roanna.Web/Roanna.Web.csproj
dotnet sln $ROOT_DIR.sln add src/Roanna.Core/Roanna.Core.csproj
dotnet sln $ROOT_DIR.sln add src/Roanna.Infrastructure/Roanna.Infrastructure.csproj
dotnet sln $ROOT_DIR.sln add src/Roanna.Common/Roanna.Common.csproj

# Create Test projects for each source project
cd tests
dotnet new xunit -n Roanna.Web.tests
dotnet new xunit -n Roanna.Core.tests
dotnet new xunit -n Roanna.Infrastructure.tests

# Add test projects to the solution
cd ..
dotnet sln $ROOT_DIR.sln add tests/Roanna.Web.tests/Roanna.Web.tests.csproj
dotnet sln $ROOT_DIR.sln add tests/Roanna.Core.tests/Roanna.Core.tests.csproj
dotnet sln $ROOT_DIR.sln add tests/Roanna.Infrastructure.tests/Roanna.Infrastructure.tests.csproj

# Create additional directories
mkdir docs
mkdir scripts
mkdir lib

# Optional: Create a .gitignore file
echo "/bin" >> .gitignore
echo "/obj" >> .gitignore

# Initialize Git repository
git init

# End of the script
echo "Project structure for $ROOT_DIR has been created successfully."
