using Senac.Domain.Entities;
using Senac.Domain.ValueObjects;
using System.Collections.Generic;

namespace Senac.Application.Interfaces
{
    public interface ICompanyAppService
    {
        Company AddCompany(Company company);
        void UpdateCompany(Company company);
        void RemoveCompany(Company company);
        Company RegisterEmployeeInCompany(int idCompany, List<int> employees);
        IEnumerable<Company> GetAllCompany();
        Company GetACompanyEmployees(int idCompany);
        Company GetCompanyByDocument(Document document);
        Company GetCompanyById(int id);
    }
}
