using System;

namespace Fisher.Bookstore.Api.Models
{
    public class Author
    {
        public int Id { get; set;}
        public string Name { get; set;}
        public string Bio {get; set; }
        public System.Collections.Generic.List<Book> Titles {get; set; }
        
    }
}