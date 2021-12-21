using adventofcode_2021.Task42;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace adventofcode_2022.Tests
{
    public class Task42Tests
    {
        public Task42Tests()
        {
        }

        [Fact]
        public void Task41_RealExample_Correct()
        {
            Assert.Equal(444356092776315UL, Solution.Function(10UL, 1UL));
        }
    }
}
