using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace АЗС.BuisnessLogic
{
    public class Cheque
    {
        public string ChequeString {get; set;}

        public Cheque(string chequeString)
        {
            ChequeString = chequeString;
        }

    }
}
