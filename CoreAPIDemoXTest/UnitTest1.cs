using System;
using Xunit;
using CoreAPIDemo.Controllers;
using CoreAPIDemo.Entities;
using CoreAPIDemo.Repository.Contract;
using Moq;
using Microsoft.AspNetCore.Mvc;

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
        public void Test1()
        {
            //Arrange 
            var result = Controller.GetAllAuthor();
            //ACT
            var okResult = result as OkObjectResult;
            //Assert
            Assert.IsType<OkObjectResult>(okResult);

        }
       
    }
}
