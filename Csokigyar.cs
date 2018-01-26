using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csoki
{
    class Csokigyar : Etelgyar
    {

        protected string csokiFajta;
        protected string[] alapAnyagok;
        protected double kakaoTartalom;

        protected bool megfeleloMinoseg;

        public Csokigyar(string _csokiFajta, string[] _alapAnyagok, double _kakaoTartalom)
        {
            csokiFajta = _csokiFajta;
            alapAnyagok = _alapAnyagok;
            kakaoTartalom = _kakaoTartalom;

            MegfeleloMinoseg = true;

        }

        public string[] mibolKeszul()
        {

            return alapAnyagok;

        }


        
        public virtual bool MegfeleloMinoseg
        {
            get
            {
                return megfeleloMinoseg;
            }

            set
            {
                if (kakaoTartalom > 50) megfeleloMinoseg = true;
                else if (kakaoTartalom >= 0 && kakaoTartalom <= 50) megfeleloMinoseg = false;
                else throw new SilanyMinosegException();
            }

        }

        bool Etelgyar.megfeleloMinoseg
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override string ToString()
        {

            return csokiFajta + " " + kakaoTartalom;

        }

        string[] Etelgyar.mibolKeszul()
        {
            throw new NotImplementedException();
        }
    }

}
