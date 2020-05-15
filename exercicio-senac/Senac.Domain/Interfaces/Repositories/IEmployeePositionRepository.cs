using Senac.Domain.Entities;
using System.Collections.Generic;
using System;

namespace Senac.Domain.Interfaces.Repositories
{
    public interface IEmployeePositionRepository
    {
        void AddEmployeePosition(EmployeePosition employeePosition);
        void UpdateEmployeePosition(EmployeePosition employeePosition);
        void RemoveEmployeePosition(EmployeePosition employeePosition);
        IEnumerable<EmployeePosition> GetAllEmployeePosition();
        EmployeePosition GetEmployeePositionById(Guid id);
    }
}
