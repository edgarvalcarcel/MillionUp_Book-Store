using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public BookStoreContext _context;
        public AuthorRepository(BookStoreContext context)
        {
            _context = context;
        }
        public IEnumerable<Author> GeAuthors()
        {
            return _context.Authors;
        }

        public Author GeAuthorById(int Id)
        {
            return _context.Authors.FirstOrDefault(a => a.Id == Id);
        }

        public Author Upsert(Author author)
        {
            if (author.Id.HasValue && author.Id > 0)
            {
                return GeAuthorById(author.Id.Value);
            }
            else
            {
                Author entity = new Author
                {
                    Name = author.Name,SurName = author.SurName
                };
                _context.Authors.Add(entity);
                _context.SaveChanges();
                return entity;
            }
        }
    }
}
