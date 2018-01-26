using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csoki
{

    interface Etelgyar
    {
        string[] mibolKeszul();

        bool megfeleloMinoseg { get; set; }

    }

    class SilanyMinosegException : Exception
    {

        public SilanyMinosegException() : base("Nem igazi csoki!") { }

    }




}
