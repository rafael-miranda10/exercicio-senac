using Xunit;

namespace Senac.Domain.Tests
{
    public class EmployeeTests
    {
        private FakeBuilder _fake;

        public EmployeeTests()
        {
            _fake = new FakeBuilder();
        }

        [Fact]
        public void Should_Return_Employee_Error()
        {
            var employee = _fake.GetEmployeeError();
            var qtdeError = employee.Notifications.Count;

            Assert.False(employee.Valid);
            Assert.Equal(2,qtdeError);
        }

    }
}
