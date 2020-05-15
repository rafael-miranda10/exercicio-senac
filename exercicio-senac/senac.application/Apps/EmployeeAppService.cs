using Senac.Application.Interfaces;
using Senac.Domain.Entities;
using Senac.Domain.Interfaces.Services;
using Senac.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Senac.Application.Apps
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeAppService(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public void AddEmployee(Employee employee)
        {
            _employeeService.AddEmployee(employee);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeService.GetAllEmployee();
        }

        public Employee GetEmployeeByDocument(Document document)
        {
            return _employeeService.GetEmployeeByDocument(document);
        }

        public Employee GetEmployeeById(Guid id)
        {
            return _employeeService.GetEmployeeById(id);
        }

        public void RemoveEmployee(Employee employee)
        {
            _employeeService.RemoveEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeService.UpdateEmployee(employee);
        }
    }
}
