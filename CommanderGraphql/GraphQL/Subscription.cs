using CommanderGraphql.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGraphql.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Platform OnPlatformAdded([EventMessage] Platform platform){
            return platform;
        }
    }
}