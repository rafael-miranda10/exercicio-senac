using Senac.API.Models.ValueObjects;

namespace Senac.API.Models.Request
{
    public class CompanyRequest
    {
        protected CompanyRequest() { }

        public CompanyRequest(DocumentUI document, EmailUI email, AddressUI address)
        {
            Document = document;
            Email = email;
            Address = address;
        }

        public string CompanyName { get; set; }
        public string FantasyName { get; set; }
        public DocumentUI Document { get; set; }
        public EmailUI Email { get; set; }
        public AddressUI Address { get; set; }
    }
}
