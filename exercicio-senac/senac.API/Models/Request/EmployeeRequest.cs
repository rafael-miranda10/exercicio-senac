using Senac.API.Models.ValueObjects;

namespace Senac.API.Models.Request
{
    public class EmployeeRequest
    {
        protected EmployeeRequest() { }

        public EmployeeRequest(NameRequest name, DocumentRequest document, EmailRequest email, 
                              AddressRequest address, EmployeePositionRequest employeePosition)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            EmployeePosition = employeePosition;

        }
        public int? Id { get; set; }
        public NameRequest Name { get;  set; }
        public DocumentRequest Document { get;  set; }
        public EmailRequest Email { get;  set; }
        public AddressRequest Address { get;  set; }
        public string RegisterCode { get; set; }
        public EmployeePositionRequest EmployeePosition { get; set; }
       
    }
}
