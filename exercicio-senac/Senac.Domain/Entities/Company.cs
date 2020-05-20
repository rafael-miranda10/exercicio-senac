using Flunt.Notifications;
using Senac.Domain.BaseEntity;
using Senac.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Senac.Domain.Entities
{
    public class Company : Entity
    {
        protected Company() { }

        public Company(Document document, Email email, Address address,
                       string companyName, string fantasyName)
        {
            Email = email;
            Address = address;
            Document = document;
            FantasyName = fantasyName;
            CompanyName = companyName;
            Employees = new List<Employee>();

            AddNotifications(document, email, address);
        }

        public Company(Document document, Email email, Address address,
                       string companyName, string fantasyName, List<Employee> employees)
        {
            Email = email;
            Address = address;
            Document = document;
            Employees = employees;
            FantasyName = fantasyName;
            CompanyName = companyName;

            AddNotifications(document, email, address);
        }

        public string CompanyName { get; private set; }
        public string FantasyName { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public ICollection<Employee> Employees { get; private set; }

        public bool ValidateEmployeeToCompany(Employee employee)
        {
            bool employeeStatus = true;

            var exists = Employees.SingleOrDefault(x => x.Document.Number == employee.Document.Number);
            if (exists != null)
            {
                AddNotification(new Notification("Company.Employees", $"O funcionário {employee.Name.ToString()} já existe na {FantasyName}."));
                employeeStatus = false;
            }
            else if (employee.CompanyId != null)
            {
                AddNotification(new Notification("Company.Employees", $"O funcionário {employee.Name.ToString()} não pode pertencer a mais de uma empresa."));
                employeeStatus = false;
            }

            return employeeStatus;
        }
    }
}
