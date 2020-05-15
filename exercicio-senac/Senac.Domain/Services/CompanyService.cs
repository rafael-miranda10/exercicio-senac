using Senac.Domain.Entities;
using Senac.Domain.Interfaces.Repositories;
using Senac.Domain.Interfaces.Services;
using Senac.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Senac.Domain.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public Company AddCompany(Company company)
        {
           return _companyRepository.AddCompany(company);
        }

        public IEnumerable<Company> GetAllCompany()
        {
            return _companyRepository.GetAllCompany();
        }

        public Company GetCompanyByDocument(Document document)
        {
            return _companyRepository.GetCompanyByDocument(document);
        }

        public Company GetCompanyById(Guid id)
        {
            return _companyRepository.GetCompanyById(id);
        }

        public void RemoveCompany(Company company)
        {
            _companyRepository.RemoveCompany(company);
        }

        public void UpdateCompany(Company company)
        {
            _companyRepository.UpdateCompany(company);
        }
    }
}
