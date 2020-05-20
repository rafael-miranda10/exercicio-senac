using Flunt.Notifications;
using Flunt.Validations;
using Senac.Domain.BaseEntity;
using System.Collections.Generic;
using System.Linq;

namespace Senac.Domain.Entities
{
    public class EmployeePosition : Entity
    {
        protected EmployeePosition() { }

        public EmployeePosition(string description, decimal salary, int referenceNumber)
        {
            Description = description;
            Salary = salary;
            ReferenceNumber = referenceNumber;
            Employees = new List<Employee>();

            Verifications(Description, Salary, ReferenceNumber);
        }

        public EmployeePosition(string description, decimal salary, int referenceNumber, List<Employee> employees)
        {
            Description = description;
            Salary = salary;
            ReferenceNumber = referenceNumber;
            Employees = employees;

            Verifications(Description, Salary, ReferenceNumber);
        }

        public string Description { get; private set; }
        public decimal Salary { get; private set; }
        public int ReferenceNumber { get; private set; }
        public ICollection<Employee> Employees { get; private set; }

        private void Verifications(string Description, decimal Salary, int ReferenceNumber)
        {
            AddNotifications(new Contract()
                   .Requires()
                    .HasMinLen(Description, 2, "EmployeePosition.Description", "O campo descrição deve ter no mínimo 2 caracteres")
                    .HasMaxLen(Description, 50, "EmployeePosition.Description", "O campo descrição deve ter no máximo 50 caracteres")
                    .IsGreaterThan(Salary, 0, "EmployeePosition.Salary", "O campo de salário deve ser maior que zero")
                    .IsGreaterThan(ReferenceNumber, 0, "EmployeePosition.Reference", "O campo de número de referencia deve ser maior que zero")
                   );
        }

        public bool ValidateEmployyeToPosition(Employee employee)
        {
            bool employeeStatus = true;

            var exists = Employees.SingleOrDefault(x => x.Document.Number == employee.Document.Number);
            if (exists != null)
            {
                AddNotification(new Notification("EmployeePosition.Employees", $"O funcionário {employee.Name.ToString()} já esta vinculado ao cargo de {Description}."));
                employeeStatus = false;
            }
            else if (employee.EmployeePositionId != null)
            {
                AddNotification(new Notification("EmployeePosition.Employees", $"O funcionário {employee.Name.ToString()} não pode pertencer a mais de um cargo."));
                employeeStatus = false;
            }

            return employeeStatus;

        }
    }

    
}
