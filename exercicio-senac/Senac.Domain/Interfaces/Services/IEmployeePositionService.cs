using Senac.Domain.Entities;
using System.Collections.Generic;
using System;

namespace Senac.Domain.Interfaces.Services
{
    public interface IEmployeePositionService
    {
        EmployeePosition AddEmployeePosition(EmployeePosition employeePosition);
        void UpdateEmployeePosition(EmployeePosition employeePosition);
        void RemoveEmployeePosition(EmployeePosition employeePosition);
        IEnumerable<EmployeePosition> GetAllEmployeePosition();
        EmployeePosition GetEmployeePositionById(Guid id);
    }
}
