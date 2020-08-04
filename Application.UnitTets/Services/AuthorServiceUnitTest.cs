using Application.UnitTets.Common;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Application.Services;
using Application.Interfaces;
using Shouldly;
using Moq;
using Domain.Models;
using WebUI.Controllers;

namespace Application.UnitTets
{
    /*: CommandTestBase*/
    public class AuthorServiceUnitTest
    {
        private readonly IAuthorService _authorService;
        public AuthorServiceUnitTest(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [Fact]
        public void ShouldPersistAuthor()
        {
            AuthorViewModel author = new AuthorViewModel()
            {
                Name = "John",
                SurName = "Doe"
            };
            var entityaut = _authorService.Upsert(author);
            entityaut.ShouldNotBeNull();
        }
    }
}
