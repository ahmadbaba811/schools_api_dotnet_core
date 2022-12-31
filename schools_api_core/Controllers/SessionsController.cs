using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using schools_api_core.Data;
using schools_api_core.Models;
using System;

namespace schools_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly schoolDbContext _context;
        public SessionsController(schoolDbContext context) => _context = context;

        //GET ALL SESSION LIST
        [HttpGet("session-list")]
        public async Task<IEnumerable<TblSession>> Get()
        {
            return await _context.TblSessions.OrderByDescending(x => x.EndDate).ToListAsync();
        }

        //GET ALL SESSION BY ROW ID
        [HttpGet("session/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var session = await _context.TblSessions.FindAsync(id);
            if (session == null) return BadRequest("no record");
            return Ok(session);
        }

        //GET ALL SESSION BY SESSION NAME
        [HttpPost("session-by-name")]
        public async Task<IActionResult> GetBySessionName(TblSession se)
        {
            var session = await _context.TblSessions.Where(x => x.SessionName == se.SessionName).FirstOrDefaultAsync();
            if (session == null) return BadRequest("no record");
            return Ok(session);
        }

        //GET ACTIVE SESSION
        [HttpGet("active-session")]
        public async Task<IActionResult> GetActiveSession()
        {
            var session = await _context.TblSessions.Where(x => x.Status == "1").FirstOrDefaultAsync();
            if (session == null) return BadRequest("no record");
            return Ok(session);
        }

        //ADD NEW SESSION
        [HttpPost("add-session")]
        public async Task<IActionResult> CreateSession(TblSession se)
        {
            var exisitingSeession = _context.TblSessions.Where(x => x.SessionName == se.SessionName).FirstOrDefault();
            if (exisitingSeession != null) return BadRequest("session name already exists");

            var activeSession = _context.TblSessions.Where(x => x.Status == "1").FirstOrDefault();
            if(activeSession != null)
            {
                if (activeSession?.Status == se.Status)
                {
                    return BadRequest("active session already exists");
                }
            }

            await _context.TblSessions.AddAsync(se);
            await _context.SaveChangesAsync();

            return Ok("success");
        }

        //DELETE SESSION
        [HttpDelete("delete-session/{id}")]
        public async Task<IActionResult> DeleteSesssion(int id, TblSession session)
        {
            var sessionToDelete = await _context.TblSessions.FindAsync(id);
            if (sessionToDelete == null) return BadRequest("no record");

            _context.TblSessions.Remove(sessionToDelete);
            await _context.SaveChangesAsync();
            return Ok("success");
        }

        //UPDATE SESSION
        [HttpPut("update-session/{id}")]
        public async Task<IActionResult> UpdateSession(int id, TblSession session)
        {
            if (session.Status == "1")
            {
                var activeSession = await _context.TblSessions.Where(x => x.Status == "1").ToListAsync();
                if (activeSession != null)
                {
                    var _update = "UPDATE tbl_session SET status = '0' where id != '"+id+"' ";
                    int x = _context.Database.ExecuteSqlRaw(_update);
                }
            }

            var ss = await _context.TblSessions.FindAsync(id);
            if (ss == null) return BadRequest("no record");

            if (ss != null)
            {
                ss.Id = session.Id;
                ss.SessionName = session.SessionName;
                ss.StartDate = session.StartDate;
                ss.EndDate = session.EndDate;
                ss.Status = session.Status;
                ss.AllowPromotion = session.AllowPromotion;
                ss.AddedBy = session.AddedBy;
                ss.AddedDate = session.AddedDate;
                await _context.SaveChangesAsync();
            }
            return Ok("success");
        }
    }
}
