using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Application.ViewModels
{
    public class AuthorsViewModel
    {
        public IEnumerable<Author> Authors { get; set; }
    }
}
