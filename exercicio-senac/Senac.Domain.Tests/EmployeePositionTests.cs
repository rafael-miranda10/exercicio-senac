using System.Linq;
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

        [Fact]
        public void Should_Return_EmployeePosition_Invalid()
        {
            var employeePosition = _fake.GetEmployeePositionInvalid();
            Assert.False(employeePosition.Valid);
            Assert.Equal("O campo descrição deve ter no máximo 50 caracteres", employeePosition.Notifications.FirstOrDefault().Message);
        }

        [Fact]
        public void Should_Return_Error_Another_Exist()
        {
            var position = _fake.GetEmployeePositionFake();
            var employee = _fake.GetEmployeeFake();
            var result = position.ValidateEmployyeToPosition(employee);
            Assert.True(position.Invalid);
            Assert.Equal($"O funcionário {employee.Name.ToString()} já esta vinculado ao cargo de {position.Description}.",
                position.Notifications.FirstOrDefault().Message);
        }

        [Fact]
        public void Should_Return_Error_Another_Position()
        {
            var position = _fake.GetEmployeePositionFake();
            var employee = _fake.GetEmployeeWithPosition();
            var result = position.ValidateEmployyeToPosition(employee);
            Assert.True(position.Invalid);
            Assert.Equal($"O funcionário {employee.Name.ToString()} não pode pertencer a mais de um cargo.",
                position.Notifications.FirstOrDefault().Message);
        }
    }
}
