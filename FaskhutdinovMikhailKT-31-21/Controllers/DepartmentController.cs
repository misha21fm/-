using FaskhutdinovMikhailKT_31_21.Filters;
using FaskhutdinovMikhailKT_31_21.Interfaces.DepartmentsInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace FaskhutdinovMikhailKT_31_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : Controller
    {

        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentService departmentService)
        {
            _logger = logger;
            _departmentService = departmentService;
        }

        [HttpGet(Name = "GetDepartmentList")]
        public async Task<IActionResult> GetDepartmentList([FromQuery]DepartmentFilter filter, CancellationToken cancellationToken = default)
        { 
            var departments = await _departmentService.GetDepartmentListAsync(filter, cancellationToken);

            return Ok(departments);
        }
    }
}
