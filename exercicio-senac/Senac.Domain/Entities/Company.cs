using Senac.Domain.BaseEntity;
using Senac.Domain.ValueObjects;

namespace Senac.Domain.Entities
{
    public class Company : Entity
    {
        protected Company(){}

        public Company(Document document, Email email, Address address)
        {
            Document = document;
            Email = email;
            Address = address;

            AddNotifications(document, email, address);
        }

        public string CompanyName { get; private set; }
        public string FantasyName { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
    }
}
