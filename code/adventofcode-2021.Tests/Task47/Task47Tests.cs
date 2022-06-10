using adventofcode_2021.Task47;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task47Tests
    {
        [Fact(Skip = "this test runs more then 1 minute")]
        public void Task47_RealExample_Correct()
        {
            Assert.Equal(3UL, Solution.Function());
        }
    }
}