using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senac.API.Models.Request
{
    public class EmployeePositionRequest
    {
        protected EmployeePositionRequest() { }

        public EmployeePositionRequest(string description, decimal salary, int referenceNumber)
        {
            Description = description;
            Salary = salary;
            ReferenceNumber = referenceNumber;
        }

        public int? Id { get; set; }
        public string Description { get; private set; }
        public decimal Salary { get; private set; }
        public int ReferenceNumber { get; private set; }
    }
}
