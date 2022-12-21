using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using schools_api_core.Data;
using schools_api_core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace schools_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly schoolDbContext _context;
        public ClassesController(schoolDbContext context) => _context = context;

        //GET ALL CLASSES LIST
        [HttpGet("class-list")]
        public async Task<IActionResult> Get()
        {
            var classes = await _context.TblClasses.ToListAsync();
            return Ok(classes);
        }

        //GET ALL CLASSES BY ROW ID
        [HttpGet("class/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var _class = await _context.TblClasses.FindAsync(id);
            if (_class == null) return BadRequest("no record");
            return Ok(_class);
        }

        //GET CLASS BY CLASS NAME
        [HttpGet("class-by-name/{class_name}")]
        public async Task<IActionResult> GetTermByName(string class_name)
        {
            var _class = await _context.TblClasses.Where(x => x.ClassName == class_name).FirstOrDefaultAsync();
            if (_class == null) return BadRequest("no record");
            return Ok(_class);
        }

        //ADD NEW CLASS
        [HttpPost("add-class")]
        public async Task<IActionResult> CreateClass(TblClass term)
        {
            var exisitingClass = _context.TblClasses.Where(x => x.ClassName == term.ClassName).FirstOrDefault();
            if (exisitingClass != null) return BadRequest("class exists");

            await _context.TblClasses.AddAsync(term);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = term.Id }, term);
        }

        //DELETE CLASS
        [HttpDelete("delete-class/{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var classToDelete = await _context.TblClasses.FindAsync(id);
            if (classToDelete == null) return BadRequest("no record");

            _context.TblClasses.Remove(classToDelete);
            await _context.SaveChangesAsync();
            return Ok("deleted");
        }

        //UPDATE CLASS
        [HttpPut("update-term/{id}")]
        public async Task<IActionResult> UpdateClass(int id, TblClass _class)
        {
            var tt = await _context.TblClasses.FindAsync(id);
            if (tt == null) return BadRequest("no record");

            if (tt != null)
            {
                tt.ClassName = _class.ClassName;
                tt.Category = _class.Category;
                tt.AddedBy = _class.AddedBy;
                tt.DateAdded = _class.DateAdded;
                await _context.SaveChangesAsync();
            }
            return Ok("updated");
        }


    }
}
