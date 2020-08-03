using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class PublisherService : IPublisherService
    {
        public IPublisherRepository _publisherRepository;
        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public PublisherViewModel GetPublisherById(int Id)
        {
            var PublisherView = _publisherRepository.GetPublisherbyId(Id);
            return new PublisherViewModel()
            {
                Id = (int)PublisherView.Id,Name = PublisherView.Name
            };
        }

        public PublisherListViewModel GetPublishers()
        {
            return new PublisherListViewModel()
            {
                Publishers = _publisherRepository.GetPublishers()
            };
        }

        public PublisherViewModel Upsert(PublisherViewModel publisher)
        {
            Publisher publisherModel = new Publisher
            {
                Id = publisher.Id,Name = publisher.Name
            }; 
            var entitypub  = _publisherRepository.Upsert(publisherModel);
            return new PublisherViewModel()
            {
                Id = (int)entitypub.Id,Name = entitypub.Name
            };
        }
    }
}
