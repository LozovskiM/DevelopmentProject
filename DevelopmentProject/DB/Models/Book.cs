using System;
using System.Collections.Generic;
using DevelopmentProject.Interfaces;

#nullable disable

namespace DevelopmentProject.DB.Models
{
    public class Book : IModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int NumOfPages { get; set; }
        public DateTime RealseDate { get; set; }
    }
}
