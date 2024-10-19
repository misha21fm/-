using FaskhutdinovMikhailKT_31_21.Data;
using FaskhutdinovMikhailKT_31_21.Filters;
using FaskhutdinovMikhailKT_31_21.Models;
using Microsoft.EntityFrameworkCore;

namespace FaskhutdinovMikhailKT_31_21.Interfaces.DepartmentsInterfaces
{

    public interface IDepartmentService
    {
        public Task<Department?[]> GetDepartmentListAsync(DepartmentFilter filter, CancellationToken cancellationToken);
    }

    public class DepartmentService : IDepartmentService
    {
        
        private readonly AppDbContext _dbContext;

        public DepartmentService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Department?[]> GetDepartmentListAsync(DepartmentFilter filter, CancellationToken cancellationToken = default)
        {
            
            var query = _dbContext.Set<Teacher>().AsQueryable();
            query = query.Include(t => t.Department);

            if (filter.CreationYear != null)
            {
                query = query.Where(t => t.Department!.CreateDate.Year == filter.CreationYear);
            }

            var groupDepartment = query.GroupBy(t => t.Department)
                .Select(g => new { DepKey = g.Key, TeacherCount = g.Count() });
            if (filter.TeachersCountMin != null)
            {
                groupDepartment = groupDepartment.Where(gd => gd.TeacherCount >= filter.TeachersCountMin);
            }
            if (filter.TeachersCountMax != null)
            {
                groupDepartment = groupDepartment.Where(gd => gd.TeacherCount <= filter.TeachersCountMax);
            }

            return await groupDepartment.Select(r => r.DepKey)
                .Join(_dbContext.Teachers, d => d.HeadId, t => t.TeacherId, (d, t) => new Department() { DepartmentId = d.DepartmentId, CreateDate = d.CreateDate, Name = d.Name, HeadId = d.HeadId, Head = t})
                .ToArrayAsync();
        }

    }
}
