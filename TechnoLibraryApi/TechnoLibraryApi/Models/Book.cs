using System;
using System.Collections.Generic;

namespace TechnoLibraryApi.Models
{
    public partial class Book
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string BookName { get; set; } = null!;
        public string PublisherName { get; set; } = null!;
        public string Isbn { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public int Pages { get; set; }
        public string Extension { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? PicturePath { get; set; }
        public int? AverageRate { get; set; }

        public virtual Author Author { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
    }
}
