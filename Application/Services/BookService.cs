using Application.Interfaces;
using Application.ViewModels;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class BookService : IBookService
    {
        public IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public BookVM GetBookById(int Id)
        {
            var BookView = _bookRepository.GetBookById(Id);
            return new BookVM()
            { 
                Id = (int)BookView.Id,Title = BookView.Title,ISBN = BookView.ISBN,
                Synopsis = BookView.Synopsis,Npages = BookView.Npages,PublisherId = BookView.PublisherId
            };
        }

        public BookViewModel GetBooks()
        {
            return new BookViewModel()
            {
                Books = _bookRepository.GetBooks()
            };
        }

        public BookVM Upsert(BookVM book)
        {
            Book bookModel = new Book
            {
                Id = (int)book.Id,Title = book.Title,
                ISBN = book.ISBN,Synopsis = book.Synopsis,
                Npages = book.Npages,PublisherId = book.PublisherId
            };
            var entitybook = _bookRepository.Upsert(bookModel);
            return new BookVM()
            {
                Id = (int)entitybook.Id,Title = entitybook.Title,
                ISBN = entitybook.ISBN,Synopsis = entitybook.Synopsis,
                Npages = entitybook.Npages,PublisherId = entitybook.PublisherId
            };
        }
    }
}
