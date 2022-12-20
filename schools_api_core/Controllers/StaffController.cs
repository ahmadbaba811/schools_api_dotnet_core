using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using schools_api_core.Data;
using schools_api_core.Models;
using System.Security.Cryptography.X509Certificates;


namespace schools_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly schoolDbContext  _context;
        public StaffController(schoolDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<TblSession>> Get()
        {
            return await _context.TblSessions.ToListAsync();
        }

       
    }
}
