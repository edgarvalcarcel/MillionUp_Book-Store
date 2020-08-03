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

        public void Delete(AuthorBook authorbook)
        {
            _context.AuthorBooks.Remove(authorbook);
            _context.SaveChanges();
        }

        public AuthorBook GetAuthorsByBook(int Id)
        {
            return _context.AuthorBooks.FirstOrDefault(a => a.BookId == Id);
        }
        public AuthorBook Upsert(AuthorBook authorbook)
        {
            if (authorbook.Id.HasValue && authorbook.Id > 0)
            {
                var authorbookModel = GetAuthorsByBook(authorbook.Id.Value);
                Delete(authorbookModel);
                _context.SaveChanges();
            }
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
