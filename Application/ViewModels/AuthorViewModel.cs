using Domain.Models;
using System;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public ICollection<AuthorBook> AuthorBook { get; set; }
    }
}
