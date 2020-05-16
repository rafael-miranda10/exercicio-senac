using Flunt.Notifications;
using Senac.API.Models.ValueObjects;
using System;

namespace Senac.API.Models.Response
{
    public class CompanyResponse 
    {
        protected CompanyResponse() { }

        public CompanyResponse(Guid id, DocumentResponse document, EmailResponse email,
                               AddressResponse address, string companyName, string fantasyName)
        {
            Id = id;
            Email = email;
            Address = address;
            Document = document;
            FantasyName = fantasyName;
            CompanyName = companyName;
        }

        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string FantasyName { get; set; }
        public DocumentResponse Document { get; set; }
        public EmailResponse Email { get; set; }
        public AddressResponse Address { get; set; }
    }
}
