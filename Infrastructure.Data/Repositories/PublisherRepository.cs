using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        public BookStoreContext _context;
        public PublisherRepository(BookStoreContext context)
        {
            _context = context;
        }
        public Publisher GetPublisherbyId(int Id)
        {
            return _context.Publishers.FirstOrDefault(a => a.Id == Id);
        }

        public IEnumerable<Publisher> GetPublishers()
        {
            return _context.Publishers;
        }

        public Publisher Upsert(Publisher publisher)
        { 
            if (publisher.Id.HasValue && publisher.Id>0)
            {
                return GetPublisherbyId(publisher.Id.Value);
            }
            else
            {
                _context.Publishers.Add(publisher);
                _context.SaveChanges();
                return publisher;
            } 
        }
    }
}
