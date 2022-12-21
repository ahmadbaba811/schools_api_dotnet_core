using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using schools_api_core.Data;
using schools_api_core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace schools_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermController : ControllerBase
    {
        private readonly schoolDbContext _context;
        public TermController(schoolDbContext context) => _context = context;

        //GET ALL TERM LIST
        [HttpGet("terms-list")]
        public async Task<IEnumerable<TblTerm>> Get()
        {
            return await _context.TblTerms.ToListAsync();
        }

        //GET ALL TERM BY ROW ID
        [HttpGet("terms/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var term = await _context.TblTerms.FindAsync(id);
            if (term == null) return BadRequest("no record");
            return Ok(term);
        }

        //GET TERM BY TERM NAME
        [HttpPost("term-by-name")]
        public async Task<IActionResult> GetTermByName(TblTerm se)
        {
            var term = await _context.TblTerms.Where(x => x.TermName == se.TermName).FirstOrDefaultAsync();
            if (term == null) return BadRequest("no record");
            return Ok(term);
        }

        //GET ACTIVE TERM
        [HttpGet("active-term")]
        public async Task<IActionResult> GetActiveTerm()
        {
            var term = await _context.TblTerms.Where(x => x.Status == "1").FirstOrDefaultAsync();
            if (term == null) return BadRequest("no record");
            return Ok(term);
        }


        //ADD NEW TERM
        [HttpPost("add-term")]
        public async Task<IActionResult> CreateTerm(TblTerm term)
        {
            var exisitingTerm = _context.TblTerms.Where(x => x.TermName == term.TermName).FirstOrDefault();
            if (exisitingTerm != null) return BadRequest("term exists");

            await _context.TblTerms.AddAsync(term);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = term.Id }, term);
        }

        //DELETE TERM
        [HttpDelete("delete-term/{id}")]
        public async Task<IActionResult> DeleteTerm(int id, TblTerm term)
        {
            var termToDelete = await _context.TblTerms.FindAsync(id);
            if (termToDelete == null) return BadRequest("no record");

            _context.TblTerms.Remove(termToDelete);
            await _context.SaveChangesAsync();
            return Ok("deleted");
        }

        //UPDATE TERM
        [HttpPut("update-term/{id}")]
        public async Task<IActionResult> UpdateTerm(int id, TblTerm term)
        {
            if (term.Status == "1")
            {
                var activeTerm = await _context.TblTerms.Where(x => x.Status == "1").FirstOrDefaultAsync();
                if (activeTerm != null) return BadRequest("active term exists");
            }

            var tt = await _context.TblTerms.FindAsync(id);
            if (tt == null) return BadRequest("no record");

            if (tt != null)
            {
                tt.TermName = term.TermName;
                tt.StartDate = term.StartDate;
                tt.EndDate = term.EndDate;
                tt.Status = term.Status;
                tt.AddedBy = term.AddedBy;
                tt.DateAdded = term.DateAdded;
                await _context.SaveChangesAsync();
            }
            return Ok("updated");
        }
    }
}
