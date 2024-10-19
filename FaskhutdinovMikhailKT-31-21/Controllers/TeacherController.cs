using FaskhutdinovMikhailKT_31_21.Data;
using FaskhutdinovMikhailKT_31_21.Filters;
using FaskhutdinovMikhailKT_31_21.Interfaces.DepartmentsInterfaces;
using FaskhutdinovMikhailKT_31_21.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace FaskhutdinovMikhailKT_31_21.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TeacherController : Controller
    {
    
        private readonly ILogger<TeacherController> _logger;
        private readonly ITeacherService _teacherService;
        private AppDbContext _dbContext;

        public TeacherController(ILogger<TeacherController> logger, ITeacherService departmentService)
        {
            _logger = logger;
            _teacherService = departmentService;
        }

        [HttpGet(Name = "GetTeachersList")]
        public async Task<IActionResult> GetDepartmentListAsync([FromQuery] TeacherFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherService.GetTeacherListAsync(filter, cancellationToken);
            return Ok(teachers);
        }

        [HttpPost(Name = "CreateTeachers")]
        public async Task<IActionResult> AddTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default)
        {
            await _teacherService.AddTeacherAsync(teacher, cancellationToken);
            return Ok();
        }

        [HttpPut(Name = "UpdateTeachers")]
        public async Task<IActionResult> UpdateTeacherAsync(Teacher teacher, CancellationToken cancellationToken)
        {
            await _teacherService.UpdateTeacherAsync(teacher, cancellationToken);
            return Ok();
        }

        [HttpDelete(Name = "DeleteTeachers")]
        public async Task<IActionResult> DeleteTeachersAsync(Teacher teacher, CancellationToken cancellationToken)
        {
            await _teacherService.DeleteTeachersAsync(teacher, cancellationToken);
            return Ok();
        }
    }
}
