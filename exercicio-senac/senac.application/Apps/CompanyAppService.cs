using Senac.Application.Interfaces;
using Senac.Domain.Entities;
using Senac.Domain.Interfaces.Services;
using Senac.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Senac.Application.Apps
{
    public class CompanyAppService : ICompanyAppService
    {
        private readonly ICompanyService _companyService;

        public CompanyAppService(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        public Company AddCompany(Company company)
        {
           return _companyService.AddCompany(company);
        }

        public IEnumerable<Company> GetACompanyEmployees(int idCompany)
        {
            return _companyService.GetACompanyEmployees(idCompany);
        }

        public IEnumerable<Company> GetAllCompany()
        {
            return _companyService.GetAllCompany();
        }

        public Company GetCompanyByDocument(Document document)
        {
            return _companyService.GetCompanyByDocument(document);
        }

        public Company GetCompanyById(int id)
        {
            return _companyService.GetCompanyById(id);
        }

        public void RemoveCompany(Company company)
        {
            _companyService.RemoveCompany(company);
        }

        public void UpdateCompany(Company company)
        {
            _companyService.UpdateCompany(company);
        }
    }
}
