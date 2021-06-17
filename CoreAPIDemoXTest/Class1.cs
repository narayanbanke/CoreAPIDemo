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

            context.Authors.AddRange(
                new Author() { FirstName = "Narayan", LastName = "banke", Genre = "software" },
                new Author() { FirstName = "John", LastName = "Lee", Genre = "Hardware" },
                new Author() { FirstName = "Shobha", LastName = "Patil", Genre = "Software" },
                new Author() { FirstName = "Other", LastName = "sqlserver", Genre = "it" }
            );


            context.SaveChanges();
        }
    }
}
