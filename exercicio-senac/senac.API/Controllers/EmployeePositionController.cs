using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Senac.API.Models.Request;
using Senac.API.Models.Response;
using Senac.Application.Interfaces;
using Senac.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senac.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePositionController : MainController
    {
        private readonly IEmployeePositionAppService _employeePositionAppService;
        private readonly IMapper _mapper;

        public EmployeePositionController(IEmployeePositionAppService employeePositionAppService, IMapper mapper)
        {
            _employeePositionAppService = employeePositionAppService;
            _mapper = mapper;
        }

        [Route("Create")]
        [HttpPost]
        public ActionResult AddEmployeePosition(EmployeePositionRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {
                var employeePosition = _mapper.Map<EmployeePositionRequest, EmployeePosition>(request);

                if (employeePosition.Notifications.Any()) return CustomResponse(employeePosition.Notifications);

                var result = _employeePositionAppService.AddEmployeePosition(employeePosition);
                var employeePositionResponse = _mapper.Map<EmployeePosition, EmployeePositionResponse>(result);
                return CustomResponse(employeePositionResponse);
            }
            catch (Exception ex)
            {
                MessageException();
                return CustomExceptionResponse();
            }
        }

        [Route("Include-Employee-Position")]
        [HttpPost]
        public ActionResult IncludeEmployeePosition(List<EmployeeRequest> request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {
                var employeesPositions = _mapper.Map<List<EmployeeRequest>, List<Employee>>(request);
                var positionResult = _employeePositionAppService.IncludeEmployeeOnPosition(employeesPositions);

               if (positionResult.Any()) return CustomResponse(positionResult);

                return CustomResponse();
            }
            catch (Exception ex)
            {
                MessageException();
                return CustomExceptionResponse();
            }
        }

        [Route("Update")]
        [HttpPut]
        public ActionResult UpdateEmployeePosition(EmployeePositionRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {
                var employeePosition = _mapper.Map<EmployeePositionRequest, EmployeePosition>(request);
                if (employeePosition.Notifications.Any()) return CustomResponse(employeePosition.Notifications);
                _employeePositionAppService.UpdateEmployeePosition(employeePosition);

                var employeePositionResponse = _mapper.Map<EmployeePosition, EmployeePositionResponse>(employeePosition);
                return CustomResponse(employeePositionResponse);
            }
            catch (Exception ex)
            {
                MessageException();
                return CustomExceptionResponse();
            }
        }

        [Route("Remove")]
        [HttpDelete]
        public ActionResult RemoveEmployeePosition(int id)
        {
            try
            {
                var employeePosition = _employeePositionAppService.GetEmployeePositionById(id);
                if (employeePosition == null)
                {
                    AdicionarErroProcessamento("Não foi possível localizar o cargo pelo id informado.");
                    return CustomResponse();
                }

                _employeePositionAppService.RemoveEmployeePosition(employeePosition);
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
        public ActionResult<IEnumerable<EmployeeResponse>> GetAllEmployeePosition()
        {
            try
            {
                var result = _employeePositionAppService.GetAllEmployeePosition().ToList();
                var listEmployeePositionResponse = _mapper.Map<List<EmployeePosition>, List<EmployeePositionResponse>>(result);
                return CustomResponse(listEmployeePositionResponse);
            }
            catch (Exception ex)
            {
                MessageException();
                return CustomExceptionResponse();
            }
        }

        [Route("GetById")]
        [HttpGet]
        public ActionResult<EmployeePositionResponse> GetEmployeePositionById(int id)
        {
            try
            {
                var result = _employeePositionAppService.GetEmployeePositionById(id);
                if (result == null)
                {
                    AdicionarErroProcessamento("Não foi possível localizar o cargo pelo id informado.");
                    return CustomResponse();
                }

                var listEmployeePositionResponse = _mapper.Map<EmployeePosition, EmployeePositionResponse>(result);
                return CustomResponse(listEmployeePositionResponse);
            }
            catch (Exception ex)
            {
                MessageException();
                return CustomExceptionResponse();
            }
        }

        [Route("GetPosition-Employees")]
        [HttpGet]
        public ActionResult<CompanyResponse> GetPositionEmployees(int idPosition)
        {
            try
            {
                var result = _employeePositionAppService.GetEmployeePositionWithEmployees(idPosition);
                var positionResponse = _mapper.Map<EmployeePosition, EmployeePositionResponse>(result);
                return CustomResponse(positionResponse);
            }
            catch (Exception ex)
            {
                MessageException();
                return CustomExceptionResponse();
            }
        }

    }
}