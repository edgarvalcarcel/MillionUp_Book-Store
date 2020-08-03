using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Book
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Synopsis { get; set; }
        public string Npages { get; set; }
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<AuthorBook> AuthorBook { get; private set; }

    }
}
