using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using schools_api_core.Data;
using schools_api_core.Models;

namespace schools_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddSubjectsController : Controller
    {
        private readonly schoolDbContext _context;
        public AddSubjectsController(schoolDbContext context) => _context = context;

        //GET ALL CLASSES LIST
        [HttpGet("subject-list")]
        public async Task<IActionResult> Get()
        {
            var subject = await _context.TblAddSubjects.ToListAsync();
            return Ok(subject);
        }

        //GET ALL CLASSES BY ROW ID
        [HttpGet("subject/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var _subject = await _context.TblAddSubjects.FindAsync(id);
            if (_subject == null) return BadRequest("no record");
            return Ok(_subject);
        }

        //GET CLASS BY CLASS NAME
        [HttpGet("subject-by-name/{subject}")]
        public async Task<IActionResult> GetsubjectByName(string subject)
        {
            var _subject = await _context.TblAddSubjects.Where(x => x.Subject == subject).FirstOrDefaultAsync();
            if (_subject == null) return BadRequest("no record");
            return Ok(_subject);
        }

        //ADD NEW CLASS
        [HttpPost("add-subject")]
        public async Task<IActionResult> CreateClass(TblAddSubjects subject)
        {
            var exisitingSubject = _context.TblAddSubjects.Where(x => x.Subject == subject.Subject).FirstOrDefault();
            if (exisitingSubject != null) return BadRequest("Addsubject exists");

            await _context.TblAddSubjects.AddAsync(subject);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = subject.id }, subject);
        }

        //DELETE CLASS
        [HttpDelete("delete-subject/{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var subjectToDelete = await _context.TblAddSubjects.FindAsync(id);
            if (subjectToDelete == null) return BadRequest("no record");

            _context.TblAddSubjects.Remove(subjectToDelete);
            await _context.SaveChangesAsync();
            return Ok("deleted");
        }

        //UPDATE CLASS
        [HttpPut("update-subject/{id}")]
        public async Task<IActionResult> UpdateClass(int id, TblAddSubjects _subject)
        {
            var tt = await _context.TblAddSubjects.FindAsync(id);
            if (tt == null) return BadRequest("no record");

            if (tt != null)
            {
                tt.Subject = _subject.Subject;
                tt.added_by = _subject.added_by;
                tt.date_added = _subject.date_added;
                await _context.SaveChangesAsync();
            }
            return Ok("updated");
        }

    }
}
