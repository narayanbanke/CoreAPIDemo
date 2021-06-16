using System;
using Xunit;
using CoreAPIDemo.Controllers;
using CoreAPIDemo.Entities;
using CoreAPIDemo.Repository.Contract;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreAPIDemoXTest
{
    public class LibrariesControllerTest
    {
        public LibrariesController Controller { get; set; }
        private readonly Mock<ILibraryRepository<Author>> mocRepo;
        public LibrariesControllerTest()
        {
            mocRepo = new Mock<ILibraryRepository<Author>>();
            Controller = new LibrariesController(mocRepo.Object);
        }
        [Fact]
        public void GetAllAuthor()
        {
            //Arrange 
            var result = Controller.GetAllAuthor();
            //ACT
            var okResult = result as OkObjectResult;
            //Assert
          //  Assert.IsType<OkObjectResult>(okResult);
            Assert.Equal("200", okResult.StatusCode.ToString());
        }
        [Fact]
        public void GetAuthor()
        {
            //Arrange 
            Guid Author = new Guid("27E2D42D-1DD2-4CAF-675F-08D9301227D5");
            var result = Controller.GetAuthor(Author);
            //ACT
            var okResult = result as OkObjectResult;
            //Assert
            //Assert.IsType<OkObjectResult>(okResult);
            Assert.Equal("200", okResult.StatusCode.ToString());
        }

        [Fact]
        public void DeleteAuthor()
        {
            //Arrange 
            Guid Author = new Guid("27E2D42D-1DD2-4CAF-675F-08D9301227D5");
            var result = Controller.DeleteAuthor(Author);
            //ACT
            var okResult = result as OkObjectResult;            
            Assert.Equal("1", okResult.Value.ToString());
        }
        [Fact]
        public void AddAuthor()
        {
            List<Book> b = new List<Book>();

            Author Author = new Author();
            Author.AuthorId = new Guid("27E2D42D-1DD2-4CAF-675F-08D9301227D9");
            Author.LastName = "lst";
            Author.FirstName = "fst";
            Author.Genre = "dd";
            Author.Books = b;
             var result = Controller.AddAuthor(Author);
            //ACT
            var okResult = result as OkObjectResult;
            Assert.Equal("1", okResult.Value.ToString());
        }

    }
}
