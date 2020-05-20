using Microsoft.EntityFrameworkCore;
using Senac.Domain.Entities;
using Senac.Domain.Interfaces.Repositories;
using Senac.Domain.ValueObjects;
using Senac.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senac.Infra.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly SenacContext _context;

        public CompanyRepository(SenacContext context)
        {
            _context = context;
        }
        public Company AddCompany(Company company)
        {
            _context.Company.Add(company);
            _context.SaveChanges();
            return company;
        }

        public IEnumerable<Company> GetACompanyEmployees(int idCompany)
        {
            return _context.Company
                 .Include(x => x.Employees)
                 .Where(c => c.Id == idCompany)
                 .AsEnumerable();
        }

        public IEnumerable<Company> GetAllCompany()
        {
            return _context.Company.AsEnumerable();
        }

        public Company GetCompanyByDocument(Document document)
        {
            return _context.Company
                .Where(x => x.Document.Number == document.Number)
                .FirstOrDefault();
        }

        public Company GetCompanyById(int id)
        {
            return _context.Company
                .AsNoTracking()
                .Include(x => x.Employees)
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public void RemoveCompany(Company company)
        {
            _context.Company.Remove(company);
            _context.SaveChanges();
        }

        public void UpdateCompany(Company company)
        {
            _context.Company.Update(company);
            _context.SaveChanges();
        }
    }
}
