﻿namespace Library.Application.Dtos.BookDto
{
    public class UpdateBookDto : BaseBookDto
    {
        public int Id { get; set; }
        public bool IsTaken { get; set; }
    }
}
