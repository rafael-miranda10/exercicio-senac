using Senac.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Senac.Application.Interfaces
{
    public interface IEmployeePositionAppService
    {
        void AddEmployeePosition(EmployeePosition employeePosition);
        void UpdateEmployeePosition(EmployeePosition employeePosition);
        void RemoveEmployeePosition(EmployeePosition employeePosition);
        IEnumerable<EmployeePosition> GetAllEmployeePosition();
        EmployeePosition GetEmployeePositionById(Guid id);
    }
}
