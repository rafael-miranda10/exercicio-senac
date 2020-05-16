using Senac.API.Models.ValueObjects;

namespace Senac.API.Models.Request
{
    public class CompanyRequest
    {
        protected CompanyRequest() { }

        public CompanyRequest(DocumentRequest document, EmailRequest email, AddressRequest address)
        {
            Document = document;
            Email = email;
            Address = address;
        }

        public int? Id { get; set; }
        public string CompanyName { get; set; }
        public string FantasyName { get; set; }
        public DocumentRequest Document { get; set; }
        public EmailRequest Email { get; set; }
        public AddressRequest Address { get; set; }
    }
}
