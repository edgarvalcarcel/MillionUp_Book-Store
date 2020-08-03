using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Data;
using Infrastructure.Data.Context;

namespace Application.UnitTets.Common
{
    public class CommandTestBase : IDisposable
    {
        public CommandTestBase()
        {
            Context = ApplicationDbContextFactory.Create();
        }

        public BookStoreContext Context { get; }

        public void Dispose()
        {
            ApplicationDbContextFactory.Destroy(Context);
        }
    }
}
