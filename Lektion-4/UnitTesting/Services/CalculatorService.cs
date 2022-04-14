namespace UnitTesting.Services
{
    public class CalculatorService
    {
        public decimal Total { get; set; }

        public void Add(decimal v)
        {
            Total += v;
        }
    }
}
