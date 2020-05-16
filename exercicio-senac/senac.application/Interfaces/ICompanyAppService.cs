using Senac.Domain.Entities;
using Senac.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Senac.Application.Interfaces
{
    public interface ICompanyAppService
    {
        Company AddCompany(Company company);
        void UpdateCompany(Company company);
        void RemoveCompany(Company company);
        IEnumerable<Company> GetAllCompany();
        Company GetCompanyByDocument(Document document);
        Company GetCompanyById(int id);
    }
}
