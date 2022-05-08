using System;
using System.Collections.Generic;

namespace TechnoLibraryApi.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? Birthday { get; set; }
    }
}
