using System;
using Xunit;
using CoreAPIDemo.Controllers;
using CoreAPIDemo.Entities;
using CoreAPIDemo.Repository.Contract;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
 
using CoreAPIDemo.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

namespace CoreAPIDemoXTest
{
    public class LibrariesControllerTest
    {
      //  public LibrariesController Controller { get; set; }
     //   private readonly Mock<ILibraryRepository<Author>> mocRepo;
        static private ILibraryRepository<Author> repository;
        public static DbContextOptions<LibraryContext> dbContextOptions { get; }
        public static string connectionString = "Server=DESKTOP-I9BPSB6\\NPSQL;Database=BlogDB;UID=sa;PWD=Love@1234;";

        //public LibrariesControllerTest()
        //{
        //    mocRepo = new Mock<ILibraryRepository<Author>>();
        //    Controller = new LibrariesController(mocRepo.Object);
        //}
        
        static LibrariesControllerTest()
        {
            dbContextOptions = 
                new DbContextOptionsBuilder<LibraryContext>()
                .UseSqlServer(connectionString)
                .Options;
            
            var context = new LibraryContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(context);
            repository = new LibraryRepository(context);
        }
        [Fact]
        public void GetAllAuthor()
        {
            var controller = new LibrariesController(repository);
            //Arrange 
            var result = controller.GetAllAuthor();
            //ACT
            var okResult = result as OkObjectResult;
            //Assert
          //  Assert.IsType<OkObjectResult>(okResult);
            Assert.Equal("200", okResult.StatusCode.ToString());
        }
        [Fact]
        public void GetAuthor()
        {
            var controller = new LibrariesController(repository);
           Guid Author = new Guid("3c15e28a-1c5f-4624-231a-08d931991d87");
            var result = controller.GetAuthor(Author);
            //ACT
            var okResult = result as OkObjectResult;
            //Assert
            //Assert.IsType<OkObjectResult>(okResult);
            Assert.Equal("200", okResult.StatusCode.ToString());
        }

        [Fact]
        public void DeleteAuthor()
        {
            var controller = new LibrariesController(repository);
            //Arrange 
            var result = controller.GetAllAuthor();
            //ACT
            var okResult = result as OkObjectResult;
            IEnumerable<Author> authors = okResult.Value as IEnumerable<Author>;
        //    controller = new LibrariesController(repository);
            //Arrange 

 
            //Guid Author=List<CoreAPIDemo.Entities.Author>.Enumerator)authors.GetEnumerator()
            List<string> guid = new List<string>();
            foreach (var a in authors)
            {
                guid.Add ( a.AuthorId.ToString());           
            
            }
            Guid Authorid = new Guid(guid[1]);
            result = controller.DeleteAuthor(Authorid);
            //ACT
              okResult = result as OkObjectResult;            
            Assert.Equal("1", okResult.Value.ToString());
        }
         

        [Fact]
        public void AddAuthor()
        {
            var controller = new LibrariesController(repository);
            List<Book> b = new List<Book>();
            // Arrange  
            //var controller = newDepartmentController();
            Author sessions = new Author(); 
            sessions.AuthorId = Guid.NewGuid();
            sessions.LastName = "lst";
            sessions.FirstName = "fst";
            sessions.Genre = "dd";
            sessions.Books = b;

            // Act  
            var  actionResult = controller.AddAuthor(sessions);
         //   var createdResult = actionResult asCreatedAtRouteNegotiatedContentResult<Department>;
            // Assert  
            //Assert.IsNotNull(createdResult);
            //Assert.AreEqual("DefaultApi", createdResult.RouteName);
            //Assert.IsNotNull(createdResult.RouteValues["id"]);
        }

    }
}
