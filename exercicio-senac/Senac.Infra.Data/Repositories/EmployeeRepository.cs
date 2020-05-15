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

        public Employee GetEmployeeByDocument(Document document)
        {
            return _context.Employee
                .Where(x => x.Document.Number == document.Number)
                .FirstOrDefault();
        }

        public Employee GetEmployeeById(Guid id)
        {
            return _context.Employee
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
            _context.Employee.Attach(employee);
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
