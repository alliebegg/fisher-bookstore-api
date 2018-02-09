using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fisher.Bookstore.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Authors);
        }

        [HttpGet("{id}", Name="GetAuthor")]
        public IActionResult GetById(int id)
        {
            var author = db.Authors.Find(id);

            if(author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Author author)
        {
            if(author == null)
            {
                return BadRequest();
            }

            this.db.Authors.Add(author);
            this.db.SaveChanges();

            return CreatedAtRoute("GetAuthor", new { id = author.Id}, author);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var author = this.db.Authors.FirstOrDefault(x => x.Id == id);

            if (author == null)
            {
                return NotFound();
            }

            this.db.Authors.Remove(author);
            this.db.SaveChanges();

            return NoContent();
        }
    
       private readonly BookstoreContext db;

       public AuthorController(BookstoreContext db)
       {
           this.db = db;

           if (this.db.Authors.Count() == 0)
           {
               this.db.Authors.Add(new Author {
                   Id = 1,
                   Name = "Allie Begg"
               });

               this.db.Authors.Add(new Author
               {
                   Id = 2,
                   Name = "Nikki Youtzy"
               });

               this.db.SaveChanges();
           }
       }
    }
}
