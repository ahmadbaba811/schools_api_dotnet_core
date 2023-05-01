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

        //GET ALL BEHAVIOUR SETTINGS LIST
        [HttpGet("behaviour-settings-list")]
        public async Task<IActionResult> GetBehaviours()
        {
            var behaviour = await _context.TblBehaviours.OrderByDescending(x => x.DateAdded).ToListAsync();
            return Ok(behaviour);
        }

        //GET ALL BEHAVIOUR SETTINGS LIST
        [HttpGet("behaviour-settings-list/{session_id}/{term_id}")]
        public async Task<IActionResult> GetBehavioursBySessionAndTerm(string session_id, string term_id)
        {
            var behaviour = await _context.TblBehaviours.OrderByDescending(x => x.DateAdded)
                .Where(
                x => x.SessionId == session_id && x.TermId == term_id
                ).ToListAsync();
            return Ok(behaviour);
        }


        //ADD NEW BEHAVIOUR SETTING
        [HttpPost("add-behaviour-setting")]
        public async Task<IActionResult> AddBehaviorSetting(TblBehaviour beh)
        {
            var behaviorToAdd = await _context.TblBehaviours.Where(x => x.BehaviorName ==beh.BehaviorName && x.SessionId == beh.SessionId && x.TermId == beh.TermId).FirstOrDefaultAsync();
            if (behaviorToAdd != null) return BadRequest("behavior exists");

            await _context.TblBehaviours.AddAsync(beh);
            await _context.SaveChangesAsync();

            //return CreatedAtAction(nameof(GetById), new { id = beh.Id }, beh);
            return Ok("success");
        }

        //DELETE BEHAVIOR SETTING
        [HttpDelete("delete-behaviour-setting/{id}")]
        public async Task<IActionResult> DeleteBehaviorSetting(int id)
        {
            var behaviorToDelete = await _context.TblBehaviours.FindAsync(id);
            if (behaviorToDelete == null) return BadRequest("no record");

            _context.TblBehaviours.Remove(behaviorToDelete);
            await _context.SaveChangesAsync();
            return Ok("success");
        }



        //GET ALL STUDENT BEHAVIOUR LIST
        [HttpGet("behaviour-list")]
        public async Task<IActionResult> Get()
        {
            var behaviour = await _context.TblStudentBehaviors.OrderByDescending(x => x.DateAdded).ToListAsync();
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

        //GET ALL STUDENT BEHAVIOUR BY STUDENT ID/TERM ID/ CLASS ID/ SESSION ID
        [HttpPost("students-behaviour")]
        public async Task<IActionResult> GetBehaviorByClassTermSession(TblStudentBehavior beh)
        {
            var behaviour = await _context.TblStudentBehaviors.Where(x => 
            x.TermId == beh.TermId && 
            x.ClassId == beh.ClassId && 
            x.SessionId == beh.SessionId).ToListAsync();
            return Ok(behaviour);
        }



        //ADD NEW STUDENT BEHAVIOUR 
        [HttpPost("add-behaviour")]
        public async Task<IActionResult> CreateBehavior(TblStudentBehavior beh)
        {
            var _behToUpdate = await _context.TblStudentBehaviors.Where(x => 
            x.BehaviorId == beh.BehaviorId && 
            x.ClassId == beh.ClassId && 
            x.TermId == beh.TermId && 
            x.SessionId == beh.SessionId && 
            x.Regno == beh.Regno).FirstOrDefaultAsync();
            if (_behToUpdate != null)
            {
                _behToUpdate.Score = beh.Score;
                await _context.SaveChangesAsync();
                return Ok("success");
            }
            else
            {
                var _behavior = new TblStudentBehavior()
                {
                    Behaviour = beh.Behaviour,
                    BehaviorId = beh.BehaviorId,
                    ClassId = beh.ClassId,
                    SessionId = beh.SessionId,
                    TermId = beh.TermId,
                    Score = beh.Score,
                    Regno = beh.Regno,
                    AddedBy = beh.AddedBy,
                    DateAdded = beh.DateAdded
                };
                await _context.TblStudentBehaviors.AddAsync(_behavior);
                await _context.SaveChangesAsync();

                return Ok("success");
            }
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


        //GET ALL RESULT SUMMARY
        [HttpGet("result-details")]
        public async Task<IActionResult> GetResultSummary()
        {
            /*var result = await _context.VwStudentResults.Where(x =>
            x.Regno == res.Regno &&
            x.TermId == res.TermId &&
            x.ClassId == res.ClassId &&
            x.SessionId == res.SessionId).ToListAsync();
            if (result == null) return BadRequest();*/

            var result = _context.VwStudentResults.FromSqlRaw($"SELECT * FROM vw_student_results").ToListAsync();
            return Ok(result);
        }
    }
}
