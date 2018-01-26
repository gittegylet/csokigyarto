using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csoki
{
    // Írj egy PremiumCsokiGyar osztályt, amely a Csokigyar osztály leszármazottja, belőle viszont 
    // nem származhat további osztály. (-> ennél nem tudom, melyik módosító kellett volna a class-hoz!?  <HIBA4>) ->
    class PremiumCsokiGyar : Csokigyar
    {
        //Megjegyzés:  az alábbi részben az ősosztály (Csokigyar) paraméteres konstruktorát hívjuk meg,
        //mely során az új konstruktorunk által "kezelt" paraméterek is átadódnak az ős-konstruktornak.
        //(ezért lesz teljesen üres a törzs!)
        public PremiumCsokiGyar(string _csokiFajta, string[] _alapAnyagok, double _kakaoTartalom) : base(_csokiFajta, _alapAnyagok, _kakaoTartalom)
        {

        }


        //Megjegyzés: itt írta felül az eredetileg feleslegesen létrehozott property-t 
        //(amit az Etelgyar-interfészből kellett volna implementálni)!  -> <HIBA3>

        //public override bool MegfeleloMinoseg
        //{
        //get
        //{
        //    if (kakaoTartalom > 80) return true;
        //    else if (kakaoTartalom >= 0 && kakaoTartalom <= 80) return false;
        //    else throw new SilanyMinosegException();
        //}

        //Megjegyzés: Az eredeti beadott anyagban volt set blokk is, az állította be a property aktuális értékét!

        //set
        //{
        //    if (kakaoTartalom > 80) megfeleloMinoseg = true;
        //    else if (kakaoTartalom >= 0 && kakaoTartalom <= 80) megfeleloMinoseg = false;
        //    else throw new SilanyMinosegException();

        //}
        //}


        // Ennek az osztálynak az esetében a megfelelő minőség meghatározásáért felelős metódus csak 80%-ot meghaladó 
        // kakaótartalom esetén adjon vissza igaz értéket! ->  (A FENTI ROSSZ MEGOLDÁS HELYETT ÍGY KELLETT VOLNA!!)

        public bool megfeleloMinoseg
        {

            get
            {
                if (kakaoTartalom > 80) return true;
                else if (kakaoTartalom >= 0 && kakaoTartalom <= 50) return false;
                else throw new SilanyMinosegException();  //* Itt dobja a hibát (SilanyMinosegException megvalósítása másik fájlban)!
            }
            
        }

    }
}
