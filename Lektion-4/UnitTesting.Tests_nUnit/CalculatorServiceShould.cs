using NUnit.Framework;
using UnitTesting.Services;

namespace UnitTesting.Tests_nUnit
{
    public class Tests
    {
        private CalculatorService sut;

        [SetUp]
        public void Setup()
        {
            // Arrange
            sut = new CalculatorService();
            sut.Total = 0;
        }

        [Test]
        public void Add_OneNumber_To_Total()
        {
            // Act
            sut.Add(2);

            // Assert
            Assert.AreEqual(2, sut.Total);
        }


        [TestCase(0.1, 0.1, 0.1, 0.3)]
        [TestCase(1, 2, 3, 6)]
        [TestCase(10, 10, 10, 30)]
        public void Add_ThreeNumbers_To_Total(decimal value1, decimal value2,  decimal value3, decimal expected)
        {
            // Act
            sut.Add(value1);
            sut.Add(value2);
            sut.Add(value3);

            // Assert
            Assert.AreEqual(expected, sut.Total);
        }
    }
}