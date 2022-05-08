using System;
using System.Collections.Generic;

namespace TechnoLibraryApi.Models
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = null!;
        public string BookNumbers { get; set; } = null!;
        public string Bibliography { get; set; } = null!;
        public string? PicturePath { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
