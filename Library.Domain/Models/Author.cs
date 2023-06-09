﻿namespace Library.Domain.Models
{
    public class Author : BusinessObject
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        public IList<Author2Book> AuthorBooks { get; set; }
    }
}
