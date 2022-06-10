using adventofcode_2021.Task41;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task41Tests
    {
        public Task41Tests()
        {
        }

        [Fact]
        public void Task41_RealExample_Correct()
        {
            Assert.Equal(739785, Solution.Function(4, 8));
        }
    }
}
