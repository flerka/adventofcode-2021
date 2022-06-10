using adventofcode_2021.Task45;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace adventofcode_2021.Tests
{
    public class Task45Tests
    {
        [Fact]
        public void Task45_RealExample_Correct()
        {
            Assert.Equal(48541, Solution.Function());
        }
    }
}