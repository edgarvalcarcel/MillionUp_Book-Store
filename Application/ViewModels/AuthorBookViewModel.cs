using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels
{
    public class AuthorBookViewModel
    {
        public int? Id { get; set; }
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public virtual AuthorViewModel Author { get; set; }
        public virtual BookViewModel Book { get; set; }
    }
}
