using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhonesController(MyAppDbContext context) : ControllerBase
    {
        private readonly MyAppDbContext _context = context;

        [HttpGet]
        public List<Phone> GetAll()
        {
            var allPhone = _context.Phones.ToList();

            return allPhone;
        }

        [HttpPost]
        public ActionResult<Phone> CreatePhone([FromBody]Phone model)
        {
            model.Created = DateTime.Now;
            _context.Phones.Add(model);
            _context.SaveChanges();

            return model;
        }

        [HttpPut("{id}")]
        public ActionResult<Phone> UpdatePhone([FromRoute]long id, [FromBody] Phone model)
        {
            var existPhone = _context.Phones.FirstOrDefault(p => p.Id == id);

            if(existPhone == null)
            {
                return NotFound();
            }

            existPhone.Updated = DateTime.Now;
            existPhone.Name = model.Name;
            existPhone.Price = model.Price;

            _context.Phones.Update(existPhone);
            _context.SaveChanges();

            return existPhone;
        }

        [HttpDelete("{id}")]
        public ActionResult<Phone> CreatePhone([FromRoute]long id)
        {
            var existPhone = _context.Phones.FirstOrDefault(p => p.Id == id);

            if(existPhone == null)
            {
                return NotFound();
            }

            _context.Phones.Remove(existPhone);
            _context.SaveChanges();

            return existPhone;
        }
    }
}