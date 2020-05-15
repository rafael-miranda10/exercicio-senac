﻿using Flunt.Validations;
using Senac.Domain.BaseEntity;

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

            AddNotifications(new Contract()
                   .Requires()
                    .HasMinLen(Description, 2, "EmployeePosition.Description", "O campo descrição deve ter no mínimo 2 caracteres")
                    .HasMaxLen(Description, 50, "EmployeePosition.Description", "O campo descrição deve ter no máximo 50 caracteres")
                    .IsGreaterThan(salary, 0, "EmployeePosition.Salary", "O campo de salário deve ser maior que zero")
                    .IsGreaterThan(ReferenceNumber, 0, "EmployeePosition.Reference", "O campo de número de referencia deve ser maior que zero")
                   );
        }

        public string Description { get; private set; }
        public decimal Salary { get; private set; }
        public int ReferenceNumber { get; private set; }
    }

    
}
