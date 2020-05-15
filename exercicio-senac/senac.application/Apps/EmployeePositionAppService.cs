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

        public EmployeePosition GetEmployeePositionById(Guid id)
        {
            return _employeePositionService.GetEmployeePositionById(id);
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
