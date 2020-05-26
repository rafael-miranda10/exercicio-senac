using Flunt.Notifications;
using Senac.Domain.Entities;
using System.Collections.Generic;

namespace Senac.Domain.Interfaces.Services
{
    public interface IEmployeePositionService
    {
        EmployeePosition AddEmployeePosition(EmployeePosition employeePosition);
        void UpdateEmployeePosition(EmployeePosition employeePosition);
        void RemoveEmployeePosition(EmployeePosition employeePosition);
        IEnumerable<EmployeePosition> GetAllEmployeePosition();
        EmployeePosition GetEmployeePositionById(int id);
        EmployeePosition GetEmployeePositionWithEmployees(int idPosition);
        List<Notification> IncludeEmployeeOnPosition(List<Employee> employeesPositions);
    }
}
