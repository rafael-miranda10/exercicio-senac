using Senac.Domain.Entities;
using System.Collections.Generic;
using Senac.Domain.ValueObjects;
using System;

namespace Senac.Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        Employee AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void RemoveEmployee(Employee employee);
        IEnumerable<Employee> GetAllEmployee();
        IEnumerable<Employee> GetAllEmployeeWithoutCompany();
        IEnumerable<Employee> GetAllEmployeeWithoutPosition(int idCompany);
        Employee GetEmployeeByDocument(Document document);
        Employee GetEmployeeById(int id);
    }
}
