﻿using AutoMapper;
using Senac.API.Models.Request;
using Senac.API.Models.Response;
using Senac.API.Models.ValueObjects;
using Senac.Domain.Entities;
using Senac.Domain.ValueObjects;
using System;

namespace Senac.API.Mapper
{
    public class SenacMappingProfile : Profile
    {
        public SenacMappingProfile()
        {
            DomainToResponse();
            RequestToDomain();
        }

        private void DomainToResponse()
        {
            CreateMap<Name, NameResponse>();
            CreateMap<Email, EmailResponse>();
            CreateMap<Address, AddressResponse>();
            CreateMap<Document, DocumentResponse>();
            CreateMap<Employee, EmployeeResponse>();
            CreateMap<Company, CompanyResponse>();
            CreateMap<EmployeePosition, EmployeePositionResponse>();
        }

        private void RequestToDomain()
        {
            CreateMap<NameRequest, Name>();
            CreateMap<EmailRequest, Email>();
            CreateMap<AddressRequest, Address>()
                .ForMember(d => d.State, m => m.MapFrom(s => s.State.ToString().ToUpper()));
            CreateMap<DocumentRequest, Document>();
            CreateMap<EmployeeRequest, Employee>();
            CreateMap<CompanyRequest, Company>();
            CreateMap<EmployeePositionRequest, EmployeePosition>();
        }
    }
}
