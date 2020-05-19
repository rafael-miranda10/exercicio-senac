using Senac.Domain.Entities;
using Senac.Domain.ValueObjects;
using System.Collections.Generic;
using System;

namespace Senac.Domain.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        Company AddCompany(Company company);
        void UpdateCompany(Company company);
        void RemoveCompany(Company company);
        IEnumerable<Company> GetAllCompany();
        IEnumerable<Company> GetACompanyEmployees(int idCompany);
        Company GetCompanyByDocument(Document document);
        Company GetCompanyById(int id);
    }
}
