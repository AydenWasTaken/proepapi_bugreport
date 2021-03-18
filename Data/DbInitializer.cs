using API.Models;
using System.Collections.Generic;
using System.Linq;

namespace API.Data
{
    /// <summary>
    /// This class provides functionality for initializing the database with seeded values.
    /// </summary>
    public class DbInitializer
    {
        /// <summary>
        /// This method seeds the database with test objects if the table is empty.
        /// </summary>
        /// <param name="context">The context</param>
        public static void InitializeTestObjects(TestContext context)
        {
            context.Database.EnsureCreated();

            if (context.TestObjects.Any())
                return;

            context.TestObjects.AddRange(new List<TestEFCore>
            {
                new TestEFCore { Name = "name0", Email = "email0" },
                new TestEFCore { Name = "name1", Email = "email1" },
                new TestEFCore { Name = "name2", Email = "email2" },
                new TestEFCore { Name = "name3", Email = "email3" },
                new TestEFCore { Name = "name4", Email = "email4" },
                new TestEFCore { Name = "name5", Email = "email5" },
                new TestEFCore { Name = "name6", Email = "email6" },
                new TestEFCore { Name = "name7", Email = "email7" },
                new TestEFCore { Name = "name8", Email = "email8" },
                new TestEFCore { Name = "name9", Email = "email9" },
            });

            context.SaveChanges();
        }
    }
}
