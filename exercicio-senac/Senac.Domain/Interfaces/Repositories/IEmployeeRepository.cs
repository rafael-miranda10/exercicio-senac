using Senac.Domain.Entities;
using Senac.Domain.ValueObjects;
using System.Collections.Generic;
using System;

namespace Senac.Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void RemoveEmployee(Employee employee);
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployeeByDocument(Document document);
        Employee GetEmployeeById(Guid id);
    }
}
