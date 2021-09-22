using System.Linq;
using CommanderGraphql.Data;
using CommanderGraphql.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGraphql.GraphQL.Platforms
{
    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Represents any software or services have a command inteface");
            descriptor.Field(p=>p.LisenceKey).Ignore();

            descriptor
            .Field(p=>p.Commands)
            .ResolveWith<Resolvers>(p=>p.GetCommands(default!, default!))
            .UseDbContext<AppDbContext>()
            .Description("This is the lsit of availabel commands for this platform");
        }

        private class Resolvers
        {
            public IQueryable<Command> GetCommands(Platform platform, [ScopedService] AppDbContext context)
            {
                return context.Commands.Where(p=>p.PlatformId==platform.Id);
            }
        }
    }
}