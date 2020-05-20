using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Senac.Domain.Entities;
using Senac.Domain.Interfaces.Repositories;
using Senac.Infra.Data.Context;

namespace Senac.Infra.Data.Repositories
{
    public class EmployeePositionRepository : IEmployeePositionRepository
    {
        private readonly SenacContext _context;

        public EmployeePositionRepository(SenacContext context)
        {
            _context = context;
        }
        public EmployeePosition AddEmployeePosition(EmployeePosition employeePosition)
        {
            _context.EmployeePosition.Add(employeePosition);
            _context.SaveChanges();
            return employeePosition;
        }

        public IEnumerable<EmployeePosition> GetAllEmployeePosition()
        {
            return _context.EmployeePosition.AsEnumerable();
        }

        public EmployeePosition GetEmployeePositionById(int id)
        {
            return _context.EmployeePosition
                .AsNoTracking()
                .Include(x => x.Employees)
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public EmployeePosition GetEmployeePositionWithEmployees(int idPosition)
        {
            return _context.EmployeePosition
                .Include(x => x.Employees)
                   .ThenInclude(Employee => Employee.Company)
                .Where(ep => ep.Id == idPosition)
                .FirstOrDefault();
        }

        public void RemoveEmployeePosition(EmployeePosition employeePosition)
        {
            _context.EmployeePosition.Remove(employeePosition);
            _context.SaveChanges();
        }

        public void UpdateEmployeePosition(EmployeePosition employeePosition)
        {
            _context.EmployeePosition.Update(employeePosition);
            _context.SaveChanges();
        }
    }
}
