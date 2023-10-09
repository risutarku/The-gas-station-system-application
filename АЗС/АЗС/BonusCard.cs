using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace АЗС
{
    internal class BonusCard
    {
        public int cardId
        {
            get { return cardId; } set { cardId = value; }
        }

        public int bonusAmount
        {
            get { return bonusAmount; } set { bonusAmount = value; }
        }

        public int totalPurchaseAmount
        {
            get { return totalPurchaseAmount; } set { totalPurchaseAmount = value; }
        }

        private BonusCard()
        {
            bonusAmount = 0;
            totalPurchaseAmount = 0;
        }



    }
}
