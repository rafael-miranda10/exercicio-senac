using Senac.API.Models.ValueObjects;
using System.Collections.Generic;

namespace Senac.API.Models.Response
{
    public class CompanyResponse 
    {
        protected CompanyResponse() { }

        public CompanyResponse(int id, DocumentResponse document, EmailResponse email,
                               AddressResponse address, string companyName, string fantasyName,
                               List<EmployeeResponse> employees)
        {
            Id = id;
            Email = email;
            Address = address;
            Document = document;
            Employees = employees;
            FantasyName = fantasyName;
            CompanyName = companyName;
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string FantasyName { get; set; }
        public DocumentResponse Document { get; set; }
        public EmailResponse Email { get; set; }
        public AddressResponse Address { get; set; }
        public ICollection<EmployeeResponse> Employees { get; set; }
    }
}
