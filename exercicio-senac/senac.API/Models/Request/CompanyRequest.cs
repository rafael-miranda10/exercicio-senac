using Senac.API.Models.ValueObjects;
using System.Collections.Generic;

namespace Senac.API.Models.Request
{
    public class CompanyRequest
    {
        protected CompanyRequest() { }

        public CompanyRequest(DocumentRequest document, EmailRequest email,
                              AddressRequest address, string companyName, string fantasyName)
        {
            Email = email;
            Address = address;
            Document = document;
            FantasyName = fantasyName;
            CompanyName = companyName;
        }

        public int? Id { get; set; }
        public string CompanyName { get; set; }
        public string FantasyName { get; set; }
        public DocumentRequest Document { get; set; }
        public EmailRequest Email { get; set; }
        public AddressRequest Address { get; set; }
    }
}
