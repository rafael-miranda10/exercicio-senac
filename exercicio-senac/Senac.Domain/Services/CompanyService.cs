using Flunt.Notifications;
using Senac.Domain.Entities;
using Senac.Domain.Interfaces.Repositories;
using Senac.Domain.Interfaces.Services;
using Senac.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senac.Domain.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public CompanyService(ICompanyRepository companyRepository, IEmployeeRepository employeeRepository)
        {
            _companyRepository = companyRepository;
            _employeeRepository = employeeRepository;
        }

        public Company AddCompany(Company company)
        {
            return _companyRepository.AddCompany(company);
        }

        public IEnumerable<Company> GetACompanyEmployees(int idCompany)
        {
            return _companyRepository.GetACompanyEmployees(idCompany);
        }

        public IEnumerable<Company> GetAllCompany()
        {
            return _companyRepository.GetAllCompany();
        }

        public Company GetCompanyByDocument(Document document)
        {
            return _companyRepository.GetCompanyByDocument(document);
        }

        public Company GetCompanyById(int id)
        {
            return _companyRepository.GetCompanyById(id);
        }

        public Company RegisterEmployeeInCompany(int idCompany, List<int> employees)
        {
            var company = _companyRepository.GetCompanyById(idCompany);
            if (company == null)
                return null;

            foreach (var idEmployee in employees)
            {
                var employee = _employeeRepository.GetEmployeeById(idEmployee);
                if (company.ValidateEmployeeToCompany(employee))
                    _employeeRepository.UpdateEmployee(new Employee(employee.Id, employee.Name, employee.Document,
                        employee.Email, employee.Address, employee.RegisterCode, company.Id, company));
            }

            if(company.Notifications.Any())
                 company.AddNotification(new Notification("Company.Employees", $"Os funcionários não listados foram vinculados a empresa {company.FantasyName} com sucesso."));

            return company;
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
