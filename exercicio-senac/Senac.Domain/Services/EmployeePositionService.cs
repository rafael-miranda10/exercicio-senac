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

        public void AddEmployeePosition(Entities.EmployeePosition employeePosition)
        {
            _employeePositionRepository.AddEmployeePosition(employeePosition);
        }

        public IEnumerable<Entities.EmployeePosition> GetAllEmployeePosition()
        {
           return _employeePositionRepository.GetAllEmployeePosition();
        }

        public Entities.EmployeePosition GetEmployeePositionById(Guid id)
        {
            return _employeePositionRepository.GetEmployeePositionById(id);
        }

        public void RemoveEmployeePosition(Entities.EmployeePosition employeePosition)
        {
            _employeePositionRepository.RemoveEmployeePosition(employeePosition);
        }

        public void UpdateEmployeePosition(Entities.EmployeePosition employeePosition)
        {
            _employeePositionRepository.UpdateEmployeePosition(employeePosition);
        }
    }
}
