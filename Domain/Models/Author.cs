using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Author
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public virtual ICollection<AuthorBook> AuthorBook { get; private set; }
    }
}
