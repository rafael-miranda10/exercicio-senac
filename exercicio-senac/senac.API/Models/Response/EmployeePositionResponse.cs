namespace Senac.API.Models.Response
{
    public class EmployeePositionResponse 
    {
        protected EmployeePositionResponse() { }

        public EmployeePositionResponse(int id, string description, decimal salary, int referenceNumber)
        {
            Id = id;
            Salary = salary;
            Description = description;
            ReferenceNumber = referenceNumber;
        }

        public int Id { get; set; }
        public string Description { get;  set; }
        public decimal Salary { get;  set; }
        public int ReferenceNumber { get;  set; }
    }
}
