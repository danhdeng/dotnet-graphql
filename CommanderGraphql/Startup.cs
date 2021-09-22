using CommanderGraphql.Data;
using CommanderGraphql.GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphQL.Server.Ui.Voyager;
using CommanderGraphql.GraphQL.Platforms;

namespace CommanderGraphql
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<AppDbContext>(opts => opts.UseSqlServer(
                _configuration.GetConnectionString("CommandConn")));
            services.AddGraphQLServer()
                    .AddQueryType<Query>()
                    .AddType<PlatformType>()
                    .AddType<CommanderGraphql.GraphQL.Commands.CommandType>()
                    .AddFiltering()
                    .AddSorting()
                    .AddMutationType<Mutation>()
                    .AddSubscriptionType<Subscription>()
                    .AddInMemorySubscriptions();
                    // .AddProjections();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseWebSockets();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new VoyagerOptions()
            {
                GraphQLEndPoint = "/graphql",
            }, "/graphql-voyager");

            // app.UseGraphQLVoyager(new GraphQLVoyagerOptions() //{
            //     GraphQLEndPoint="/graphql",
            //     Path ="/graphql/voyager"
            // });
        }
    }
}
