using CoreServices.Controllers;
using CoreServices.Models;
using CoreServices.Repository;
using CoreServices.ViewModel;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace CoreServiesTest
{
  public  class PostUnitTestController
    {
        static private PostRepository repository;  
        public static DbContextOptions<BlogDBContext> dbContextOptions { get; }
        public static string connectionString = "Server=DESKTOP-I9BPSB6\\NPSQL;Database=BlogDB;UID=sa;PWD=Love@1234;";
        // server=DESKTOP-I9BPSB6\\NPSQL;database=BookStore;User=sa;password=Love@1234
        static PostUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<BlogDBContext>()
                .UseSqlServer(connectionString)
                .Options;

            var context = new BlogDBContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(context);
            repository = new PostRepository(context);
        }

        #region Get By Id  

        [Fact]
        public async void Task_GetPostById_Return_OkResult()
        {
            //Arrange  
            var controller = new PostController(repository);
            var postId = 2;

            //Act  
            var data = await controller.GetPost(postId);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetPostById_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new PostController(repository);
            var postId = 3;

            //Act  
            var data = await controller.GetPost(postId);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_GetPostById_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new PostController(repository);
            int? postId = null;

            //Act  
            var data = await controller.GetPost(postId);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_GetPostById_MatchResult()
        {
            //Arrange  
            var controller = new PostController(repository);
            int? postId = 1;

            //Act  
            var data = await controller.GetPost(postId);

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var post = okResult.Value.Should().BeAssignableTo<PostViewModel>().Subject;

            Assert.Equal("Test Title 1", post.Title);
            Assert.Equal("Test Description 1", post.Description);
        }

        #endregion
        #region Add New Blog  

        [Fact]
        public async void Task_Add_ValidData_Return_OkResult()
        {
            //Arrange  
            var controller = new PostController(repository);
            var post = new Post() { Title = "Test Title 3", Description = "Test Description 3", CategoryId = 2, CreatedDate = DateTime.Now };

            //Act  
            var data = await controller.AddPost(post);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_Add_InvalidData_Return_BadRequest()
        {
            //Arrange  
            var controller = new PostController(repository);
            Post post = new Post() { Title = "Test Title More Than 20 Characteres", Description = "Test Description 3", CategoryId = 3, CreatedDate = DateTime.Now };

            //Act              
            var data = await controller.AddPost(post);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_Add_ValidData_MatchResult()
        {
            //Arrange  
            var controller = new PostController(repository);
            var post = new Post() { Title = "Test Title 4", Description = "Test Description 4", CategoryId = 2, CreatedDate = DateTime.Now };

            //Act  
            var data = await controller.AddPost(post);

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            // var result = okResult.Value.Should().BeAssignableTo<PostViewModel>().Subject;  

            Assert.Equal(3, okResult.Value);
        }

        #endregion

    }


}
