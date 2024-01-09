using ���.BuisnessLogic;

namespace BuisnessLogic.Tests
{
    public class OrderTests
    {
        [Fact]
        public void cheque_string_format_test()
        {
            string[] testNameAddress = { "������", "��������, 7" };
            List<string> testGasList = new List<string>() { "��-92", "��-100", "��-95" };
            CurrentFuel testFuel = new CurrentFuel("��-92");
            Dictionary<string, int> testGasPrice = new Dictionary<string, int>()
            {
                { "��-92", 50 },
                { "��-95", 52 },
                { "��-100", 65 }
            };
            Dictionary<string, int> testGasReserve = new Dictionary<string, int>()
            {
                { "��-92", 234 },
                { "��-95", 656 },
                { "��-100", 170 }
            };
            Station testStation = new Station(testNameAddress, testGasList, testGasPrice, testGasReserve);
            Discount testDiscount = new Discount(15);
            Order testOrder = new Order(testStation, testFuel, 100, testDiscount);
            Cheque expected = new Cheque($"��� �����\n" +
                $"���: ������, ��. ��������, 7\n" +
                $"��-92   50� X 100� = 5000�\n" +
                $"������ ���������: 750� (15%)\n" +
                $"�����: 4250�");

            var actual = testOrder.CreateCheque();

            Assert.Equal(expected.ChequeString, actual.ChequeString);
        }
    }
}