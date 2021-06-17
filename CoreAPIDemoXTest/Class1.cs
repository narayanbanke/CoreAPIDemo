using CoreAPIDemo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAPIDemoXTest
{
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {
        }

        public void Seed(LibraryContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            //modelBuilder.Entity<Author>().HasData(new Author
            //{

            //    AuthorId = Guid.NewGuid(),
            //    FirstName = "narayan",
            //    LastName = "banke",
            //    Genre = "IT"

            //}, new Author
            //{
            //    AuthorId = Guid.NewGuid(),
            //    FirstName = "Shoba",
            //    LastName = "Patil",
            //    Genre = "Fantasy"
            //});
            context.Authors.AddRange(
                new Author() { FirstName = "CSHARP", LastName = "csharp", Genre = "it" },
                new Author() { FirstName = "VISUAL STUDIO", LastName = "visualstudio", Genre = "it" },
                new Author() { FirstName = "ASP.NET CORE", LastName = "aspnetcore", Genre = "it" },
                new Author() { FirstName = "SQL SERVER", LastName = "sqlserver", Genre = "it" }
            );


            context.SaveChanges();
        }
    }
}
