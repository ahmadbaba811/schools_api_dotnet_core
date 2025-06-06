﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using schools_api_core.Data;
using schools_api_core.Models;
using System.Runtime.CompilerServices;

namespace schools_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BioDataController : ControllerBase
    {
        private readonly schoolDbContext _context;
        public BioDataController(schoolDbContext context) => _context = context;

        //GET ALL STUDENTS LIST
        [HttpGet("student-list")]
        public async Task<IActionResult> Get()
        {
            var student = await _context.TblStudentBiodata.ToListAsync();
            return Ok(student);
        }

        
        //GET ALL STUDENTS LIST BY CLASS ID
        [HttpGet("student-list/{class_id}")]
        public async Task<IActionResult> GetStudentByClassID(string class_id)
        {
            var student = await _context.TblStudentBiodata.Where(x => x.ClassId == class_id ).ToListAsync();
            return Ok(student);
        }

        //GET ALL STUDENTS BY ROW ID
        [HttpGet("student/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _context.TblStudentBiodata.FindAsync(id);
            if (student == null) return BadRequest("no record");
            return Ok(student);
        }

        //GET LAST STUDENT ID
        [HttpGet("last-student-id")]
        public async Task<IActionResult> GetLastStudentID()
        {
            var student = await _context.TblStudentBiodata.OrderByDescending(x => x.Regno).FirstOrDefaultAsync();
            if (student == null) return Ok("no record");
            return Ok(student);
        }

        //GET ALL STUDENTS BY STUDENT ID
        [HttpPost("student-by-regno")]
        public async Task<IActionResult> GetByStudentId(TblStudentBiodatum stud)
        {
            var student = await _context.TblStudentBiodata.Where(x => x.Regno == stud.Regno).ToListAsync();
            if (student == null) return BadRequest("no record");
            return Ok(student);
        }


        //ADD NEW STUDENTS
        [HttpPost("add-student")]
        public async Task<IActionResult> CreatePComment(TblStudentBiodatum stud)
        {
            /*var studToAdd = await _context.TblStudentBiodata.Where(x => x.Phone == stud.Phone).FirstOrDefaultAsync();
            if (studToAdd != null) return BadRequest("student exists");*/

            await _context.TblStudentBiodata.AddAsync(stud);
            var check = await _context.SaveChangesAsync();

            if(check > 0 ) { return Ok("success"); }
            else
            {
                return BadRequest();
            }
        }

        //DELETE STUDENTS
        [HttpDelete("delete-student/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var studentToDelete = await _context.TblStudentBiodata.FindAsync(id);
            if (studentToDelete == null) return BadRequest("no record");

            _context.TblStudentBiodata.Remove(studentToDelete);
            await _context.SaveChangesAsync();
            return Ok("success");
        }

        //UPDATE STUDENTS BY ROW ID
        [HttpPut("update-student/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, TblStudentBiodatum stud)
        {
            if (id != stud.Id) return BadRequest("no result");

            _context.Entry(stud).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("success");
        }

        //UPDATE STUDENT STATUS BY REGNO
        [HttpPut("update-student-status")]
        public async Task<IActionResult> UpdateStatus(int id, TblStudentBiodatum stud)
        {
            var studToUpdate = await _context.TblStudentBiodata.Where(x => x.Regno == stud.Regno).FirstOrDefaultAsync();
            if (studToUpdate == null) return NotFound("no record");

            if(studToUpdate != null)
            {
                studToUpdate.StudentStatus = stud.StudentStatus;
                await _context.SaveChangesAsync();
            }

            return Ok("success");
        }

        //UPDATE STUDENT CLASS BY REGNO
        [HttpPut("update-student-class")]
        public async Task<IActionResult> UpdateClass(TblStudentBiodatum stud)
        {
            var studToUpdate = await _context.TblStudentBiodata.Where(x => x.Regno == stud.Regno).FirstOrDefaultAsync();
            if (studToUpdate == null) return NotFound("no record");

            if (studToUpdate != null)
            {
                studToUpdate.ClassId = stud.ClassId;
                await _context.SaveChangesAsync();
            }

            return Ok("success");
        }

        //UPDATE STUDENT GROUP BY REGNO
        [HttpPut("update-student-group")]
        public async Task<IActionResult> UpdateGroup(int id, TblStudentBiodatum stud)
        {
            var studToUpdate = await _context.TblStudentBiodata.Where(x => x.Regno == stud.Regno).FirstOrDefaultAsync();
            if (studToUpdate == null) return NotFound("no record");

            if (studToUpdate != null)
            {
                studToUpdate.SubjectGroup = stud.SubjectGroup;
                await _context.SaveChangesAsync();
            }

            return Ok("success");
        }

        //UPDATE STUDENT GROUP BY CLASS
        [HttpPut("update-student-group/{subject_group}")]
        public async Task<IActionResult> UpdateGroupByClass(string subject_group, TblStudentBiodatum stud)
        {
            var stdList =  _context.TblStudentBiodata.Where(x => x.ClassId == stud.ClassId).ToListAsync();
            if (stdList == null) return NotFound("no record");

            var sGroup = subject_group;
            var update = await _context.TblStudentBiodata.FromSql($"UPDATE dbo.tbl_student_biodata SET subject_group = {sGroup} WHERE class_id = {stud.ClassId}").ToListAsync();

            return Ok("success");
        }

        //UPDATE STUDENT PARENT BY REGNO
        [HttpPut("update-student-parent")]
        public async Task<IActionResult> UpdateParent(TblStudentBiodatum stud)
        {
            var studToUpdate = await _context.TblStudentBiodata.Where(x => x.Regno == stud.Regno).FirstOrDefaultAsync();
            if (studToUpdate == null) return NotFound("no record");

            if (studToUpdate != null)
            {
                studToUpdate.ParentId = stud.ParentId;
                await _context.SaveChangesAsync();
            }

            return Ok("success");
        }
    }

}
