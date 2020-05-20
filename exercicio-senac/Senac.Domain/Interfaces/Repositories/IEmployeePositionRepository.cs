using Senac.Domain.Entities;
using System.Collections.Generic;
using System;

namespace Senac.Domain.Interfaces.Repositories
{
    public interface IEmployeePositionRepository
    {
        EmployeePosition AddEmployeePosition(EmployeePosition employeePosition);
        void UpdateEmployeePosition(EmployeePosition employeePosition);
        void RemoveEmployeePosition(EmployeePosition employeePosition);
        IEnumerable<EmployeePosition> GetAllEmployeePosition();
        EmployeePosition GetEmployeePositionWithEmployees(int idPosition);
        EmployeePosition GetEmployeePositionById(int id);
    }
}
