﻿namespace WebApiProject.Models
{
    public class Book : BusinessObject
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Rating { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsBought { get; set; }

        public IList<Author2Book> AuthorBooks { get; set; }
    }
}
