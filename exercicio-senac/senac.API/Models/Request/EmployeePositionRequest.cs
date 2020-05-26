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
        public string Description { get;  set; }
        public decimal? Salary { get;  set; }
        public int? ReferenceNumber { get;  set; }
    }
}
