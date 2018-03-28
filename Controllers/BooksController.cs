using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fisher.Bookstore.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Api.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Books);
        }

        [HttpGet("{id}", Name="GetBook")]
        public IActionResult GetById(int id)
        {
            var book = db.Books.Find(id);

            if(book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Book book)
        {
            if(book == null)
            {
                return BadRequest();
            }

            this.db.Books.Add(book);
            this.db.SaveChanges();

            return CreatedAtRoute("GetBook", new { id = book.Id}, book);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = this.db.Books.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            this.db.Books.Remove(book);
            this.db.SaveChanges();

            return NoContent();
        }
    
       private readonly Data.BookstoreContext db;

       public BooksController(Data.BookstoreContext db)
       {
           this.db = db;

           if (this.db.Books.Count() == 0)
           {
               this.db.Books.Add(new Book {
                   Id = 1,
                   Title = "The Lean Startup"
               });

               this.db.Books.Add(new Book
               {
                   Id = 2,
                   Title = "Patterns of Enterprise Application Architecture"
               });

               this.db.SaveChanges();
           }
       }
    }
}
