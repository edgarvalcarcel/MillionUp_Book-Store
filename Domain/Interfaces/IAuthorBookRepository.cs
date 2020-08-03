using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IAuthorBookRepository
    {
        AuthorBook GetAuthorsByBook(int Id);
        AuthorBook Upsert(AuthorBook authorbook);
    }
}
