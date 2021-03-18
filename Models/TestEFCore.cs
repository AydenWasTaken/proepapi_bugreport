using System;

namespace API.Models
{
    /// <summary>
    /// This is a test class to experiment with EF Core
    /// </summary>
    public class TestEFCore
    {
        /// <summary>
        /// The id of this object
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of this object
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The email of this object
        /// </summary>
        public string Email { get; set; }
    }
}
