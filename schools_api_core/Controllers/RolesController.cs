using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using schools_api_core.Data;
using schools_api_core.Models;

namespace schools_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly schoolDbContext _context;
        public RolesController(schoolDbContext context) => _context = context;

        //GET ALL ROLE LIST
        [HttpGet("roles-list")]
        public async Task<IActionResult> Get()
        {
            var roles = await _context.TblRoles.OrderByDescending(x => x.AddedDate).ToListAsync();
            return Ok(roles);
        }

        //GET ALL ROLE BY ROW ID
        [HttpGet("role/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _context.TblRoles.FindAsync(id);
            if (role == null) return BadRequest("no record");
            return Ok(role);
        }

        //GET ALL ROLE BY NAME
        [HttpGet("role-by-name/{role_name}")]
        public async Task<IActionResult> GetDesignationByName(string role_name)
        {
            var _role = await _context.TblRoles.Where(x => x.RoleName == role_name).FirstOrDefaultAsync();
            if (_role == null) return BadRequest("no record");

            return Ok(_role);
        }

        //ADD NEW ROLE
        [HttpPost("add-role")]
        public async Task<IActionResult> CreateRole(TblRole _role)
        {
            var exisitingRole = _context.TblRoles.Where(x => x.RoleName == _role.RoleName).FirstOrDefault();
            if (exisitingRole != null) return BadRequest("subject exists");

            await _context.TblRoles.AddAsync(_role);
            await _context.SaveChangesAsync();

            return Ok("success");
        }

        //DELETE ROLE
        [HttpDelete("delete-role/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var roleToDelete = await _context.TblRoles.FindAsync(id);
            if (roleToDelete == null) return BadRequest("no record");

            _context.TblRoles.Remove(roleToDelete);
            await _context.SaveChangesAsync();
            return Ok("deleted");
        }

        //UPDATE ROLE
        [HttpPut("update-role/{id}")]
        public async Task<IActionResult> UpdateRole(int id, TblRole _role)
        {
            var tt = await _context.TblRoles.FindAsync(id);
            if (tt == null) return BadRequest("no record");

            if (tt != null)
            {
                tt.RoleName = _role.RoleName;
                tt.AddedBy = _role.AddedBy;
                tt.AddedDate = Convert.ToDateTime(DateTime.Now);
                await _context.SaveChangesAsync();
            }
            return Ok("success");
        }
    }
}
