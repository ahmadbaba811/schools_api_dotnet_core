using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using schools_api_core.Data;
using schools_api_core.Models;


namespace schools_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly schoolDbContext  _context;
        public StaffController(schoolDbContext context) => _context = context;

        //GET ALL STAFF LIST
        [HttpGet("staff-list")]
        public async Task<IEnumerable<TblStaff>> Get()
        {
            return await _context.TblStaffs.ToListAsync();
        }

        
        //GET STAFF BY ROW ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffByID(int id)
        {
            var staff = await _context.TblStaffs.FindAsync(id);
            return staff == null ? NotFound() : Ok(staff);
        }

        //GET STAFF BY STAFF ID
        [HttpGet("by-staff-id/{staff_id}")]
        public async Task<IActionResult> GetStaffByStaffID(string staff_id)
        {
            var staff = await _context.TblStaffs.Where(x => x.StaffId == staff_id).ToListAsync();
            return staff == null ? NotFound() : Ok(staff);
        }


        //ADD NEW STAFF RECORD
        [HttpPost("add-staff")]
        public async Task<IActionResult> CreateStaff(TblStaff staff)
        {
            var _stf = await _context.TblStaffs
                .Where(x => x.Email == staff.Email || x.Phone == staff.Phone).FirstOrDefaultAsync();
            if (_stf != null) return BadRequest("staff with this email or phone exists");

            await _context.TblStaffs.AddAsync(staff);
            await _context.SaveChangesAsync();

            return Ok("success");
        }


        //UPDATE STAFF BY ROW ID
        [HttpPut("update-staff/{id}")]
        public async Task<IActionResult> UpdateStaff(int id, TblStaff staff)
        {
            if (id != staff.Id) return BadRequest();
            
            _context.Entry(staff).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("success");
        }

            
        //UPDATE STAFF NAMES WITH ROW ID
        [HttpPut("update-staff-name/{id}")]
        public async Task<IActionResult> UpdateStaffName(int id, TblStaff staff)
        {
            if(id != staff.Id) return BadRequest();
            var st = await _context.TblStaffs.FindAsync(id);
            if(st != null)
            {
                st.FirstName = staff.FirstName;
                st.MiddleName = staff.MiddleName;
                st.Surname = staff.Surname;

                await _context.SaveChangesAsync();  
            }
            return Ok();
        }


        //DELETE STAFF RECORD WITH ROW ID
        [HttpDelete("delete-staff/{id}")]
        public async Task<IActionResult> RemoveStaff(int id, TblStaff staff)
        {
            if(id != staff.Id) return BadRequest();
            _context.Entry(staff).State = EntityState.Deleted;
            await _context.SaveChangesAsync(true);
            return Ok();
        }


        //ASSIGN NEW FORM MASTER TO CLASS
        [HttpPost("assign-form-master")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AssignFormMaster(TblFormMaster formmaster)
        {
            var existingFormMaster = await _context.TblFormMasters.Where(x => x.StaffId == formmaster.StaffId && x.ClassId == formmaster.ClassId && x.SessionId == formmaster.SessionId).FirstOrDefaultAsync();
            if (existingFormMaster != null) return BadRequest("staff already assigned");

            var existingFormMasterinSession = await _context.TblFormMasters.Where(x => x.StaffId == formmaster.StaffId &&  x.SessionId == formmaster.SessionId).FirstOrDefaultAsync();
            if (existingFormMasterinSession != null) return BadRequest("staff already assigned in this session");

            var existingAssignedClass = await _context.TblFormMasters.Where(x => x.ClassId == formmaster.ClassId && x.SessionId == formmaster.SessionId).FirstOrDefaultAsync();
            if (existingAssignedClass != null) return BadRequest("class already assigned");

            await _context.TblFormMasters.AddAsync(formmaster);
            await _context.SaveChangesAsync();
            return Ok("success");
        }


        //DELETE FORM MASTER BY ROW ID
        [HttpDelete("delete-form-master/{id}")]
        public async Task<IActionResult> DeleteFormMaster(int id)
        {
            var formMasterToDelete = await _context.TblFormMasters.FindAsync(id);

            if (formMasterToDelete == null) return BadRequest("no record");

            _context.TblFormMasters.Remove(formMasterToDelete);
            await _context.SaveChangesAsync();
            return Ok("success");
        }


        //ALL FORM MASTERS LIST
        [HttpGet("form-masters/list")]
        public async Task<IActionResult> GetFormMasters()
        {
            var formmasters = await _context.TblFormMasters.ToListAsync();
            return Ok(formmasters);
        }


        //ALL FORM MASTERS LIST
        [HttpGet("form-masters/list/{staff_id}")]
        public async Task<IActionResult> GetFormMastersByStaffID(string staff_id)
        {
            var formmaster = await _context.TblFormMasters.Where(x => x.StaffId == staff_id).ToListAsync();
            return Ok(formmaster);
        }


        //ASSIGN SUBJECT TO TEACHER
        [HttpPost("assign-subject-teacher")]
        public async Task<IActionResult> AssignSubjectTeacher(TblAssignTeacher teacher)
        {
            var existingSubject = await _context.TblAssignTeachers.Where(x =>
            x.SubjectId == teacher.SubjectId &&
            x.TermId == teacher.TermId &&
            x.ClassId == teacher.ClassId &&
            x.SessionId == teacher.SessionId
            ).FirstOrDefaultAsync();
            if (existingSubject != null) return BadRequest("subject already assigned");

            await _context.TblAssignTeachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return Ok("success");
        }


        //DELETE SUBJECT TEACHER ASSIGNMENT
        [HttpDelete("delete-subject-teacher/{id}")]
        public async Task<IActionResult> DeleteSubjectTeacher(int id)
        {
            var teacherToDelete = await _context.TblAssignTeachers.FindAsync(id);

            if (teacherToDelete == null) return BadRequest();

            _context.TblAssignTeachers.Remove(teacherToDelete);
            await _context.SaveChangesAsync();
            return Ok("success");
        }


        //ALL SUBJECT TEACHERS LIST
        [HttpGet("subject-teachers/list")]
        public async Task<IActionResult> GetSubjectTeachers()
        {
            var teachers = await _context.TblAssignTeachers.ToListAsync();
            return Ok(teachers);
        }


        //ALL SUBJECT TEACHERS LIST
        [HttpGet("subject-teachers/list/{staff_id}")]
        public async Task<IActionResult> GetSubjectTeachersByStaffID(string staff_id)
        {
            var teachers = await _context.TblAssignTeachers.Where(x => x.StaffId == staff_id).ToListAsync();
            return Ok(teachers);
        }


        //GET ACTIVITIES BY STAFF ID
        [HttpGet("staff-activities")]
        public async Task<IActionResult> GetStaffActivities()
        {
            var activites = await _context.TblStaffActivities.ToListAsync();
            return Ok(activites);
        }

        //GET ACTIVITIES BY STAFF ID
        [HttpGet("staff-activities/{staff_id}")]
        public async Task<IActionResult> GetStaffActivitiesByStaffID(string staff_id)
        {
            var activites = await _context.TblStaffActivities.Where(x => x.StaffId == staff_id).ToListAsync();
            return Ok(activites);
        }

        //ADD STAFF ACTIVITIES
        [HttpPost("add-staff-activity")]
        public async Task<IActionResult> PostNewActivity(TblStaffActivity activity)
        {
            var nee_activity = _context.TblStaffActivities.AddAsync(activity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStaffActivitiesByStaffID), new { staff_id = activity.StaffId }, activity);
        }

    }
}
