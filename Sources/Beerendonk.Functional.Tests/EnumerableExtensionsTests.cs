using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Beerendonk.Functional.Tests
{
    [TestClass]
    public class EnumerableExtensionsTests
    {
        [TestMethod]
        public void CycleTest()
        {
            // Arrange
            var numbers = new[] { 3, 5, 8 };

            var cycles = 5;
            IEnumerable<int> expected = numbers;
            for (int i = 1; i < cycles; i++)
            {
                expected = expected.Concat(numbers);
            }

            // Act
            var actual = EnumerableExtensions.Cycle(numbers).Take(cycles * numbers.Length);

            // Assert
            actual.Should().Equal(expected);
        }
    }
}
