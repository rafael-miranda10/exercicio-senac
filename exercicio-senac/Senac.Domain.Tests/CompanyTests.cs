using System.Linq;
using Xunit;

namespace Senac.Domain.Tests
{
    public class CompanyTests
    {

        private FakeBuilder _fake;

        public CompanyTests()
        {
            _fake = new FakeBuilder();
        }

        [Fact]
        public void Should_Return_False()
        {
            var company = _fake.GetCompanyFake();
            var employee = _fake.GetEmployeeFake();
            var result = company.ValidateEmployeeToCompany(employee);
            Assert.False(result);
        }

        [Theory]
        [InlineData("54712645091", 2)]
        [InlineData("83952336041", 3)]
        [InlineData("44545384099", 4)]
        public void Should_Return_True(string cpf, int id)
        {
            var company = _fake.GetCompanyFake();
            var employee = _fake.GetEmployeeFake_With_Params(cpf, id);
            var result = company.ValidateEmployeeToCompany(employee);
            Assert.True(result);
        }

        [Theory]
        [InlineData("48798899031", 1)]
        public void Should_Return_Error_Exists(string cpf, int id)
        {
            var company = _fake.GetCompanyFake();
            var employee = _fake.GetEmployeeFake_With_Params(cpf, id);
            var result = company.ValidateEmployeeToCompany(employee);
            Assert.True(company.Invalid);
            Assert.Equal($"O funcionário { employee.Name.ToString()} já existe na { company.FantasyName}.",
                company.Notifications.FirstOrDefault().Message);
        }

        [Fact]
        public void Should_Return_Error_Another_Company()
        {
            var company = _fake.GetCompanyFake();
            var employee = _fake.GetEmployeeWithCompany();
            var result = company.ValidateEmployeeToCompany(employee);
            Assert.True(company.Invalid);
            Assert.Equal($"O funcionário {employee.Name.ToString()} não pode pertencer a mais de uma empresa.",
                company.Notifications.FirstOrDefault().Message);
        }
    }
}
