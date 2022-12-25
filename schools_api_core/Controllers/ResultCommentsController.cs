using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using schools_api_core.Data;
using schools_api_core.Models;

namespace schools_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultCommentsController : ControllerBase
    {
        private readonly schoolDbContext _context;
        public ResultCommentsController(schoolDbContext context) => _context = context;

        //GET ALL RESULT COMMENT LIST
        [HttpGet("result-comment-list")]
        public async Task<IActionResult> Get()
        {
            var comments = await _context.TblResultComments.ToListAsync();
            return Ok(comments);
        }

        //GET ALL RESULT COMMENT BY ROW ID
        [HttpGet("result-comment/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comments = await _context.TblResultComments.FindAsync(id);
            if (comments == null) return BadRequest("no record");
            return Ok(comments);
        }

        //GET ALL RESULT COMMENT BY STUDENT ID
        [HttpGet("result-comment-by-regno/{regno}")]
        public async Task<IActionResult> GetByStudentId(string regno)
        {
            var comments = await _context.TblResultComments.Where(x => x.Regno == regno ).ToListAsync();
            if (comments == null) return BadRequest("no record");
            return Ok(comments);
        }


        //ADD NEW RESULT COMMENT
        [HttpPost("add-result-comment")]
        public async Task<IActionResult> CreatePComment(TblResultComment comments)
        {
            await _context.TblResultComments.AddAsync(comments);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = comments.Id }, comments);
        }

        //DELETE RESULT COMMENT
        [HttpDelete("delete-result-comment/{id}")]
        public async Task<IActionResult> DeletePComment(int id)
        {
            var commentToDelete = await _context.TblResultComments.FindAsync(id);
            if (commentToDelete == null) return BadRequest("no record");

            var student_comment = _context.TblStudentBiodata.Where(x => x.ParentId == id.ToString()).FirstOrDefault();
            if (student_comment != null) return BadRequest("student exists");

            _context.TblResultComments.Remove(commentToDelete);
            await _context.SaveChangesAsync();
            return Ok("deleted");
        }
    }
}
