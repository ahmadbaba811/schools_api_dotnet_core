using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.IsisMtt.X509;
using schools_api_core.Data;
using schools_api_core.Models;
using System.Diagnostics;

namespace schools_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly schoolDbContext _context;
        public ResultController(schoolDbContext context) => _context = context;

        //GET ALL RESULT COMMENT LIST
        [HttpGet("student-list/{staff_id}/{term_id}/{session_id}")]
        public async Task<IActionResult> GetStaffStudents(string staff_id, string term_id, string session_id)
        {
            var result = (from sb in _context.TblStudentBiodata
                         join sg in _context.TblSubjectGroups on sb.SubjectGroup equals sg.GroupCode
                         join at in _context.TblAssignTeachers on sg.Id.ToString() equals at.SubjectId
                         where at.StaffId == staff_id && sg.SessionId == session_id && at.TermId == term_id
                         select new
                         {
                             sb.Regno,
                             sb.SubjectGroup,
                             sb.ClassId
                         }).Distinct();

            return Ok(result);
        }


        [HttpPost("add-subject-score")]
        public async Task<IActionResult> PostSubjectScore(TblStudentScore score)
        {
            var tt = await _context.TblStudentScores.Where( x => 
            x.TermId == score.TermId && x.ClassId == score.ClassId && x.SessionId == score.SessionId && x.Regno == score.Regno && x.SubjectId == score.SubjectId ).FirstOrDefaultAsync();

            if (tt != null)
            {
                tt.Ca1 = score.Ca1;
                tt.Ca2 = score.Ca2;
                tt.Test1 = score.Test1;
                tt.Test2 = score.Test2;
                tt.Exam = score.Exam;
                tt.UpdatedBy = score.UpdatedBy;
                tt.Total = score.Total;
                tt.Grade = score.Grade;
                tt.Comment = score.Comment;
                tt.UpdatedDate = Convert.ToDateTime(DateTime.Now);
                await _context.SaveChangesAsync();
                return Ok("success");
            }
            else
            {
                var _new_score = new TblStudentScore()
                {
                    Regno = score.Regno,
                    SessionId = score.SessionId,
                    TermId = score.TermId,  
                    ClassId = score.ClassId,
                    Ca1 = score.Ca1,
                    Ca2 = score.Ca2,
                    Test1 = score.Test1,
                    Test2 = score.Test2,
                    Exam = score.Exam,
                    ClassName = score.ClassName,
                    TermName = score.TermName,
                    SessionName = score.SessionName,
                    SubjectId = score.SubjectId,
                    SubjectName = score.SubjectName,
                    FullName = score.FullName,
                    Total  = score.Total,
                    Grade = score.Grade,
                    Comment = score.Comment,
                    AddedBy = score.AddedBy,
                    UpdatedDate = Convert.ToDateTime(DateTime.Now)
                };
                await _context.TblStudentScores.AddAsync(_new_score);
                await _context.SaveChangesAsync();
                return Ok("success");
            }
            
        }


        //GET RESULT ENTRY
        [HttpPost("subject-scores")]
        public async Task<IActionResult> GetSubjectScores(TblStudentScore sc)
        {
            var scores = await _context.TblStudentScores.Where(x => x.TermId == sc.TermId && x.ClassId == sc.ClassId && x.SessionId == sc.SessionId && x.SubjectId == sc.SubjectId).ToListAsync();
            if (scores == null) return Ok("no record");

            return Ok(scores);
        }



        //GET LATEST ENTRIES BY DATE
        [HttpGet("letest-subject-scores/{staff_id}")]
        public async Task<IActionResult> GetLatestSubjectScores(string staff_id)
        {
            var scores = await _context.TblStudentScores.OrderByDescending(x => x.UpdatedDate).Where(x => x.AddedBy == staff_id).Take(10).ToListAsync();
            if (scores == null) return Ok("no record");

            return Ok(scores);
        }


    }
}
