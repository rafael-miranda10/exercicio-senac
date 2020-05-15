using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Senac.API.Models.Request;
using Senac.API.Models.Response;
using Senac.Application.Interfaces;
using Senac.Domain.Entities;
using System;
using System.Linq;

namespace Senac.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : MainController
    {
        private readonly IEmployeeAppService _employeeAppService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeAppService employeeAppService, IMapper mapper)
        {
            _mapper = mapper;
            _employeeAppService = employeeAppService;
        }

        [Route("addEmployee")]
        [HttpPost]
        public IActionResult AddEmployee(EmployeeRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {
                var employee = _mapper.Map<EmployeeRequest, Employee>(request);

                if (employee.Notifications.Any()) return CustomResponse(employee.Notifications);

                var result = _employeeAppService.AddEmployee(employee);
                var employeeResponse = _mapper.Map<Employee, EmployeeResponse>(result);

                if (employeeResponse.Valid) return CustomResponse(employeeResponse);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento("Ops! Algo não deu certo. Aguarde um instante e tente novamente, caso o erro persista entre em contato com o administrador do sistema.");
                return CustomExceptionResponse();
            }
            return CustomResponse();
        }
    }
}