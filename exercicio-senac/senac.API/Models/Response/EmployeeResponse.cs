using Flunt.Notifications;
using Senac.API.Models.ValueObjects;
using System;

namespace Senac.API.Models.Response
{
    public class EmployeeResponse 
    {
        protected EmployeeResponse() { }

        public EmployeeResponse(int id ,NameResponse name, DocumentResponse document, EmailResponse email, AddressResponse address, string registerCode)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            Id = id;
            RegisterCode = registerCode;
        }
        public int Id { get;  set; }
        public NameResponse Name { get;  set; }
        public DocumentResponse Document { get;  set; }
        public EmailResponse Email { get;  set; }
        public AddressResponse Address { get;  set; }
        public string RegisterCode { get;  set; }
    }
}
