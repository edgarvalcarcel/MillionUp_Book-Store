using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class AuthorService : IAuthorService
    {
        public IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository= authorRepository;
        }

        public AuthorViewModel GetAuthorById(int Id)
        {
            var AuthorView = _authorRepository.GeAuthorById(Id);
            return new AuthorViewModel()
            {
                Id = (int)AuthorView.Id,
                Name = AuthorView.Name,
                SurName = AuthorView.SurName
            };
        }

        public AuthorsViewModel GetAuthors()
        {
            return new AuthorsViewModel()
            {
                Authors = _authorRepository.GeAuthors()
            };
        }

        public AuthorViewModel Upsert(AuthorViewModel author)
        {
            Author publisherModel = new Author
            {
                Id = author.Id,Name = author.Name,SurName = author.SurName
            };
            var entityaut = _authorRepository.Upsert(publisherModel);
            return new AuthorViewModel()
            {
                Id = (int)entityaut.Id,Name = entityaut.Name,SurName = entityaut.SurName
            };
        }
    }
}
