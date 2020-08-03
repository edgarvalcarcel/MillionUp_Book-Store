
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Domain.Interfaces
{
    public interface IPublisherRepository
    {
        IEnumerable<Publisher> GetPublishers();
        Publisher GetPublisherbyId(int Id);
        Publisher Upsert(Publisher publisher);
    }
}
