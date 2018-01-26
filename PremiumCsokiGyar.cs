using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csoki
{
    class PremiumCsokiGyar : Csokigyar
    {

        public PremiumCsokiGyar(string _csokiFajta, string[] _alapAnyagok, double _kakaoTartalom) : base(_csokiFajta, _alapAnyagok, _kakaoTartalom)
        {

        }


        public override bool MegfeleloMinoseg
        {
            get
            {
                return megfeleloMinoseg;
            }

            set
            {
                if (kakaoTartalom > 80) megfeleloMinoseg = true;
                else if (kakaoTartalom >= 0 && kakaoTartalom <= 80) megfeleloMinoseg = false;
                else throw new SilanyMinosegException();

            }
        }

    }
}
