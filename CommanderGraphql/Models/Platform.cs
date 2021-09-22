using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace CommanderGraphql.Models
{
    [GraphQLDescription("Represents any software or services have a command inteface")]
    public class Platform
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [GraphQLDescription("Represents a purchased and valid lisence for platoform")]
        public string LisenceKey { get; set; }
        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}