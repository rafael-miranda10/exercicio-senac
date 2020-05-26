using System.Collections.Generic;

namespace Senac.API.Models.Request
{
    public class IncludeEmployeePositionRequest
    {
        protected IncludeEmployeePositionRequest() { }

        protected IncludeEmployeePositionRequest(int idPosition, int idEmployee)
        {
            IdPosition = idPosition;
            IdEmployee = idEmployee;
        }

        public int IdPosition { get; set; }
        public int IdEmployee { get; set; }
    }
}
