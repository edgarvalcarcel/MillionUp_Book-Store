using System;
using System.Collections.Generic;
using System.Text;
using Application.ViewModels;

namespace Application.Interfaces
{
    public interface IAuthorService
    {
        AuthorsViewModel GetAuthors();
        AuthorViewModel GetAuthorById(int Id);
        AuthorViewModel Upsert(AuthorViewModel author);
    }
}
