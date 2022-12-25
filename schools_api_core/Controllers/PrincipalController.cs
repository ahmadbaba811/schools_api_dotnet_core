using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using schools_api_core.Data;
using schools_api_core.Models;

namespace schools_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrincipalController : ControllerBase
    {
        private readonly schoolDbContext _context;
        public PrincipalController(schoolDbContext context) => _context = context;

        //GET ALL PRINCIPAL COMMENT LIST
        [HttpGet("principal-comment-list")]
        public async Task<IActionResult> Get()
        {
            var comments = await _context.TblPrincipalComments.ToListAsync();
            return Ok(comments);
        }

        //GET ALL PRINCIPAL COMMENT BY ROW ID
        [HttpGet("principal-comment/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comments = await _context.TblPrincipalComments.FindAsync(id);
            if (comments == null) return BadRequest("no record");
            return Ok(comments);
        }


        //ADD NEW PRINCIPAL COMMENT
        [HttpPost("add-principal-comment")]
        public async Task<IActionResult> CreatePComment(TblPrincipalComment comments)
        {
            await _context.TblPrincipalComments.AddAsync(comments);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = comments.Id }, comments);
        }

        //DELETE PRINCIPAL COMMENT
        [HttpDelete("delete-principal-comment/{id}")]
        public async Task<IActionResult> DeletePComment(int id)
        {
            var commentToDelete = await _context.TblPrincipalComments.FindAsync(id);
            if (commentToDelete == null) return BadRequest("no record");

            var student_comment = _context.TblStudentBiodata.Where(x => x.ParentId == id.ToString()).FirstOrDefault();
            if (student_comment != null) return BadRequest("student exists");

            _context.TblPrincipalComments.Remove(commentToDelete);
            await _context.SaveChangesAsync();
            return Ok("deleted");
        }
    }
}
