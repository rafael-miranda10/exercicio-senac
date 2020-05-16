using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Senac.API.Models;
using Senac.API.Models.Request;
using Senac.API.Models.Response;
using Senac.API.Models.ValueObjects;
using Senac.Application.Interfaces;
using Senac.Domain.Entities;
using Senac.Domain.ValueObjects;
using System;
using System.Collections.Generic;
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

        [Route("Create")]
        [HttpPost]
        public ActionResult AddEmployee(EmployeeRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {
                var employee = _mapper.Map<EmployeeRequest, Employee>(request);

                if (employee.Notifications.Any()) return CustomResponse(employee.Notifications);

                var result = _employeeAppService.AddEmployee(employee);
                var employeeResponse = _mapper.Map<Employee, EmployeeResponse>(result);
                return CustomResponse(employeeResponse);
            }
            catch (Exception ex)
            {
                MessageException();
                return CustomExceptionResponse();
            }
        }

        [Route("Update")]
        [HttpPut]
        public ActionResult UpdateEmployee(EmployeeRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {
                var employee = _mapper.Map<EmployeeRequest, Employee>(request);
                if (employee.Notifications.Any()) return CustomResponse(employee.Notifications);
                _employeeAppService.UpdateEmployee(employee);
                return CustomResponse(employee);
            }
            catch (Exception ex)
            {
                MessageException();
                return CustomExceptionResponse();
            }
        }

        [Route("Remove")]
        [HttpDelete]
        public ActionResult RemoveEmployee(Guid id)
        {
            if (id == Guid.Empty)
            {
                AdicionarErroProcessamento("O id do funcionário deve ser válido.");
                return CustomResponse();
            }

            try
            {
                var employee = _employeeAppService.GetEmployeeById(id);
                if (employee == null)
                {
                    AdicionarErroProcessamento("Não foi possível localizar o funcionário pelo id informado.");
                    return CustomResponse();
                }

                _employeeAppService.RemoveEmployee(employee);
                return CustomResponse();
            }
            catch (Exception ex)
            {
                MessageException();
                return CustomExceptionResponse();
            }
        }

        [Route("GetAll")]
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeResponse>> GetAllEmployee()
        {
            try
            {
                var result = _employeeAppService.GetAllEmployee().ToList();
                var listEmployeeResponse = _mapper.Map<List<Employee>, List<EmployeeResponse>>(result);
                return CustomResponse(listEmployeeResponse);
            }
            catch (Exception ex)
            {
                MessageException();
                return CustomExceptionResponse();
            }
        }

        [Route("GetByDocument")]
        [HttpGet]
        public ActionResult<EmployeeResponse> GetEmployeeByDocument(string number)
        {
            try
            {
                var employeeDocument = _mapper.Map<DocumentUI, Document>(new DocumentUI(number, (int)DocumentEnumUI.CPF));
                if (employeeDocument.Notifications.Any()) return CustomResponse(employeeDocument.Notifications);

                var result = _employeeAppService.GetEmployeeByDocument(employeeDocument);
                var listEmployeeResponse = _mapper.Map<Employee, EmployeeResponse>(result);
                return CustomResponse(listEmployeeResponse);
            }
            catch (Exception ex)
            {
                MessageException();
                return CustomExceptionResponse();
            }
        }

        [Route("GetById")]
        [HttpGet]
        public ActionResult<EmployeeResponse> GetEmployeeById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    AdicionarErroProcessamento("O id do funcionário deve ser válido.");
                    return CustomResponse();
                }

                var result = _employeeAppService.GetEmployeeById(id);
                if (result == null) return CustomResponse();

                var listEmployeeResponse = _mapper.Map<Employee, EmployeeResponse>(result);
                return CustomResponse(listEmployeeResponse);
            }
            catch (Exception ex)
            {
                MessageException();
                return CustomExceptionResponse();
            }
        }




    }
}