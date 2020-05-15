using Microsoft.Extensions.DependencyInjection;
using Senac.Domain.Interfaces.Repositories;
using Senac.Domain.Interfaces.Services;
using Senac.Domain.Services;
using Senac.Infra.Data.Repositories;

namespace Senac.Infra.IoC
{
    public class DependencyInjectorSenac
    {
        public static void Registrar(IServiceCollection svcCollection)
        {
            //Aplicação

            //Dominio
            svcCollection.AddScoped<IEmployeeService, EmployeeService>();
            svcCollection.AddScoped<IEmployeePositionService, EmployeePositionService>();
            svcCollection.AddScoped<ICompanyService, CompanyService>();

            //Repositorio
            svcCollection.AddScoped<IEmployeeRepository, EmployeeRepository>();
            svcCollection.AddScoped<IEmployeePositionRepository, EmployeePositionRepository>();
            svcCollection.AddScoped<ICompanyRepository, CompanyRepository>();
        }
    }
}
