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
    public class EmployeeController : ControllerBase
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
            var employee = _mapper.Map<EmployeeRequest, Employee>(request);

            if (!employee.Notifications.Any())
            {
                try
                {
                    var result = _employeeAppService.AddEmployee(employee);
                    var employeeResponse = _mapper.Map<Employee, EmployeeResponse>(result);
                    return Ok(employeeResponse);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                }
            }
            else
            {
                return BadRequest(new { errors = employee.Notifications });
            }
        }
    }
}