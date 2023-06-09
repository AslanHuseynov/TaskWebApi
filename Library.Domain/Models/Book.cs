﻿namespace Library.Domain.Models
{
    public class Book : BusinessObject
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Rating { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsTaken { get; set; }
        public string Image { get; set; }
        public IList<Author2Book> AuthorBooks { get; set; }
    }
}
