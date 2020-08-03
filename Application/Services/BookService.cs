using Application.Interfaces;
using Application.ViewModels;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class BookService : IBookService
    {
        public IBookRepository _bookRepository;
        public IAuthorBookRepository _authorbookRepository;
        public BookService(IBookRepository bookRepository, IAuthorBookRepository authorbookRepository)
        {
            _bookRepository = bookRepository;
            _authorbookRepository = authorbookRepository;
        }

        public BookVM GetBookById(int Id)
        {
            var BookView = _bookRepository.GetBookById(Id);

            PublisherViewModel PublisherVm = new PublisherViewModel
            {
                Id = BookView.Publisher.Id,
                Name = BookView.Publisher.Name
            };
            AuthorViewModel AuthorVm = new AuthorViewModel
            {
                Id = (int)BookView.AuthorBook.FirstOrDefault().Author.Id,
                Name = BookView.AuthorBook.FirstOrDefault().Author.Name,
                SurName= BookView.AuthorBook.FirstOrDefault().Author.SurName
            };
            AuthorBookViewModel AuthorBookVm = new AuthorBookViewModel
            {
                Id = (int)BookView.AuthorBook.FirstOrDefault().Author.Id,
                AuthorId = (int)BookView.AuthorBook.FirstOrDefault().Author.Id,
                BookId = (int)BookView.AuthorBook.FirstOrDefault().Book.Id
            };
            BookVM bookVm = new BookVM()
            {
                Id = (int)BookView.Id, Title = BookView.Title, ISBN = BookView.ISBN,
                Synopsis = BookView.Synopsis, Npages = BookView.Npages, PublisherId = BookView.PublisherId,
                Author = AuthorVm,
                AuthorBook = AuthorBookVm,
                Publisher = PublisherVm,
                AuthorId = (int)BookView.AuthorBook.FirstOrDefault().AuthorId
            };
            return bookVm;
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
           
            AuthorBook authorBookModel = new AuthorBook
            {
                Id = (int)book.Id,
                AuthorId = book.AuthorId,
                BookId = (int)entitybook.Id
            };
            var authorbook = _authorbookRepository.Upsert(authorBookModel);

            return new BookVM()
            {
                Id = (int)entitybook.Id,Title = entitybook.Title,
                ISBN = entitybook.ISBN,Synopsis = entitybook.Synopsis,
                Npages = entitybook.Npages,PublisherId = entitybook.PublisherId,
                AuthorId = (int)authorbook.AuthorId
            };
        }
    }
}
