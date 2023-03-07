using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using schools_api_core.Data;
using schools_api_core.Models;

namespace schools_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly schoolDbContext _context;
        public ParentsController(schoolDbContext context) => _context = context;

        //GET ALL PARENT LIST
        [HttpGet("parents-list")]
        public async Task<IActionResult> Get()
        {
            var parents = await _context.TblParents.ToListAsync();
            return Ok(parents);
        }

        //GET ALL PARENT BY ROW ID
        [HttpGet("parents/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var parents = await _context.TblParents.Where(x => x.Id == id).ToListAsync();
            if (parents == null) return BadRequest("no record");
            return Ok(parents);
        }

        //GET ALL WARDS BY PARENT ID
        [HttpGet("parent-wards/{id}")]
        public async Task<IActionResult> GetWardsByParentId(int id)
        {
            var parents = await _context.TblStudentBiodata.Where(x => x.ParentId == id.ToString()).ToListAsync();
            if (parents == null) return BadRequest("no record");
            return Ok(parents);
        }


        //ADD NEW PARENT
        [HttpPost("add-parents")]
        public async Task<IActionResult> CreateParent(TblParent parent)
        {
            var exisitingParent = _context.TblParents.Where(x => x.Email == parent.Email || x.PhoneNumber == parent.PhoneNumber).FirstOrDefault();
            if (exisitingParent != null) return BadRequest("exists");

            await _context.TblParents.AddAsync(parent);
            await _context.SaveChangesAsync();

            return Ok("success");
        }

        //DELETE PARENT
        [HttpDelete("delete-parent/{id}")]
        public async Task<IActionResult> DeleteParent(int id)
        {
            var parentToDelete = await _context.TblParents.FindAsync(id);
            if (parentToDelete == null) return BadRequest("no record");

            var student_parent = _context.TblStudentBiodata.Where(x => x.ParentId == id.ToString()).FirstOrDefault();
            if (student_parent != null) return BadRequest("student is registered to this guardian");

            _context.TblParents.Remove(parentToDelete);
            await _context.SaveChangesAsync();
            return Ok("success");
        }

        //UPDATE PARENT
        [HttpPut("update-parent/{id}")]
        public async Task<IActionResult> UpdateParent(int id, TblParent parent)
        {
            var tt = await _context.TblParents.FindAsync(id);
            if (tt == null) return BadRequest("no record");

            if (tt != null)
            {
                tt.FirstName = parent.FirstName;
                tt.MiddleName = parent.MiddleName;
                tt.LastName = parent.LastName;
                tt.Address = parent.Address;
                tt.Occupation = parent.Occupation;
                tt.Email = parent.Email;
                tt.PhoneNumber = parent.PhoneNumber;
                tt.AddedBy = parent.AddedBy;
                tt.AddedDate = parent.AddedDate;
                await _context.SaveChangesAsync();
            }
            return Ok("updated");
        }
    }
}
