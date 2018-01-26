using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csoki
{
    // 2. Írj egy osztályt Csokigyar néven, mely implementálja az Etelgyar interfészt! ->
    class Csokigyar : Etelgyar
    {

        // Az osztálynak három adattagja legyen: egy string-ben tároljuk a gyártott csoki fajtáját, egy string
        // tömbben a felhasznált alapanyagokat, egy szám változóban pedig a kakaótartalmat. ->

        protected string csokiFajta;
        protected string[] alapAnyagok;
        protected double kakaoTartalom;

        //Megjegyzés: eredetileg külön adattagot hoztam létre, a már meglévő Etelgyar-interfész helyes implementációja helyett!!
        //protected bool megfeleloMinoseg;


        // Az osztályhoz paraméteres konstruktor tartozik, mely három paramétert vár, és minden adattagot inicializál. ->
        public Csokigyar(string _csokiFajta, string[] _alapAnyagok, double _kakaoTartalom)
        {
            csokiFajta = _csokiFajta;
            alapAnyagok = _alapAnyagok;
            kakaoTartalom = _kakaoTartalom;

            //Megjegyzés: amennyiben van set blokkja, akkor ezzel a sorral lehet beállítani a megfeleloMinoseg true/false értékét!

            //MegfeleloMinoseg = true;    //==> Itt nem a value (egyenlőségjel utáni true) értékkel tér vissza, tehát lényegtelen
                                          //    hogy mi szerepel az egyenlőségjel jobb oldalán! :)

        }

        // A mibolKeszul metódus implementációja visszaadja a felhasznált alapanyagokat ->
        public string[] mibolKeszul()
        {

            return alapAnyagok;

        }


        // a megfeleloMinoseg tulajdonságban ellenőrizze a kakaótartalmat ->
        
        //Megjegyzés: a beadott dolgozatomban az alábbiak szerint valósítottam meg ezt a feladatot <HIBA2>
        //public virtual bool MegfeleloMinoseg
        //{
            //get
            //{
            //    if (kakaoTartalom > 50) return true;
            //    else if (kakaoTartalom >= 0 && kakaoTartalom <= 50) return false;
            //    else throw new SilanyMinosegException();
            //}

            //Megjegyzés: Eredetileg volt set blokkja is, az állította be a property aktuális értékét!

            //set
            //{
            //    if (kakaoTartalom > 50) megfeleloMinoseg = true;
            //    else if (kakaoTartalom >= 0 && kakaoTartalom <= 50) megfeleloMinoseg = false;
            //    else throw new SilanyMinosegException();
            //}

        //}


        //Megjegyzés:  ez lett volna a helyes implementáció!! <HIBA2>

        public virtual bool megfeleloMinoseg
        {

            // Ha a kakaótartalom nagyobb 50%-nál, akkor igazzal tér vissza, ha 0% és 50% közötti, akkor
            // hamissal, ha negatív, akkor (*)hibát dob „Nem igazi csoki!” szöveggel. ->

            get
            {
                if (kakaoTartalom > 50) return true;
                else if (kakaoTartalom >= 0 && kakaoTartalom <= 50) return false;
                else throw new SilanyMinosegException();  //* Itt dobja a hibát (SilanyMinosegException megvalósítása másik fájlban)!
            }

            //Megjegyzés: felesleges a set-blokk!!
            //set
            //{
            //    throw new NotImplementedException();
            //}
        }


        // Az osztály toString metódusát valósítsd meg, és alkalmazd az adatelrejtés elveit is... ->
        public override string ToString()
        {

            return csokiFajta + " " + kakaoTartalom;

        }

        //Megjegyzés:  felesleges kód maradt bent, mivel feljebb már implementálva lett ez a metódusa az interfésznek!
        //string[] Etelgyar.mibolKeszul()
        //{
        //    throw new NotImplementedException();
        //}
    }

}
