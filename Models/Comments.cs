using System.ComponentModel.DataAnnotations;

namespace BloggersHub.Models
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BlogId { get; set; }
        public Blogs Blog { get; set; }
       
    }
}
