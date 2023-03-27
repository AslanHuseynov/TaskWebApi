﻿using WebApiProject.Dtos.BookDto;

namespace WebApiProject.Repositories.LibraryRepository
{
    public interface ILibraryRepository
    {
        Task<Book> Borrow(int bookId);
        Task<Book> Return(int bookId);
    }
}
