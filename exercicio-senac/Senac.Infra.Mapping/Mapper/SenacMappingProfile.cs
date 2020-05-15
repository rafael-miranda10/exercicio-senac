using AutoMapper;
using Senac.API.Models.Response;
using Senac.API.Models.ValueObjects;
using Senac.Domain.Entities;
using Senac.Domain.ValueObjects;

namespace Senac.Infra.Mapping.Mapper
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
            CreateMap<Name, NameUI>();
            CreateMap<Email, EmailUI>();
            CreateMap<Address, AddressUI>();
            CreateMap<Document, DocumentUI>();
            CreateMap<Employee, EmployeeResponse>();
            CreateMap<Company, CompanyResponse>();
            CreateMap<EmployeePosition, EmployeePositionResponse>();
        }

        private void RequestToDomain()
        {
            CreateMap<NameUI, Name>();
            CreateMap<EmailUI, Email>();
            CreateMap<AddressUI, Address>();
            CreateMap<DocumentUI, Document>();
            CreateMap<EmployeeResponse, Employee>();
            CreateMap<CompanyResponse, Company>();
            CreateMap<EmployeePositionResponse, EmployeePosition>();
        }
    }
}
