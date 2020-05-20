using Senac.Domain.Entities;
using Senac.Domain.Enum;
using Senac.Domain.ValueObjects;
using System.Collections.Generic;

namespace Senac.Domain.Tests
{
    public class FakeBuilder
    {
        //company
        private const string COMPANY_NAME = "Djalma Jorge Rações ME";
        private const string FANTASY_NAME = "Maringá Pet Clínica Veterinária";
        private const string DOCUMENT_CNPJ = "80034110000103";
        private const int TYPE_DOCUMENT = 2;
        private const string EMAIL = "maringa.pet@gmail.com";
        private const string ADDRESS_STREET = "Av Horacio Raccanelo";
        private const string ADDRESS_NUMBER = "5410";
        private const string ADDRESS_NEIGHBORHOOD = "CENTRO";
        private const string ADDRESS_CITY = "Maringá";
        private const string ADDRESS_STATE = "PR";
        private const int COMPANY_ID = 1;
        private List<Employee> Employees;
        private Company _company;
        private Document _companyDocument;
        private Email _companyEmail;
        private Address _companyAddress;

        //Employee
        private const string EMPLOYEE_NAME = "Rafael";
        private const string EMPLOYEE_LAST_NAME = "Miranda";
        private const string DOCUMENT_CPF = "48798899031";
        private const int DOCUMENT_TYPE = 1;
        private const string EMPLOYEE_EMAIL = "rafael.miranda@gmail.com";
        private const string E_ADDRESS_STREET = "Rua Nochete";
        private const string E_ADDRESS_NUMBER = "450";
        private const string E_ADDRESS_NEIGHBORHOOD = "JD Aviação";
        private const string E_ADDRESS_CITY = "Presidente Prudente";
        private const string E_ADDRESS_STATE = "SP";
        private const string E_ADDRESS_STATE_ERROR = "São Paulo";
        private const string EMPLOYEE_EMAIL_ERROR = "rafael.miranda";
        private const int EMPLOYEE_ID = 1;
        private Employee _employee;
        private Name _employeeName;
        private Document _employeeDocument;
        private Email _employeeEmail;
        private Address _employeeAddress;

        //employeePosition
        private const string EP_DESCRIPTION = "Médico Veterinário";
        private const decimal EP_SALARY = 4500;
        private const int EP_NUM_REFERENCE = 1;
        private EmployeePosition _employeePosition;



        public Company GetCompanyFake()
        {
            Employees = new List<Employee>();
            Employees.Add(GetEmployeeFake());
            //company
            _companyDocument = new Document(DOCUMENT_CNPJ, (DocumentEnum)TYPE_DOCUMENT);
            _companyEmail = new Email(EMAIL);
            _companyAddress = new Address(E_ADDRESS_STREET, ADDRESS_NUMBER, ADDRESS_NEIGHBORHOOD, ADDRESS_CITY, ADDRESS_STATE);
            _company = new Company(_companyDocument, _companyEmail, _companyAddress, COMPANY_NAME, FANTASY_NAME, Employees);
            return _company;
        }

        public Employee GetEmployeeFake()
        {
            _employeeName = new Name(EMPLOYEE_NAME, EMPLOYEE_LAST_NAME);
            _employeeDocument = new Document(DOCUMENT_CPF, (DocumentEnum)DOCUMENT_TYPE);
            _employeeEmail = new Email(EMPLOYEE_EMAIL);
            _employeeAddress = new Address(E_ADDRESS_STREET, E_ADDRESS_NUMBER, E_ADDRESS_NEIGHBORHOOD, E_ADDRESS_CITY, E_ADDRESS_STATE);
            _employee = new Employee(EMPLOYEE_ID, _employeeName, _employeeDocument, _employeeEmail, _employeeAddress, string.Empty);
            _employee.GenerateRegisterCode();
            return _employee;
        }
        public Employee GetEmployeeFake_With_Params(string cpf)
        {
            _employeeName = new Name(EMPLOYEE_NAME, EMPLOYEE_LAST_NAME);
            _employeeDocument = new Document(cpf, (DocumentEnum)DOCUMENT_TYPE);
            _employeeEmail = new Email(EMPLOYEE_EMAIL);
            _employeeAddress = new Address(E_ADDRESS_STREET, E_ADDRESS_NUMBER, E_ADDRESS_NEIGHBORHOOD, E_ADDRESS_CITY, E_ADDRESS_STATE);
            _employee = new Employee(EMPLOYEE_ID, _employeeName, _employeeDocument, _employeeEmail, _employeeAddress, string.Empty);
            _employee.GenerateRegisterCode();
            return _employee;
        }

        public Employee GetEmployeeError()
        {
            _employeeName = new Name(EMPLOYEE_NAME, EMPLOYEE_LAST_NAME);
            _employeeDocument = new Document(DOCUMENT_CPF, (DocumentEnum)DOCUMENT_TYPE);
            _employeeEmail = new Email(EMPLOYEE_EMAIL_ERROR);
            _employeeAddress = new Address(E_ADDRESS_STREET, E_ADDRESS_NUMBER, E_ADDRESS_NEIGHBORHOOD, E_ADDRESS_CITY, E_ADDRESS_STATE_ERROR);
            _employee = new Employee(EMPLOYEE_ID, _employeeName, _employeeDocument, _employeeEmail, _employeeAddress, string.Empty);
            _employee.GenerateRegisterCode();
            return _employee;
        }

        public EmployeePosition GetEmployeePositionFake()
        {
            Employees = new List<Employee>();
            Employees.Add(GetEmployeeFake());
            _employeePosition = new EmployeePosition(EP_DESCRIPTION,EP_SALARY,EP_NUM_REFERENCE,Employees);
            return _employeePosition;
        }
    }
}
