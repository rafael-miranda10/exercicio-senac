using Senac.Domain.BaseEntity;
using Senac.Domain.ValueObjects;
using System.Collections.Generic;

namespace Senac.Domain.Entities
{
    public class Company : Entity
    {
        protected Company() { }

        public Company(Document document, Email email, Address address)
        {
            Email = email;
            Document = document;
            Address = address;
            Employees = new List<Employee>();

            AddNotifications(document, email, address);
        }

        public Company(Document document, Email email, Address address, List<Employee> employees)
        {
            Email = email;
            Address = address;
            Document = document;
            Employees = employees;

            AddNotifications(document, email, address);
        }

        public string CompanyName { get; private set; }
        public string FantasyName { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public ICollection<Employee> Employees {get; private set;}
    }
}
