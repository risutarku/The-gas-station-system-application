

using ���.BuisnessLogic;



namespace BuisnessLogic.Tests
{
    public class VerificationTests
    {
        [Fact]
        public void Check_correct_input_string_to_int() // �������� �� ������� ������ ������ � int
        {
            string testInput = "1";
            int expected = 1;

            int actual = Verification.CheckCorrectInput(testInput);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Check_correct_input_string01_to_int() // �������� �� ������� ������ ������ ������������ � ���� � int
        {
            string testInput = "01";
            int expected = 1;

            int actual = Verification.CheckCorrectInput(testInput);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Check_fail_input_string_to_int() // �������� �� ������� �������� ������ � int
        {
            string testInput = "f1";
            int expected = 0;

            int actual = Verification.CheckCorrectInput(testInput);

            Assert.Equal(expected, actual);
        }

       
        [Fact]
        public void Is_station_name_in_station_list()
        {
            string[] testNameAddress = { "������", "��������, 7" };
            List<string> testGasList = new List<string>() { "��-92", "��-100" , "��-95" };
            Dictionary<string, int> testGasPrice = new Dictionary<string, int>()
            {
                { "��-92", 50 },
                { "��-95", 52 },
                { "��-100", 65 }
            };
            Dictionary<string, int> testGasReserve= new Dictionary<string, int>()
            {
                { "��-92", 234 },
                { "��-95", 656 },
                { "��-100", 170 }
            };
            Station testStation = new Station(testNameAddress, testGasList, testGasPrice, testGasReserve);
            List<Station> testStationList = new List<Station>() { testStation };
            string testStationName = "������";

            var actual = Verification.IsStationNameInStationList(testStationList, testStationName);

            Assert.True(actual);
        }

        [Fact]
        public void Is_Not_station_name_in_station_list()
        {
            string[] testNameAddress = { "������", "��������, 7" };
            List<string> testGasList = new List<string>() { "��-92", "��-100", "��-95" };
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
            List<Station> testStationList = new List<Station>() { testStation };
            string testStationName = "��������";

            var actual = Verification.IsStationNameInStationList(testStationList, testStationName);

            Assert.False(actual);
        }


        [Fact]
        public void Find_station_name_in_station_list()
        {
            string[] testNameAddress1 = { "������", "��������, 7" };
            List<string> testGasList1 = new List<string>() { "��-92", "��-100", "��-95" };
            Dictionary<string, int> testGasPrice1 = new Dictionary<string, int>()
            {
                { "��-92", 50 },
                { "��-95", 52 },
                { "��-100", 65 }
            };
            Dictionary<string, int> testGasReserve1 = new Dictionary<string, int>()
            {
                { "��-92", 234 },
                { "��-95", 656 },
                { "��-100", 170 }
            };
            Station testStation1 = new Station(testNameAddress1, testGasList1, testGasPrice1, testGasReserve1);
            string[] testNameAddress2 = { "��������", "��������, 7" };
            List<string> testGasList2 = new List<string>() { "��-92", "��-100", "��-95" };
            Dictionary<string, int> testGasPrice2 = new Dictionary<string, int>()
            {
                { "��-92", 50 },
                { "��-95", 52 },
                { "��-100", 65 }
            };
            Dictionary<string, int> testGasReserve2 = new Dictionary<string, int>()
            {
                { "��-92", 234 },
                { "��-95", 656 },
                { "��-100", 170 }
            };
            Station testStation2 = new Station(testNameAddress2, testGasList2, testGasPrice2, testGasReserve2);
            List<Station> testStationList = new List<Station>() { testStation1, testStation2};
            string testStationName = "������";
            Station expected = testStation1;

            var actual = Verification.FindStationByStationName(testStationList, testStationName);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Not_find_station_name_in_station_list()
        {
            string[] testNameAddress1 = { "������", "��������, 7" };
            List<string> testGasList1 = new List<string>() { "��-92", "��-100", "��-95" };
            Dictionary<string, int> testGasPrice1 = new Dictionary<string, int>()
            {
                { "��-92", 50 },
                { "��-95", 52 },
                { "��-100", 65 }
            };
            Dictionary<string, int> testGasReserve1 = new Dictionary<string, int>()
            {
                { "��-92", 234 },
                { "��-95", 656 },
                { "��-100", 170 }
            };
            Station testStation1 = new Station(testNameAddress1, testGasList1, testGasPrice1, testGasReserve1);
            string[] testNameAddress2 = { "��������", "��������, 7" };
            List<string> testGasList2 = new List<string>() { "��-92", "��-100", "��-95" };
            Dictionary<string, int> testGasPrice2 = new Dictionary<string, int>()
            {
                { "��-92", 50 },
                { "��-95", 52 },
                { "��-100", 65 }
            };
            Dictionary<string, int> testGasReserve2 = new Dictionary<string, int>()
            {
                { "��-92", 234 },
                { "��-95", 656 },
                { "��-100", 170 }
            };
            Station testStation2 = new Station(testNameAddress2, testGasList2, testGasPrice2, testGasReserve2);
            List<Station> testStationList = new List<Station>() { testStation1, testStation2 };
            string testStationName = "�������";

            var actual = Verification.FindStationByStationName(testStationList, testStationName);

            Assert.Null(actual);
        }

        [Fact]
        public void Correct_fuel_type_on_station_and_correct_fuel_amount()
        {
            string[] testNameAddress1 = { "������", "��������, 7" };
            List<string> testGasList1 = new List<string>() { "��-92", "��-100", "��-95" };
            Dictionary<string, int> testGasPrice1 = new Dictionary<string, int>()
            {
                { "��-92", 50 },
                { "��-95", 52 },
                { "��-100", 65 }
            };
            Dictionary<string, int> testGasReserve1 = new Dictionary<string, int>()
            {
                { "��-92", 234 },
                { "��-95", 656 },
                { "��-100", 170 }
            };
            Station testStation1 = new Station(testNameAddress1, testGasList1, testGasPrice1, testGasReserve1);
            string testGasName = "��-92";
            int testFuelAmount = 34;

            bool actual = Verification.IsFuelAmountAvailableOnSelectedStationAndFuelType(testStation1, testGasName, testFuelAmount);

            Assert.True(actual);
        }

        [Fact]
        public void Incorrect_fuel_type_on_station()
        {
            string[] testNameAddress1 = { "������", "��������, 7" };
            List<string> testGasList1 = new List<string>() { "��-92", "��-100", "��-95" };
            Dictionary<string, int> testGasPrice1 = new Dictionary<string, int>()
            {
                { "��-92", 50 },
                { "��-95", 52 },
                { "��-100", 65 }
            };
            Dictionary<string, int> testGasReserve1 = new Dictionary<string, int>()
            {
                { "��-92", 234 },
                { "��-95", 656 },
                { "��-100", 170 }
            };
            Station testStation1 = new Station(testNameAddress1, testGasList1, testGasPrice1, testGasReserve1);
            string testGasName = "��-93";
            int testFuelAmount = 34;

            bool actual = Verification.IsFuelAmountAvailableOnSelectedStationAndFuelType(testStation1, testGasName, testFuelAmount);

            Assert.False(actual);
        }

        [Fact]
        public void Correct_fuel_type_and_Incorrect_fuel_amount_on_staion()
        {
            string[] testNameAddress1 = { "������", "��������, 7" };
            List<string> testGasList1 = new List<string>() { "��-92", "��-100", "��-95" };
            Dictionary<string, int> testGasPrice1 = new Dictionary<string, int>()
            {
                { "��-92", 50 },
                { "��-95", 52 },
                { "��-100", 65 }
            };
            Dictionary<string, int> testGasReserve1 = new Dictionary<string, int>()
            {
                { "��-92", 234 },
                { "��-95", 656 },
                { "��-100", 170 }
            };
            Station testStation1 = new Station(testNameAddress1, testGasList1, testGasPrice1, testGasReserve1);
            string testGasName = "��-92";
            int testFuelAmount = 656;
            int testFuelAmount1 = -234;

            bool actual = Verification.IsFuelAmountAvailableOnSelectedStationAndFuelType(testStation1, testGasName, testFuelAmount);
            bool actual1 = Verification.IsFuelAmountAvailableOnSelectedStationAndFuelType(testStation1, testGasName, testFuelAmount1);

            Assert.False(actual);
            Assert.False(actual1);
        }
    }
}