using FaskhutdinovMikhailKT_31_21.Data;
using FaskhutdinovMikhailKT_31_21.Filters;
using FaskhutdinovMikhailKT_31_21.Interfaces.DepartmentsInterfaces;
using FaskhutdinovMikhailKT_31_21.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaskhutdinovMikhailKT31_21.Tests
{
    public class DepartmentIntegrationTest
    {
        public readonly DbContextOptions<AppDbContext> _dbContextOptions;

        public DepartmentIntegrationTest() 
        {
            this._dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("temp_test_db")
                .Options;
        }

        [Fact]
        public async Task GetDepartmentByName_IVT_OneObjects()
        {

            var context = new AppDbContext(_dbContextOptions);
            var departmentService = new DepartmentService(context);
            var departments = new List<Department>
            {
                new Department
                {
                    Name = "IVT",
                    CreateDate = new DateTime(1999,12,15)
                },
                new Department
                {
                    Name = "NotIVT",
                    CreateDate = new DateTime(1999,12,15)
                }
            };
            await context.Set<Department>().AddRangeAsync(departments);

            await context.SaveChangesAsync();

            var departmentList = context.Departments.ToList();
            var IVTDepartment = departmentList.FirstOrDefault(d => d.Name == "IVT");
            var teachers = new List<Teacher>
            {
                new Teacher
                {
                    FirstName = "Иванов",
                    LastName = "Иван",
                    Patronymic = "Иванович",
                    DepartmentId = IVTDepartment.DepartmentId
                },
                new Teacher
                {
                    FirstName = "Петров",
                    LastName = "Петр",
                    Patronymic = "Петрович",
                    DepartmentId = IVTDepartment.DepartmentId
                },
                new Teacher
                {
                    FirstName = "Семенов",
                    LastName = "Семен",
                    Patronymic = "Семенович",
                    DepartmentId = IVTDepartment.DepartmentId
                },
                new Teacher
                {
                    FirstName = "Александров",
                    LastName = "Александр",
                    Patronymic = "Александрович",
                    DepartmentId = departmentList.FirstOrDefault(d => d.Name == "NotIVT")?.DepartmentId
                },
            };
            await context.Set<Teacher>().AddRangeAsync(teachers);

            await context.SaveChangesAsync();

            var deps = context.Departments.ToList();
            foreach(var dep in deps)
            {
                dep.HeadId = Random.Shared.Next(teachers.Count);
            }
            context.UpdateRange(deps);
            context.SaveChangesAsync();

            var filter = new DepartmentFilter
            {
                DepartmentName = IVTDepartment.Name
            };
            var departmentResult = await departmentService.GetDepartmentListAsync(filter, CancellationToken.None);

            Assert.Equal(1, departmentResult.Length);
        }

    }
}
