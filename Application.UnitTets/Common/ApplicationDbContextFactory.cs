using Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using IdentityServer4.EntityFramework.Options;
using Application.Common;
using Domain.Models;

namespace Application.UnitTets.Common
{
    public static class ApplicationDbContextFactory
    {
        public static BookStoreContext Create()
        {
            var options = new DbContextOptionsBuilder<BookStoreContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new BookStoreContext(options);

            context.Database.EnsureCreated();

            SeedSampleData(context);

            return context;
        }

        public static void SeedSampleData(BookStoreContext context)
        {
            context.Authors.AddRange(
                new Author { Name = "Gabriel", SurName="Garcia Marquez" },
                new Author { Name = "Philip", SurName = "Pullman" },
                new Author { Name = "Margaret", SurName = "Atwood" }
            );
            context.SaveChanges();
        }

        public static void Destroy(BookStoreContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
