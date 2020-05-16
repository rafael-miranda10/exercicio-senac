using Senac.Domain.Entities;
using Senac.Domain.ValueObjects;
using System.Collections.Generic;
using System;

namespace Senac.Domain.Interfaces.Services
{
    public interface ICompanyService
    {
        Company AddCompany(Company company);
        void UpdateCompany(Company company);
        void RemoveCompany(Company company);
        IEnumerable<Company> GetAllCompany();
        Company GetCompanyByDocument(Document document);
        Company GetCompanyById(int id);
    }
}
