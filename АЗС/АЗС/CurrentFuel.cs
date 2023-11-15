using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class CurrentFuel
    {
        private string fuelTypeName;

        public CurrentFuel(string fuelTypeName)
        {
            FuelTypeName = fuelTypeName;
        }

        public string FuelTypeName
        {
            get { return fuelTypeName; }
            set { fuelTypeName = value; }
        }


    }
}
