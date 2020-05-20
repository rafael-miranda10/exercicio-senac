using Flunt.Notifications;
using Senac.Domain.Entities;
using Senac.Domain.Interfaces.Repositories;
using Senac.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Senac.Domain.Services
{
    public class EmployeePositionService : IEmployeePositionService
    {
        private readonly IEmployeePositionRepository _employeePositionRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeePositionService(IEmployeePositionRepository employeePositionRepository,
            IEmployeeRepository employeeRepository)
        {
            _employeePositionRepository = employeePositionRepository;
            _employeeRepository = employeeRepository;
        }

        public EmployeePosition AddEmployeePosition(EmployeePosition employeePosition)
        {
            return _employeePositionRepository.AddEmployeePosition(employeePosition);
        }

        public IEnumerable<EmployeePosition> GetAllEmployeePosition()
        {
            return _employeePositionRepository.GetAllEmployeePosition();
        }

        public EmployeePosition GetEmployeePositionById(int id)
        {
            return _employeePositionRepository.GetEmployeePositionById(id);
        }

        public EmployeePosition GetEmployeePositionWithEmployees(int idPosition)
        {
            return _employeePositionRepository.GetEmployeePositionWithEmployees(idPosition);
        }

        public EmployeePosition IncludeEmployeeOnPosition(int idPosition, List<int> employees)
        {
            var position = _employeePositionRepository.GetEmployeePositionById(idPosition);
            if (position == null) return null;

            foreach (var idEmployee in employees)
            {
                var employee = _employeeRepository.GetEmployeeById(idEmployee);
                if (position.ValidateEmployyeToPosition(employee))
                {
                    _employeeRepository.UpdateEmployee(new Employee(employee.Id, employee.Name, employee.Document,
                        employee.Email, employee.Address, employee.RegisterCode, employee.CompanyId.Value,
                        employee.Company,position.Id, position));
                }
            }

            if (position.Notifications.Any())
                position.AddNotification(new Notification("EmployeePosition.Employees", $"Os funcionários não listados foram vinculados ao cargo de  {position.Description} com sucesso."));

            return position;
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
