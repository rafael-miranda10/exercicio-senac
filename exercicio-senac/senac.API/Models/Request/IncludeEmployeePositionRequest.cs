using System.Collections.Generic;

namespace Senac.API.Models.Request
{
    public class IncludeEmployeePositionRequest
    {
        protected IncludeEmployeePositionRequest() { }

        protected IncludeEmployeePositionRequest(int idPosition, List<int> employees)
        {
            IdPosition = idPosition;
            Employees = employees;
        }

        public int IdPosition { get; set; }
        public List<int> Employees { get; set; }
    }
}
