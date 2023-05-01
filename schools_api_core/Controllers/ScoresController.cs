using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using schools_api_core.Data;
using schools_api_core.Models;

namespace schools_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly schoolDbContext _context;
        public ScoresController(schoolDbContext context) => _context = context;

        //GET ALL STUDENT SCORES LIST
        [HttpGet("scores-list")]
        public async Task<IActionResult> Get()
        {
            var scores = await _context.TblStudentScores.ToListAsync();
            return Ok(scores);
        }

        //GET ALL STUDENT SCORES BY ROW ID
        [HttpGet("scores/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var scores = await _context.TblStudentScores.FindAsync(id);
            if (scores == null) return BadRequest("no record");
            return Ok(scores);
        }

        //GET ALL STUDENT SCORES BY STUDENT ID/TERM ID/ CLASS ID/ SESSION ID
        [HttpGet("scores/{regno}/{term_id}/{class_id}/{session_id}")]
        public async Task<IActionResult> GetByStudentId(string regno, string term_id, string class_id, string session_id)
        {
            var scores = await _context.TblStudentScores.Where(x => x.Regno == regno && x.TermId == term_id && x.ClassId == class_id && x.SessionId == session_id).ToListAsync();
            if (scores == null) return BadRequest("no record");
            return Ok(scores);
        }


        //ADD NEW STUDENT SCORES 
        [HttpPost("add-scores")]
        public async Task<IActionResult> CreateScore(TblStudentScore score)
        {
            var scoreToAdd = await _context.TblStudentScores.Where(x => x.SubjectId == score.SubjectId && x.ClassId == score.ClassId && x.TermId == score.TermId && x.SessionId == score.SessionId).FirstOrDefaultAsync();
            if (scoreToAdd != null) return BadRequest("score exists");

            await _context.TblStudentScores.AddAsync(score);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = score.Id }, score);
        }

        //DELETE STUDENT SCORES 
        [HttpDelete("delete-scores/{id}")]
        public async Task<IActionResult> DeleteScore(int id)
        {
            var behaviourToDelete = await _context.TblStudentBehaviors.FindAsync(id);
            if (behaviourToDelete == null) return BadRequest("no record");

            _context.TblStudentBehaviors.Remove(behaviourToDelete);
            await _context.SaveChangesAsync();
            return Ok("deleted");
        }

        //UPDATE STUDENT SCORES BY ROW ID
        [HttpPut("update-score/{id}")]
        public async Task<IActionResult> UpdateScore(int id, TblStudentScore score)
        {
            if (id != score.Id) return BadRequest("no result");

            _context.Entry(score).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("updated");
        }


        //GET SCORE SETTINGS
        [HttpGet("scores-settings-list")]
        public async Task<IActionResult> GetScoreSettings()
        {
            var scores = await _context.TblScoreSettings.ToListAsync();
            return Ok(scores);
        }

        //GET SCORE SETTINGS BY TERM AND SESSION ID
        [HttpGet("scores-settings-list/{term_id}/{session_id}")]
        public async Task<IEnumerable<TblScoreSetting>> GetScoreSettingsByTermAndSession(string term_id, string session_id)
        {
            var scores = await _context.TblScoreSettings.Where(x => x.TermId.ToString() == term_id && x.SessionId.ToString() == session_id).ToListAsync();
            return scores;
        }

        //ADD SCORES  SETTING
        [HttpPost("add-scores-setting")]
        public async Task<IActionResult> CreateScoreSetting(TblScoreSetting score)
        {
            var scoreToAdd = await _context.TblScoreSettings.Where(x => x.TermId == score.TermId && x.SessionId == score.SessionId).FirstOrDefaultAsync();
            if (scoreToAdd != null) return BadRequest("score setting exists");

            await _context.TblScoreSettings.AddAsync(score);
            await _context.SaveChangesAsync();

            return Ok("success");
        }


        //UPDATE SCORE SETTING
        [HttpPut("update-score-settings/{id}")]
        public async Task<IActionResult> UpdateScoreSetting(int id, TblScoreSetting score)
        {
            var tt = await _context.TblScoreSettings.FindAsync(id);
            if (tt == null) return BadRequest("no record");

            if (tt != null)
            {
                tt.SessionId = score.SessionId;
                tt.TermId = score.TermId;
                tt.Ca1 = score.Ca1;
                tt.Ca2 = score.Ca2;
                tt.Test1 = score.Test1;
                tt.Test2 = score.Test2; 
                tt.Exam = score.Exam;
                await _context.SaveChangesAsync();
            }
            return Ok("success");
        }


    }
}
