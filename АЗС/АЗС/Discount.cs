using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class Discount
    {
        private int discuontSize;

        public Discount(int discuontSize)
        {
            DiscountSize = discuontSize;
        }

        public int DiscountSize
        {
            get { return discuontSize; }
            set { discuontSize = value; }
        }
    }
}
