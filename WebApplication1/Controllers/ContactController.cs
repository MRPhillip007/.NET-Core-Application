using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public string SaveContact([FromBody] Contact model)
        {
            var newContact = new Contact
            {
                ID = model.ID,
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
            };

            if (newContact == null)
            {
                throw new Exception();
            }

            _context.Add(newContact);
            _context.SaveChanges();

            return "OK";
        }
    }
}
