using Flunt.Notifications;
using Flunt.Validations;
using Senac.Domain.BaseEntity;
using Senac.Domain.ValueObjects;
using System;

namespace Senac.Domain.Entities
{
    public class Employee : Entity
    {
        protected Employee() { }

        public Employee(Name name, Document document, Email email, Address address)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;

            AddNotifications(name, document, email, address);
        }
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public string RegisterCode { get; private set; }

        public void GenerateRegisterCode()
        {
            RegisterCode = Guid.NewGuid().ToString().Substring(0, 8);
        }
    }
}
