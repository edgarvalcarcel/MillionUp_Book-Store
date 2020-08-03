using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Application.ViewModels
{
    public class PublisherListViewModel
    {
        public IEnumerable<Publisher> Publishers { get; set; }
    }
}
