using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        public BookStoreContext _context;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.Include(a => a.AuthorBook).ThenInclude(x=>x.Author)
                                 .Include(p => p.Publisher);
        }
        
        public Book Upsert(Book book)
        {

            if (book.Id.HasValue && book.Id > 0)
            {
                return GetBookById(book.Id.Value);
            }
            else
            {
                Book entity = new Book
                {
                    Title = book.Title,ISBN = book.ISBN,
                    Synopsis = book.Synopsis, Npages = book.Npages,
                    PublisherId = book.PublisherId,Publisher = book.Publisher
                };
                _context.Books.Add(entity);
                _context.SaveChanges();
                return book;
            }
        }

        public Book GetBookById(int Id)
        {
            return _context.Books.FirstOrDefault(a => a.Id == Id);
        }
    }
}
