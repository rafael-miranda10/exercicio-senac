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

        public Employee AddEmployee(Employee employee)
        {
           return _employeeService.AddEmployee(employee);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeService.GetAllEmployee();
        }

        public Employee GetEmployeeByDocument(Document document)
        {
            return _employeeService.GetEmployeeByDocument(document);
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeService.GetEmployeeById(id);
        }

        public void RemoveEmployee(Employee employee)
        {
            _employeeService.RemoveEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            var RegisterCode = GetEmployeeById(employee.Id).RegisterCode;
            var newEmployee = new Employee(employee.Id, employee.Name, employee.Document, employee.Email, employee.Address, RegisterCode);
            _employeeService.UpdateEmployee(newEmployee);
        }
    }
}
