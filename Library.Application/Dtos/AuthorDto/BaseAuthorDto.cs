﻿namespace Library.Application.Dtos.AuthorDto
{
    public class BaseAuthorDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}
