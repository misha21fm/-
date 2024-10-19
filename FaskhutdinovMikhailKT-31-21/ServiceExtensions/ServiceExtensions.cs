using FaskhutdinovMikhailKT_31_21.Interfaces.DepartmentsInterfaces;
using System.Runtime.CompilerServices;

namespace FaskhutdinovMikhailKT_31_21.ServiceExtensions
{
    public static class ServiceExtensions
    {

        public static IServiceCollection AddService(this IServiceCollection services)
        {

            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ITeacherService, TeacherService>();

            return services;
        }
    }
}
