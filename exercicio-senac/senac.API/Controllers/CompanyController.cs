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
    public class CompanyController : MainController
    {
        private readonly ICompanyAppService _companyAppService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyAppService companyAppService, IMapper mapper)
        {
            _mapper = mapper;
            _companyAppService = companyAppService;
        }

        [Route("Create")]
        [HttpPost]
        public ActionResult AddCompany(CompanyRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {
                var company = _mapper.Map<CompanyRequest, Company>(request);

                if (company.Notifications.Any()) return CustomResponse(company.Notifications);

                var result = _companyAppService.AddCompany(company);
                var employeeResponse = _mapper.Map<Company, CompanyResponse>(result);
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
        public ActionResult UpdateCompany(CompanyRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {
                var company = _mapper.Map<CompanyRequest, Company>(request);
                if (company.Notifications.Any()) return CustomResponse(company.Notifications);
                _companyAppService.UpdateCompany(company);

                var companyResponse = _mapper.Map<Company, CompanyResponse>(company);
                return CustomResponse(companyResponse);
            }
            catch (Exception ex)
            {
                MessageException();
                return CustomExceptionResponse();
            }
        }

        [Route("Remove")]
        [HttpDelete]
        public ActionResult RemoveCompany(int id)
        {
            try
            {
                var company = _companyAppService.GetCompanyById(id);
                if (company == null)
                {
                    AdicionarErroProcessamento("Não foi possível localizar a empresa pelo id informado.");
                    return CustomResponse();
                }

                _companyAppService.RemoveCompany(company);
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
        public ActionResult<IEnumerable<CompanyResponse>> GetAllCompany()
        {
            try
            {
                var result = _companyAppService.GetAllCompany().ToList();
                var listCompanyResponse = _mapper.Map<List<Company>, List<CompanyResponse>>(result);
                return CustomResponse(listCompanyResponse);
            }
            catch (Exception ex)
            {
                MessageException();
                return CustomExceptionResponse();
            }
        }

        [Route("GetByDocument")]
        [HttpGet]
        public ActionResult<CompanyResponse> GetCompanyByDocument(string number)
        {
            try
            {
                var companyDocument = _mapper.Map<DocumentRequest, Document>(new DocumentRequest(number, (int)DocumentEnumUI.CPF));
                if (companyDocument.Notifications.Any()) return CustomResponse(companyDocument.Notifications);

                var result = _companyAppService.GetCompanyByDocument(companyDocument);
                var listCompanyResponse = _mapper.Map<Company, CompanyResponse>(result);
                return CustomResponse(listCompanyResponse);
            }
            catch (Exception ex)
            {
                MessageException();
                return CustomExceptionResponse();
            }
        }

        [Route("GetById")]
        [HttpGet]
        public ActionResult<CompanyResponse> GetCompanyById(int id)
        {
            try
            {
                var result = _companyAppService.GetCompanyById(id);
                if (result == null) return CustomResponse();

                var listCompanyResponse = _mapper.Map<Company, CompanyResponse>(result);
                return CustomResponse(listCompanyResponse);
            }
            catch (Exception ex)
            {
                MessageException();
                return CustomExceptionResponse();
            }
        }

    }
}