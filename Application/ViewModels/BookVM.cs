using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels
{
    public class BookVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Synopsis { get; set; }
        public string Npages { get; set; }
        public int PublisherId { get; set; }
        public int AuthorId { get; set; }
        public virtual PublisherViewModel Publisher { get; set; }
        public virtual AuthorViewModel Author { get; set; }
        public virtual AuthorBookViewModel AuthorBook { get; set; }
    }
}
