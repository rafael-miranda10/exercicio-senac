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
    }
}
