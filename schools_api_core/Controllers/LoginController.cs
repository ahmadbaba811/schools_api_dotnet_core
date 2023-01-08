using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using schools_api_core.Data;
using schools_api_core.Models;
using System.Text.Json.Serialization;

namespace schools_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly schoolDbContext _context;

        public LoginController(schoolDbContext context) => _context = context;

        //GET ALL LOGIN
        [HttpGet("list")]
        public async Task<IActionResult> Get()
        {
            var login = await _context.TblLogins.ToListAsync();
            return Ok(login);
        }

        //Login 
        [HttpPost("user-login")]
        public async Task<IActionResult> CreateBehavior(TblLogin login, string StaffId = "", string Password = "")
        {
            Random generator = new Random();
            var _random = generator.Next(0, 1000000000).ToString("D9");
            var _staff = await _context.TblStaffs.Where(x => x.Email == StaffId || x.StaffId == StaffId).FirstOrDefaultAsync();

            var _staff_ = await _context.TblStaffs.Where(x => x.Email == StaffId || x.StaffId == StaffId).ToListAsync();

            if (_staff == null) return NotFound("wrong email");

            if (_staff != null)
            {
                var _pwd = await _context.TblStaffs.Where(x => x.Email == _staff.Email).Select(u => u.Password).SingleOrDefaultAsync();
                if (_pwd != null)
                {
                    if(_pwd == Password)
                    {
                        var commandText = "INSERT INTO tbl_login (user_id, session_id, status, login_date, ip_address, location) VALUES ('"+login.UserId+ "', '"+_random+"', '1', '"+Convert.ToDateTime(DateTime.Now).ToString()+"', '"+login.IpAddress + "', '" + login.Location + "' ) ";
                        int x = _context.Database.ExecuteSqlRaw(commandText);

                        var res = new
                        {
                            Success = true,
                            staff = _staff
                        };

                        return Ok(_staff_);
                    }
                    else
                    {
                        var commandText = "INSERT INTO tbl_login (user_id, session_id, status, login_date, ip_address, location) VALUES ('" + login.UserId + "', '" + _random + "', '0', '" + Convert.ToDateTime(DateTime.Now).ToString() + "', '" + login.IpAddress + "', '" + login.Location + "' ) ";
                        int x = _context.Database.ExecuteSqlRaw(commandText);

                        return BadRequest("wrong credentials");
                    }
                }
            }
            return BadRequest("no staff");
        }
    }
}
