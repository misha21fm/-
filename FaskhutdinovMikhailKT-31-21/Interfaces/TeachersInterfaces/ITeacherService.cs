using FaskhutdinovMikhailKT_31_21.Data;
using FaskhutdinovMikhailKT_31_21.Filters;
using FaskhutdinovMikhailKT_31_21.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace FaskhutdinovMikhailKT_31_21.Interfaces.TeachersInterfaces
{
    public interface ITeacherService
    {
        public Task<Teacher?[]> GetTeacherListAsync(TeacherFilter filter, CancellationToken cancellationToken);
        public Task AddTeacherAsync(Teacher teacher, CancellationToken cancellationToken);
        public Task UpdateTeacherAsync(Teacher teacher, CancellationToken cancellationToken);
        public Task DeleteTeachersAsync(Teacher teacher, CancellationToken cancellationToken);

    }

    public class TeacherService : ITeacherService
    {

        private readonly AppDbContext _dbContext;

        public TeacherService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Teacher?[]> GetTeacherListAsync(TeacherFilter filter, CancellationToken cancellationToken = default)
        {

            var teachers = _dbContext.Set<Teacher>().AsQueryable();

            if (filter.TeacherId != null)
            {
                teachers = teachers.Where(t => t.TeacherId == filter.TeacherId);
            }

            return await teachers.ToArrayAsync(cancellationToken);
        }

        public async Task AddTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default)
        {
            await _dbContext.Teachers.AddAsync(teacher, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateTeacherAsync(Teacher teacher, CancellationToken cancellationToken)
        {
            _dbContext.Update(teacher);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteTeachersAsync(Teacher teacher, CancellationToken cancellationToken)
        {
            _dbContext.Remove(teacher);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
