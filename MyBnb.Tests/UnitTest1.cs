using System;
using Xunit;

namespace MyBnb.Tests
{
    public class UnitTest1
    {
        [Fact]
        void TestAdd() => Assert.Equal(
        	expected: 3, 
        	actual: Program.Add(1, 2));
    }
}
