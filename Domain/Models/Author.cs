using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public partial class Author
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public virtual ICollection<AuthorBook> AuthorBook { get; private set; }
        
    }

    public partial class Author
    {
        public string FullName
        {
            get
            {
                return this.Name + " " + this.SurName;
            }
        }
    }
}
