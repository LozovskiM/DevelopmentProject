using System;
using System.Collections.Generic;

#nullable disable

namespace DevelopmentProject.DB.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int NumOfPages { get; set; }
        public DateTime RealseDate { get; set; }
    }
}
