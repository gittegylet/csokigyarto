using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csoki
{
    // 1. Írj egy interfészt Etelgyar néven a csoki csomagba, amely egy metódust és egy
    // tulajdonságot deklarál.

    interface Etelgyar
    {
        // A mibolKeszul metódus nem vár paramétert és egy string tömbbel tér vissza ->
        
        string[] mibolKeszul();

        // a megfeleloMinoseg csak olvasható(get) tulajdonság pedig igaz vagy hamis
        // értékkel, esetleg SilanyMinosegException kivételt is dobhat ->
        bool megfeleloMinoseg { get; }    //Megjegyzés: eredetileg set is volt benne!! <HIBA1>

    }

    // Ehhez hozd létre a SilanyMinosegException osztályt is! ->

    class SilanyMinosegException : Exception
    {

        public SilanyMinosegException() : base("Nem igazi csoki!") { }  // -> ...hibát dob „Nem igazi csoki!” szöveggel (2. fel.)

    }




}
