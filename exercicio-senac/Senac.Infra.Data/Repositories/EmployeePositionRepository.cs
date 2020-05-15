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
        public void AddEmployeePosition(EmployeePosition employeePosition)
        {
            _context.EmployeePosition.Add(employeePosition);
            _context.SaveChanges();
        }

        public IEnumerable<EmployeePosition> GetAllEmployeePosition()
        {
            return _context.EmployeePosition.AsEnumerable();
        }

        public EmployeePosition GetEmployeePositionById(Guid id)
        {
            return _context.EmployeePosition
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public void RemoveEmployeePosition(EmployeePosition employeePosition)
        {
            _context.EmployeePosition.Remove(employeePosition);
            _context.SaveChanges();
        }

        public void UpdateEmployeePosition(EmployeePosition employeePosition)
        {
            _context.EmployeePosition.Attach(employeePosition);
            _context.Entry(employeePosition).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
