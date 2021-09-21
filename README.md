# dotnet-graphql

# create a github ignore file for dotnet

dotnet new gitignore

# add entityframework
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
# add hot chocolate package

dotnet add package HotChocolate.AspNetCore
dotnet add package HotChocolate.Data.EntityFramework

# add graphql package

dotnet add package GraphQL.Server.Ui.Voyager --version 5.0.2

# launch and stop sql server from docker in background mode

docker-compose up -d 
docker-compose stop

# install dotnet ef cli

dotnet tool install --global dotnet-ef
dotnet ef 
Commands:
  database    Commands to manage the database.
  dbcontext   Commands to manage DbContext types.
  migrations  Commands to manage migrations.
