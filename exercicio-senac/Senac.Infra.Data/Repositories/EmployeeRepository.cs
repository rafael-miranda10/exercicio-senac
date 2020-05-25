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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SenacContext _context;

        public EmployeeRepository(SenacContext context)
        {
            _context = context;
        }

        public Employee AddEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _context.Employee.AsEnumerable();
        }

        public IEnumerable<Employee> GetAllEmployeeWithoutCompany()
        {
            return _context.Employee
                .Where(x => x.CompanyId == null)
                .AsEnumerable();
        }

        public IEnumerable<Employee> GetAllEmployeeWithoutPosition(int idCompany)
        {
            return _context.Employee
                .Include(c => c.Company)
                .Where(x => x.CompanyId == idCompany &&
                       x.EmployeePositionId == null)
                .AsEnumerable();
        }

        public Employee GetEmployeeByDocument(Document document)
        {
            return _context.Employee
                .AsNoTracking()
                .Where(x => x.Document.Number == document.Number)
                .FirstOrDefault();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employee
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public void RemoveEmployee(Employee employee)
        {
            _context.Employee.Remove(employee);
            _context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Employee.Update(employee);
            _context.SaveChanges();
        }
    }
}
