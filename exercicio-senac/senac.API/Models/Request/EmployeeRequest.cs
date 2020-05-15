using Senac.API.Models.ValueObjects;

namespace Senac.API.Models.Request
{
    public class EmployeeRequest
    {
        protected EmployeeRequest() { }

        public EmployeeRequest(NameUI name, DocumentUI document, EmailUI email, AddressUI address)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
        }
        public NameUI Name { get;  set; }
        public DocumentUI Document { get;  set; }
        public EmailUI Email { get;  set; }
        public AddressUI Address { get;  set; }
    }
}
