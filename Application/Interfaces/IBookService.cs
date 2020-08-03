using System;
using System.Collections.Generic;
using System.Text;
using Application.ViewModels;

namespace Application.Interfaces
{
    public interface IBookService
    {
        BookViewModel GetBooks();
        BookVM Upsert(BookVM book);
        BookVM GetBookById(int Id);
    }
}
