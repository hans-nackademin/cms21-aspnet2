using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting.Services;

namespace UnitTesting.Tests_MSTest
{
    [TestClass]
    public class CalculatorServiceShould
    {
        

        [TestMethod]
        public void Add_OneNumber_To_Total()
        {
            // Arrange
            CalculatorService sut = new CalculatorService();
            sut.Total = 0m;

            // Act
            sut.Add(0.1m);

            // Assert
            Assert.AreEqual(0.1m, sut.Total);
        }

        [TestMethod]
        public void Add_ThreeNumbers_To_Total()
        {
            // Arrange
            CalculatorService sut = new CalculatorService();
            sut.Total = 0m;

            // Act
            sut.Add(0.1m);
            sut.Add(0.1m);
            sut.Add(0.1m);

            // Assert
            Assert.AreEqual(0.3m, sut.Total);
        }
    }
}