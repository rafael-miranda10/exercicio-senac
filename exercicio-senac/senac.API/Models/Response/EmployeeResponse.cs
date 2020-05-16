using Flunt.Notifications;
using Senac.API.Models.ValueObjects;
using System;

namespace Senac.API.Models.Response
{
    public class EmployeeResponse 
    {
        protected EmployeeResponse() { }

        public EmployeeResponse(Guid id ,NameUI name, DocumentUI document, EmailUI email, AddressUI address, string registerCode)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            Id = id;
            RegisterCode = registerCode;
        }
        public Guid Id { get;  set; }
        public NameUI Name { get;  set; }
        public DocumentUI Document { get;  set; }
        public EmailUI Email { get;  set; }
        public AddressUI Address { get;  set; }
        public string RegisterCode { get;  set; }
    }
}
