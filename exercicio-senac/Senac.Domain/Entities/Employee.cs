using Senac.Domain.BaseEntity;
using Senac.Domain.ValueObjects;
using System;

namespace Senac.Domain.Entities
{
    public class Employee : Entity
    {
        protected Employee() { }

        public Employee(int id, Name name, Document document, Email email, Address address, string registerCode)
        {
            Id = id;
            Name = name;
            Email = email;
            Address = address;
            Document = document;
            RegisterCode = registerCode;

            AddNotifications(name, document, email, address);
        }

        public Employee(int id, Name name, Document document, Email email, Address address,
                       string registerCode, int idCompany, Company company)
        {
            Id = id;
            Name = name;
            Email = email;
            Company = company;
            Address = address;
            Document = document;
            CompanyId = idCompany;
            RegisterCode = registerCode;

            AddNotifications(name, document, email, address);
        }

        public Employee(int id, Name name, Document document, Email email, Address address,
                      string registerCode, int idCompany, Company company, int positionId,
                      EmployeePosition employeePosition)
        {
            Id = id;
            Name = name;
            Email = email;
            Company = company;
            Address = address;
            Document = document;
            CompanyId = idCompany;
            RegisterCode = registerCode;
            EmployeePositionId = positionId;
            EmployeePosition = employeePosition;

            AddNotifications(name, document, email, address);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public string RegisterCode { get; private set; }
        public int? CompanyId { get; private set; }
        public virtual Company Company { get; private set; }
        public int? EmployeePositionId { get; private set; }
        public virtual EmployeePosition EmployeePosition { get; private set; }

        public void GenerateRegisterCode()
        {
            RegisterCode = Guid.NewGuid().ToString().Substring(0, 8);
        }

    }
}
