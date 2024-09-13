using System.ComponentModel.DataAnnotations;

namespace BloggersHub.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
