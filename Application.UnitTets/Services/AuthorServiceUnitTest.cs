using Application.UnitTets.Common;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTets
{
    
   public class AuthorServiceUnitTest : CommandTestBase
    {
        [Fact]
        public void ShouldPersistAuthor()
        {
            //var command = new CreateTodoItemCommand
            //{
            //    Title = "Do yet another thing."
            //};

            //var handler = new CreateTodoItemCommand.CreateTodoItemCommandHandler(Context);

            //var result = await handler.Handle(command, CancellationToken.None);

            //var entity = Context.TodoItems.Find(result);

            //entity.ShouldNotBeNull();
            //entity.Title.ShouldBe(command.Title);

            AuthorViewModel author;
            //AuthorViewModel model = Upsert(author);
        }
    }
}
