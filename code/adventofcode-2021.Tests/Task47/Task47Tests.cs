using adventofcode_2021.Task47;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace adventofcode_2022.Tests
{
    public class Task47Tests
    {
        [Fact]
        public void Task47_RealExample_Correct()
        {
            Assert.Equal(3UL, Solution.Function());
        }
    }
}