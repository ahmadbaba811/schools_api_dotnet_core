using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using schools_api_core.Data;
using schools_api_core.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace schools_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly schoolDbContext _context;
        public SubjectController(schoolDbContext context) => _context = context;

        //GET ALL SUBJECT LIST
        [HttpGet("subject-list")]
        public async Task<IEnumerable<TblSubject>> Get()
        {
            return await _context.TblSubjects.ToListAsync();
        }


        //GET ALL SUBJECT BY ROW ID
        [HttpGet("subject/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subject = await _context.TblSubjects.FindAsync(id);
            if (subject == null) return BadRequest("no record");
            return Ok(subject);
        }


        //GET ALL SUBJECT BY SUBJECT NAME
        [HttpGet("subject-by-name/{subject_name}")]
        public async Task<IActionResult> GetSubjectByName(string subject_name)
        {
            var subject = await _context.TblSubjects.Where(x => x.SubjectName == subject_name).FirstOrDefaultAsync();
            if (subject == null) return BadRequest("no record");
            return Ok(subject);
        }


        //ADD NEW SUBJECT
        [HttpPost("add-subject")]
        public async Task<IActionResult> CreateSubject(TblSubject subject)
        {
            var exisitingSubject = _context.TblSubjects.Where(x => x.SubjectName == subject.SubjectName || x.SubjectCode == subject.SubjectCode).FirstOrDefault();
            if (exisitingSubject != null) return BadRequest("subject with same name or code exists");

            await _context.TblSubjects.AddAsync(subject);
            await _context.SaveChangesAsync();

            return Ok("success");
        }

        //DELETE SUBJECT
        [HttpDelete("delete-subject/{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var subjectToDelete = await _context.TblSubjects.FindAsync(id);
            if (subjectToDelete == null) return BadRequest("no record");

            var subjectWithScores = await _context.TblStudentScores
                .Where(x => x.SubjectId == id.ToString()).FirstOrDefaultAsync();
            if (subjectWithScores != null) return BadRequest("there are students with scores for this subject");


            _context.TblSubjects.Remove(subjectToDelete);
            await _context.SaveChangesAsync();
            return Ok("success");
        }


        //UPDATE SUBJECT
        [HttpPut("update-subject/{id}")]
        public async Task<IActionResult> UpdateSubject(int id, TblSubject _subject)
        {
            var tt = await _context.TblSubjects.FindAsync(id);
            if (tt == null) return BadRequest("no record");

            if (tt != null)
            {
                tt.SubjectName = _subject.SubjectName;
                tt.SubjectCode = _subject.SubjectCode;
                tt.AddedBy = _subject.AddedBy;
                tt.AddedDate = Convert.ToDateTime(DateTime.Now);
                await _context.SaveChangesAsync();
            }
            return Ok("success");
        }


        //GET ALL SUBJECT GROUP
        [HttpGet("running-subject-list/{session_id}")]
        public async Task<IEnumerable<TblSubjectGroup>> GetSubjectGroup(string session_id)
        {
            return await _context.TblSubjectGroups.Where(x => x.SessionId == session_id).ToListAsync();
        }

        //GET ALL SUBJECT GROUP BY GROUPCODE
        [HttpGet("subject-group-by-code/{group_code}/{session_id}")]
        public async Task<IActionResult> GetSubjectGroupByCode(string group_code, string session_id)
        {
            var subject_group = await _context.TblSubjectGroups.Where(x => x.GroupCode == group_code && x.SessionId == session_id).ToListAsync();
            if (subject_group == null) return BadRequest("no record");
            return Ok(subject_group);
        }

        //GET ALL SUBJECT GROUP BY ROW ID
        [HttpGet("subject-group/{id}")]
        public async Task<IActionResult> GetBySubjectId(int id)
        {
            var subject_group = await _context.TblSubjectGroups.FindAsync(id);
            if (subject_group == null) return BadRequest("no record");
            return Ok(subject_group);
        }


        //ADD NEW SUBJECT GROUPING
        [HttpPost("add-subject-group")]
        public async Task<IActionResult> CreateSubjectGroup(TblSubjectGroup subject)
        {
            var exisitingSubjectGroup = _context.TblSubjectGroups.Where(x => x.SubjectName == subject.SubjectName && x.GroupCode == subject.GroupCode && x.SessionId == subject.SessionId).FirstOrDefault();
            if (exisitingSubjectGroup != null) return BadRequest("subject exists in the group already");

            await _context.TblSubjectGroups.AddAsync(subject);
            await _context.SaveChangesAsync();

            return Ok("success");
        }


        //DELETE SUBJECT GROUPS
        [HttpDelete("delete-subject-group/{id}")]
        public async Task<IActionResult> DeleteSubjectGroups(int id)
        {
            var subjectGroupToDelete = await _context.TblSubjectGroups.FindAsync(id);
            if (subjectGroupToDelete == null) return BadRequest("no record");

            _context.TblSubjectGroups.Remove(subjectGroupToDelete);
            await _context.SaveChangesAsync();
            return Ok("deleted");
        }

        


    }
}
