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
        [InlineData("38402480004")]
        [InlineData("83952336041")]
        [InlineData("51198890002")]
        public void Should_Return_True(string cpf)
        {
            var employeePosition = _fake.GetEmployeePositionFake();
            var employee = _fake.GetEmployeeFake_With_Params(cpf);
            var result = employeePosition.ValidateEmployyeToPosition(employee);
            Assert.True(result);
        }
    }
}
