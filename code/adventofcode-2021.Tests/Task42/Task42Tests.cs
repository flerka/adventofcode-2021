using adventofcode_2021.Task42;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task42Tests
    {
        public Task42Tests()
        {
        }

        [Fact]
        public void Task42_RealExample_Correct()
        {
            Assert.Equal(56852759190649UL, Solution.Function(10UL, 1UL));
        }
    }
}
