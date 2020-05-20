using Senac.API.Models.ValueObjects;

namespace Senac.API.Models.Response
{
    public class EmployeeResponse 
    {
        protected EmployeeResponse() { }

        public EmployeeResponse(int id ,NameResponse name, DocumentResponse document, EmailResponse email, 
                               AddressResponse address, string registerCode, CompanyResponse company,
                               EmployeePositionResponse employeePositionResponse)
        {
            Id = id;
            Name = name;
            Email = email;
            Company = company;
            Address = address;
            Document = document;
            RegisterCode = registerCode;
            EmployeePositionResponse = employeePositionResponse;
        }
        public int Id { get;  set; }
        public NameResponse Name { get;  set; }
        public DocumentResponse Document { get;  set; }
        public EmailResponse Email { get;  set; }
        public AddressResponse Address { get;  set; }
        public string RegisterCode { get;  set; }
        public CompanyResponse Company { get; set; }
        public EmployeePositionResponse EmployeePositionResponse { get; set; }
    }
}
