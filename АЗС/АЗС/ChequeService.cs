using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class ChequeService
    {
        public static void PrintCheque(Cheque cheque)
        {
            Console.WriteLine(cheque.ChequeString);
        }

        public static void WriteCheque(Cheque cheque)
        {
            using (StreamWriter SW = new StreamWriter("./Check.txt", false))
            {
                SW.WriteLine(cheque.ChequeString);
            }
        }
    }
}
