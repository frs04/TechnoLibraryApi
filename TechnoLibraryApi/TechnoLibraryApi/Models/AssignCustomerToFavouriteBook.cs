using System;
using System.Collections.Generic;

namespace TechnoLibraryApi.Models
{
    public partial class AssignCustomerToFavouriteBook
    {
        public int BookId { get; set; }
        public int CustomerId { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
    }
}
