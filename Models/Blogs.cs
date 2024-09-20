﻿using System.ComponentModel.DataAnnotations;

namespace BloggersHub.Models
{
    public class Blogs
    {
        [Key]
        public  int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        //public int UserId { get; set; }
        //public User User { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}
