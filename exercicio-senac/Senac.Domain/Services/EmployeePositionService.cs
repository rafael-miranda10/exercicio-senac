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

        public List<Notification> IncludeEmployeeOnPosition(List<Employee> employeesPositions)
        {
            bool hasError = false;
            List<Notification> _notifications = new List<Notification>();

            foreach (var _employee in employeesPositions)
            {
                var position = _employeePositionRepository.GetEmployeePositionById(_employee.EmployeePosition.Id);
                var employee = _employeeRepository.GetEmployeeById(_employee.Id);

                if(position == null)
                {
                    _notifications.Add(new Notification("EmployeePosition", $"Não foi possível encontrar o cargo com o id disableBtnAdd: {_employee.EmployeePosition.Id}."));
                    hasError = true;
                }

                if (employee == null)
                {
                    _notifications.Add(new Notification("EmployeePosition", $"Não foi possível encontrar o funcionário com o id informado: {_employee.Id}."));
                    hasError = true;
                }

                if (!hasError)
                {
                    if (position.ValidateEmployyeToPosition(employee))
                    {
                        _employeeRepository.UpdateEmployee(new Employee(employee.Id, employee.Name, employee.Document,
                            employee.Email, employee.Address, employee.RegisterCode, employee.CompanyId.Value,
                            employee.Company, position.Id, position));
                    }
                }

                hasError = false;
                
            }

            if (_notifications.Any())
                _notifications.Add(new Notification("EmployeePosition", $"Os funcionários não listados foram vinculados aos cargos com sucesso."));

            return _notifications;
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
