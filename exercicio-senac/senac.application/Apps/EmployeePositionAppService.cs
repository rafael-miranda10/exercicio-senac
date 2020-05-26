using Flunt.Notifications;
using Senac.Application.Interfaces;
using Senac.Domain.Entities;
using Senac.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Senac.Application.Apps
{
    public class EmployeePositionAppService : IEmployeePositionAppService
    {
        private readonly IEmployeePositionService _employeePositionService;

        public EmployeePositionAppService(IEmployeePositionService employeePositionService)
        {
            _employeePositionService = employeePositionService;
        }

        public EmployeePosition AddEmployeePosition(EmployeePosition employeePosition)
        {
           return _employeePositionService.AddEmployeePosition(employeePosition);
        }

        public IEnumerable<EmployeePosition> GetAllEmployeePosition()
        {
            return _employeePositionService.GetAllEmployeePosition();
        }

        public EmployeePosition GetEmployeePositionById(int id)
        {
            return _employeePositionService.GetEmployeePositionById(id);
        }

        public EmployeePosition GetEmployeePositionWithEmployees(int idPosition)
        {
            return _employeePositionService.GetEmployeePositionWithEmployees(idPosition);
        }

        public List<Notification> IncludeEmployeeOnPosition(List<Employee> employeesPositions)
        {
            return _employeePositionService.IncludeEmployeeOnPosition(employeesPositions);
        }

        public void RemoveEmployeePosition(EmployeePosition employeePosition)
        {
            _employeePositionService.RemoveEmployeePosition(employeePosition);
        }

        public void UpdateEmployeePosition(EmployeePosition employeePosition)
        {
            _employeePositionService.UpdateEmployeePosition(employeePosition);
        }
    }
}
