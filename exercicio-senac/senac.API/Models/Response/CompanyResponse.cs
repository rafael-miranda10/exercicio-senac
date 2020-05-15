using Flunt.Notifications;
using Senac.API.Models.ValueObjects;
using System;

namespace Senac.API.Models.Response
{
    public class CompanyResponse : Notifiable
    {
        protected CompanyResponse() { }

        public CompanyResponse(Guid id, DocumentUI document, EmailUI email,
                               AddressUI address, string companyName, string fantasyName)
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
        public DocumentUI Document { get; set; }
        public EmailUI Email { get; set; }
        public AddressUI Address { get; set; }
    }
}
