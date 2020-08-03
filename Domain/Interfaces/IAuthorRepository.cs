using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GeAuthors();
        Author GeAuthorById(int Id);
        Author Upsert(Author author);
    }
}
