using System.Collections.Generic;

namespace Senac.API.Models.Request
{
    public class RegisterEmployeeRequest
    {
        protected RegisterEmployeeRequest() {}

        protected RegisterEmployeeRequest(int idCompany, List<int> employees)
        {
            IdCompany = idCompany;
            Employees = employees;
        }

        public int IdCompany { get; set; }
        public List<int> Employees { get; set; }
    }
}
