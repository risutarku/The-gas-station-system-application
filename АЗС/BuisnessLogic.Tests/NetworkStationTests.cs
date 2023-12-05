

using ÀÇÑ.BuisnessLogic;



namespace BuisnessLogic.Tests
{
    public class NetworkStationTests
    {
        [Fact]
        public void Get_fail_discount_amount0_size0()
        {
            List<Station> list = new List<Station>();
            Dictionary<int, int> discounts = new Dictionary<int, int>() { {0, 5}, {5, 10} };
            int amount = 0;
            int expected = 0;

            NetworkStation net = new NetworkStation(list, discounts);
            Discount actualDiscount = net.GetDiscountSize(amount);
            int actual = actualDiscount.DiscountSize;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Get_discount_amount1to5_size5()
        {
            List<Station> list = new List<Station>();
            Dictionary<int, int> discounts = new Dictionary<int, int>() { { 0, 5 }, { 5, 10 } };
            Random r = new Random();
            int amount = r.Next(1, 5);
            int expected = 5;

            NetworkStation net = new NetworkStation(list, discounts);
            Discount actualDiscount = net.GetDiscountSize(amount);
            int actual = actualDiscount.DiscountSize;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Get_discount_amount_more_than6_size10()
        {
            List<Station> list = new List<Station>();
            Dictionary<int, int> discounts = new Dictionary<int, int>() { { 0, 5 }, { 5, 10 } };
            Random r = new Random();
            int amount = r.Next(5, 100);
            int expected = 10;

            NetworkStation net = new NetworkStation(list, discounts);
            Discount actualDiscount = net.GetDiscountSize(amount);
            int actual = actualDiscount.DiscountSize;

            Assert.Equal(expected, actual);
        }
    }
}