using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    /// <summary>
    /// This class represents a session with the database and can be used to query and save instances of your entities.
    /// </summary>
    public class TestContext : DbContext
    {
        /// <summary>
        /// The DbSet of <see cref="TestEFCore"/> objects. This is essentially a direct connection to the database.<br></br>
        /// This is set automagically. <b>Do not set!</b>
        /// </summary>
        public DbSet<TestEFCore> TestObjects { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="options"></param>
        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestEFCore>().ToTable("Test objects table");
        }
    }
}
