using Senac.Domain.Entities;
using Senac.Domain.Interfaces.Repositories;
using Senac.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Senac.Domain.Services
{
    public class EmployeePositionService : IEmployeePositionService
    {
        private readonly IEmployeePositionRepository _employeePositionRepository;

        public EmployeePositionService(IEmployeePositionRepository employeePositionRepository)
        {
            _employeePositionRepository = employeePositionRepository;
        }

        public EmployeePosition AddEmployeePosition(EmployeePosition employeePosition)
        {
            return _employeePositionRepository.AddEmployeePosition(employeePosition);
        }

        public IEnumerable<EmployeePosition> GetAllEmployeePosition()
        {
           return _employeePositionRepository.GetAllEmployeePosition();
        }

        public EmployeePosition GetEmployeePositionById(Guid id)
        {
            return _employeePositionRepository.GetEmployeePositionById(id);
        }

        public void RemoveEmployeePosition(EmployeePosition employeePosition)
        {
            _employeePositionRepository.RemoveEmployeePosition(employeePosition);
        }

        public void UpdateEmployeePosition(EmployeePosition employeePosition)
        {
            _employeePositionRepository.UpdateEmployeePosition(employeePosition);
        }
    }
}
