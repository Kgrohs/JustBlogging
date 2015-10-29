using System;

namespace BlogLibrary.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}