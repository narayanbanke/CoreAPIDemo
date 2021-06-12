using CoreAPIDemo.Controllers;
using CoreAPIDemo.Entities;
using CoreAPIDemo.Repository.Contract;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace TestProject4
{
    public class UnitTest1
    {
        public LibrariesController Controller { get; set; }
        private readonly Mock<ILibraryRepository<Author>> mocRepo;
        public UnitTest1()
        {
            mocRepo = new Mock<ILibraryRepository<Author>>();
            Controller = new LibrariesController(mocRepo.Object);
        }
        [Fact]
        public void GetAllAuthor_Return_Ok()
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
