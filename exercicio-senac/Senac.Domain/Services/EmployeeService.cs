using Senac.Domain.Entities;
using Senac.Domain.Interfaces.Repositories;
using Senac.Domain.Interfaces.Services;
using Senac.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Senac.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee AddEmployee(Employee employee)
        {
           return _employeeRepository.AddEmployee(employee);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeRepository.GetAllEmployee();
        }

        public IEnumerable<Employee> GetAllEmployeeWithoutCompany()
        {
            return _employeeRepository.GetAllEmployeeWithoutCompany();
        }

        public IEnumerable<Employee> GetAllEmployeeWithoutPosition(int idCompany)
        {
            return _employeeRepository.GetAllEmployeeWithoutPosition(idCompany);
        }

        public Employee GetEmployeeByDocument(Document document)
        {
            return _employeeRepository.GetEmployeeByDocument(document);
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }

        public void RemoveEmployee(Employee employee)
        {
            _employeeRepository.RemoveEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.UpdateEmployee(employee);
        }
    }
}
