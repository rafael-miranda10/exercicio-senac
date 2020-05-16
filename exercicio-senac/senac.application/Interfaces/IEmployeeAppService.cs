using Senac.Domain.Entities;
using Senac.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Senac.Application.Interfaces
{
    public interface IEmployeeAppService
    {
        Employee AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void RemoveEmployee(Employee employee);
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployeeByDocument(Document document);
        Employee GetEmployeeById(int id);
    }
}
