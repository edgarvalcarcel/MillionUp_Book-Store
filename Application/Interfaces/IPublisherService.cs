using System;
using System.Collections.Generic;
using System.Text;
using Application.ViewModels;

namespace Application.Interfaces
{
    public interface IPublisherService
    {
        PublisherListViewModel GetPublishers();
        PublisherViewModel GetPublisherById(int Id);
        PublisherViewModel Upsert(PublisherViewModel publisher);
    }
}