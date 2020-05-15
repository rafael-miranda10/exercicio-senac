using Senac.Domain.Entities;
using System.Collections.Generic;
using Senac.Domain.ValueObjects;
using System;

namespace Senac.Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void RemoveEmployee(Employee employee);
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployeeByDocument(Document document);
        Employee GetEmployeeById(Guid id);
    }
}
