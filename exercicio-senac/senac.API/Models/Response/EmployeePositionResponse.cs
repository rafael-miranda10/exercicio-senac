using Flunt.Notifications;
using System;

namespace Senac.API.Models.Response
{
    public class EmployeePositionResponse 
    {
        protected EmployeePositionResponse() { }

        public EmployeePositionResponse(Guid id, string description, decimal salary, int referenceNumber)
        {
            Description = description;
            Salary = salary;
            ReferenceNumber = referenceNumber;
        }

        public Guid Id { get; set; }
        public string Description { get; private set; }
        public decimal Salary { get; private set; }
        public int ReferenceNumber { get; private set; }
    }
}
