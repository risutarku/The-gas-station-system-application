using АЗС.BuisnessLogic;

namespace BuisnessLogic.Tests
{
    public class OrderTests
    {
        [Fact]
        public void cheque_string_format_test()
        {
            string[] testNameAddress = { "Лукойл", "Ватутина, 7" };
            List<string> testGasList = new List<string>() { "АИ-92", "АИ-100", "АИ-95" };
            CurrentFuel testFuel = new CurrentFuel("АИ-92");
            Dictionary<string, int> testGasPrice = new Dictionary<string, int>()
            {
                { "АИ-92", 50 },
                { "АИ-95", 52 },
                { "АИ-100", 65 }
            };
            Dictionary<string, int> testGasReserve = new Dictionary<string, int>()
            {
                { "АИ-92", 234 },
                { "АИ-95", 656 },
                { "АИ-100", 170 }
            };
            Station testStation = new Station(testNameAddress, testGasList, testGasPrice, testGasReserve);
            Discount testDiscount = new Discount(15);
            Order testOrder = new Order(testStation, testFuel, 100, testDiscount);
            Cheque expected = new Cheque($"Ваш заказ\n" +
                $"АЗС: Лукойл, ул. Ватутина, 7\n" +
                $"АИ-92   50р X 100л = 5000р\n" +
                $"Скидка составила: 750р (15%)\n" +
                $"Итого: 4250р");

            var actual = testOrder.CreateCheque();

            Assert.Equal(expected.ChequeString, actual.ChequeString);
        }
    }
}