using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace АЗС
{
    internal class Cheque
    {
        private string chequeString = "";

        public Cheque(string chequeString)
        {
            ChequeString = chequeString;
        }

        public string ChequeString
        {
            get { return chequeString; }
            set { chequeString = value; }
        }
    }
}
