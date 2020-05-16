using Senac.API.Models.ValueObjects;
using System;

namespace Senac.API.Models.Request
{
    public class EmployeeRequest
    {
        protected EmployeeRequest() { }

        public EmployeeRequest(NameRequest name, DocumentRequest document, EmailRequest email, AddressRequest address)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
        }
        public Guid Id { get; set; }
        public NameRequest Name { get;  set; }
        public DocumentRequest Document { get;  set; }
        public EmailRequest Email { get;  set; }
        public AddressRequest Address { get;  set; }
       // public string RegisterCode { get; set; }
    }
}
