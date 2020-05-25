using Xunit;

namespace Senac.Domain.Tests
{
    public class EmployeePositionTests
    {
        private FakeBuilder _fake;

        public EmployeePositionTests()
        {
            _fake = new FakeBuilder();
        }

        [Fact]
        public void Should_Return_False()
        {
            var employeePosition = _fake.GetEmployeePositionFake();
            var employee = _fake.GetEmployeeFake();
            var result = employeePosition.ValidateEmployyeToPosition(employee);
            Assert.False(result);
        }

        [Theory]
        [InlineData("38402480004", 2)]
        [InlineData("83952336041", 3)]
        [InlineData("51198890002", 4)]
        public void Should_Return_True(string cpf, int id)
        {
            var employeePosition = _fake.GetEmployeePositionFake();
            var employee = _fake.GetEmployeeFake_With_Params(cpf, id);
            var result = employeePosition.ValidateEmployyeToPosition(employee);
            Assert.True(result);
        }
    }
}
