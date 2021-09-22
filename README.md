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

# generate the Migrations
dotnet ef migrations add {migrations name}

# To undo this action, use 'ef migrations remove'
dotnet ef migrations remove

# apply the migrations

dotnet ef database update

# add grpahql endpoint to Project

endpoints.MapGraphQL();

# setup the graphql voyager
  app.UseGraphQLVoyager(new GraphQL.Server.Ui.Voyager.VoyagerOptions()
            {
                GraphQLEndPoint = "/graphql",
            }, "/graphql-voyager");

# to access the graphql voyager

http://localhost:5000/graphql-voyager

# to solove the parallel request issue in graphql
in startup
services.AddPooledDbContextFactory<AppDbContext>(opts=>opts.UseSqlServer(
                _configuration.GetConnectionString("CommandConn")));

in Query
 [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context){
            return context.Platforms;
        }

# add filter to query in graphql

query{
  command (where: {platformId: {eq: 1}})
  {
    id,
    howTo
    commandLine,
    platform{
      name
    }
  }
}

# add sorting to query in graphql

query {
  platform (order: {name: DESC}){
    name
  }
}

# mutation to add platform to db in graphql
mutation{
  addPlatform(
    input: {
      name: "test"
    }
  ){ platform
  {
    id
    name
  }
  }
}