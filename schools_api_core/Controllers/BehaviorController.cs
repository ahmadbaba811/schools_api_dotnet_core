using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using schools_api_core.Data;
using schools_api_core.Models;

namespace schools_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BehaviorController : ControllerBase
    {
        private readonly schoolDbContext _context;
        public BehaviorController(schoolDbContext context) => _context = context;

        //GET ALL STUDENT BEHAVIOUR LIST
        [HttpGet("behaviour-list")]
        public async Task<IActionResult> Get()
        {
            var behaviour = await _context.TblStudentBehaviors.ToListAsync();
            return Ok(behaviour);
        }

        //GET ALL STUDENT BEHAVIOUR BY ROW ID
        [HttpGet("behaviour/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var behaviour = await _context.TblStudentBehaviors.FindAsync(id);
            if (behaviour == null) return BadRequest("no record");
            return Ok(behaviour);
        }

        //GET ALL STUDENT BEHAVIOUR BY STUDENT ID/TERM ID/ CLASS ID/ SESSION ID
        [HttpGet("behaviour/{regno}/{term_id}/{class_id}/{session_id}")]
        public async Task<IActionResult> GetByStudentId(string regno, string term_id, string class_id, string session_id)
        {
            var behaviour = await _context.TblStudentBehaviors.Where(x => x.Regno == regno && x.TermId == term_id && x.ClassId == class_id && x.SessionId == session_id).ToListAsync();
            if (behaviour == null) return BadRequest("no record");
            return Ok(behaviour);
        }


        //ADD NEW STUDENT BEHAVIOUR 
        [HttpPost("add-behaviour")]
        public async Task<IActionResult> CreateBehavior(TblStudentBehavior beh)
        {
            var behaviorToAdd = await _context.TblStudentBehaviors.Where(x => x.Behaviour == beh.Behaviour && x.ClassId ==  beh.ClassId && x.TermId == beh.TermId && x.SessionId == beh.SessionId).FirstOrDefaultAsync();
            if (behaviorToAdd != null) return BadRequest("behavior exists");

            await _context.TblStudentBehaviors.AddAsync(beh);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = beh.Id }, beh);
        }

        //DELETE STUDENT BEHAVIOUR 
        [HttpDelete("delete-behaviour/{id}")]
        public async Task<IActionResult> DeleteBehavior(int id)
        {
            var behaviourToDelete = await _context.TblStudentBehaviors.FindAsync(id);
            if (behaviourToDelete == null) return BadRequest("no record");

            _context.TblStudentBehaviors.Remove(behaviourToDelete);
            await _context.SaveChangesAsync();
            return Ok("deleted");
        }

        //UPDATE BEHAVIOUR BY ROW ID
        [HttpPut("update-behaviour/{id}")]
        public async Task<IActionResult> UpdateBeaviour(int id, TblStudentBehavior beh)
        {
            if (id != beh.Id) return BadRequest("no result");

            _context.Entry(beh).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("updated");
        }
    }
}
