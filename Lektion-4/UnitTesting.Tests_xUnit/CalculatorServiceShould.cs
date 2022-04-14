using System.Collections.Generic;
using UnitTesting.Services;
using Xunit;

namespace UnitTesting.Tests_xUnit
{
    public class CalculatorServiceShould
    {
        [Fact]
        public void Add_OneNumber_To_Total()
        {
            // Arrange
            CalculatorService sut = new CalculatorService();
            sut.Total = 0;

            // Act
            sut.Add(1);

            // Assert
            Assert.Equal(1, sut.Total);
        }


        [Theory]
        [InlineData(0.1, 0.1, 0.1, 0.3)]
        [InlineData(1, 1.5, 2, 4.5)]
        [InlineData(10, 20, 30, 60)]
        public void Add_ThreeNumbers_To_Total(decimal value1, decimal value2, decimal value3, decimal expected)
        {
            // Arrange
            CalculatorService sut = new CalculatorService();
            sut.Total = 0;

            // Act
            sut.Add(value1);
            sut.Add(value2);
            sut.Add(value3);

            // Assert
            Assert.Equal(expected, sut.Total);
        }


        // Test Data
        private static IEnumerable<object[]> testValues()
        {
            yield return new object[] { 10, new decimal[] { 5, 5 }};
            yield return new object[] { 0.3m, new decimal[] { 0.1m, 0.1m, 0.1m } };
            yield return new object[] { 9, new decimal[] { 1, 1, 1, 2, 2, 2 } };
        }

        [Theory]
        [MemberData(nameof(testValues))]
        public void Add_MultipleNumbers_To_Total(decimal expected, params decimal[] values)
        {
            // Arrange
            CalculatorService sut = new CalculatorService();
            sut.Total = 0;

            // Act
            foreach(var value in values)
                sut.Add(value);

            // Assert
            Assert.Equal(expected, sut.Total);
        }

    }
}