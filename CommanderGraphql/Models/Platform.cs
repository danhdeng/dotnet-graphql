using System.ComponentModel.DataAnnotations;

namespace CommanderGraphql.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set;}
        [Required]
        public string name { get; set; }
        public string LisenceKey { get; set; }
    }
}