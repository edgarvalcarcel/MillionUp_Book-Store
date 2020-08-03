using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.Repositories
{
    public class AuthorBookRepository : IAuthorBookRepository
    {
        public BookStoreContext _context;
        public AuthorBookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public AuthorBook GetAuthorsByBook(int Id)
        {
            throw new NotImplementedException();
        }
        public AuthorBook Upsert(AuthorBook authorbook)
        {
            if (authorbook.Id.HasValue && authorbook.Id > 0)
            {
                return GetAuthorsByBook(authorbook.Id.Value);
            }
            else
            {
                AuthorBook entity = new AuthorBook
                {
                    AuthorId = authorbook.AuthorId,
                    BookId = authorbook.BookId
                };
                _context.AuthorBooks.Add(entity);
                _context.SaveChanges();
                return entity;
            }
        }
    }
}
