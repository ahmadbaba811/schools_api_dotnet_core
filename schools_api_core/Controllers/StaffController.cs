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

        [HttpGet("staff-list")]
        public async Task<IEnumerable<TblStaff>> Get()
        {
            return await _context.TblStaffs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffByID(int id)
        {
            var staff = await _context.TblStaffs.FindAsync(id);
            return staff == null ? NotFound() : Ok(staff);
        }


        [HttpPost("add-staff")]
        public async Task<IActionResult> CreateStaff(TblStaff staff)
        {
            await _context.TblStaffs.AddAsync(staff);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStaffByID), new { staffid = staff.StaffId }, staff);
        }

        [HttpPut("update-staff/{id}")]
        public async Task<IActionResult> UpdateStaff(int id, TblStaff staff)
        {
            if (id != staff.Id) return BadRequest();
            
            _context.Entry(staff).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

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

        [HttpDelete("remove-staff/{id}")]
        public async Task<IActionResult> RemoveStaff(int id, TblStaff staff)
        {
            if(id != staff.Id) return BadRequest();
            _context.Entry(staff).State = EntityState.Deleted;
            await _context.SaveChangesAsync(true);
            return Ok();
        }

        [HttpPost("assign-form-master")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AssignFormMaster(TblFormMaster formmaster)
        {
            var existingFormMaster = await _context.TblFormMasters.Where(x => x.StaffId == formmaster.StaffId && x.ClassId == formmaster.ClassId && x.SessionId == formmaster.SessionId).FirstOrDefaultAsync();
            if (existingFormMaster != null) return BadRequest("staff already assigned");

            var existingAssignedClass = await _context.TblFormMasters.Where(x => x.ClassId == formmaster.ClassId && x.SessionId == formmaster.SessionId).FirstOrDefaultAsync();
            if (existingAssignedClass != null) return BadRequest("class already assigned");

            await _context.TblFormMasters.AddAsync(formmaster);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("assign-subject-teacher")]
        public async Task<IActionResult> AssignSubjectTeacher(TblAssignTeacher teacher)
        {
            var existingSubject = await _context.TblAssignTeachers.Where(x =>
            x.SubjectCode == teacher.SubjectCode &&
            x.TermId == teacher.TermId &&
            x.ClassId == teacher.ClassId &&
            x.SessionId == teacher.SessionId
            ).FirstOrDefaultAsync();
            if (existingSubject != null) return BadRequest("subject already assigned");

            await _context.TblAssignTeachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("delete-form-master/{id}")]
        public async Task<IActionResult> DeleteFormMaster(int id, TblFormMaster formmaster)
        {
            var formMasterToDelete = await _context.TblFormMasters.FindAsync(id);

            if (formMasterToDelete == null ) return BadRequest();

            _context.TblFormMasters.Remove(formMasterToDelete);
            await _context.SaveChangesAsync();
            return Ok("deleted");
        }
    }
}
