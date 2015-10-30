using System;

namespace BlogLibrary.Models
{
    public class Entry
    {
        public int EntryId { get; set; }
        public int UserId { get; set; }
        public string EntryText { get; set; }
        public DateTime Date { get; set; }
    }
}