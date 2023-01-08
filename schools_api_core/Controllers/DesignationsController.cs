using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using schools_api_core.Data;
using schools_api_core.Models;

namespace schools_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationsController : ControllerBase
    {
        private readonly schoolDbContext _context;
        public DesignationsController(schoolDbContext context) => _context = context;

        //GET ALL DESIGNATIONS LIST
        [HttpGet("designations-list")]
        public async Task<IEnumerable<TblDesignation>> Get()
        {
            return await _context.TblDesignations.OrderByDescending(x => x.AddedDate).ToListAsync();
        }

        //GET ALL DESIGNATIONS BY ROW ID
        [HttpGet("designations/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var designation = await _context.TblDesignations.FindAsync(id);
            if (designation == null) return BadRequest("no record");
            return Ok(designation);
        }

        //GET ALL DESIGNATIONS BY NAME
        [HttpGet("designation-by-code/{designation_code}")]
        public async Task<IActionResult> GetDesignationByName(string designation_code)
        {
            var designation = await _context.TblDesignations.Where(x => x.DesignationCode == designation_code).FirstOrDefaultAsync();
            if (designation == null) return BadRequest("no record");

            return Ok(designation);
        }

        //ADD NEW DESIGNATIONS
        [HttpPost("add-designation")]
        public async Task<IActionResult> CreateDesignation(TblDesignation _des)
        {
            var exisitingDesignation = _context.TblDesignations.Where(x => x.DesignationName == _des.DesignationName).FirstOrDefault();
            if (exisitingDesignation != null) return BadRequest("designation exists");

            await _context.TblDesignations.AddAsync(_des);
            await _context.SaveChangesAsync();

            return Ok("success");
        }

        //DELETE DESIGNATIONS
        [HttpDelete("delete-designation/{id}")]
        public async Task<IActionResult> DeleteDesignation(int id)
        {
            var designationToDelete = await _context.TblDesignations.FindAsync(id);
            if (designationToDelete == null) return BadRequest("no record");

            _context.TblDesignations.Remove(designationToDelete);
            await _context.SaveChangesAsync();
            return Ok("deleted");
        }

        //UPDATE DESIGNATIONS
        [HttpPut("update-designation/{id}")]
        public async Task<IActionResult> UpdateDesignation(int id, TblDesignation _des)
        {
            var tt = await _context.TblDesignations.FindAsync(id);
            if (tt == null) return BadRequest("no record");

            if (tt != null)
            {
                tt.DesignationCode = _des.DesignationCode;
                tt.DesignationName = _des.DesignationName;
                tt.AddedBy = _des.AddedBy;
                tt.AddedDate = Convert.ToDateTime(DateTime.Now);
                await _context.SaveChangesAsync();
            }
            return Ok("success");
        }
    }
}
