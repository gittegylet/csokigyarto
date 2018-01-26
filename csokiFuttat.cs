using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace csoki
{
    // 4. Írj egy futtatható osztályt, mely megnyit egy „input.txt” nevű fájlt! ->
    class csokiFuttat
    {

        static StreamReader sr;

        static StreamWriter sw = new StreamWriter("input.txt");
        static StreamWriter sw2 = new StreamWriter("output.txt");

        static Random vel = new Random();


        static void Main(string[] args)
        {

            //  + KÓDRÉSZ.... (elkészít egy random generált, input.txt nevű bemeneti fájlt a dolgozat teszteléséhez) !!! ====>

            Console.WriteLine("Nyomj egy Entert, ha indulhat a program! ;)");
            Console.ReadLine();
            
            int csCount = vel.Next(81) + 120;

            sw.WriteLine(csCount);


            string[] csokiFelek = { "keserűcsoki", "étcsoki", "tejcsoki", "fehércsoki", "töltöttcsoki" };

            string[,] osszetevok = { { "cukor", "nádcukor" }, { "sovány tejpor", "teljes tejpor" }, { "zsírszegény kakaópor", "kakaómassza" }, { "tejsavópor", "tejszínpor" }, { "hidrogénezett növényi zsír/vajzsír", "kakaóvaj" }, { "szójalecitin", "emulgeálószerek" }, { "vaníliaaroma", "vaníliakivonat" }, { "mogyorópaszta", "mogyoróvelő" } };
            

            for (int i = 0; i < csCount; i++)
            {
                
                bool premiumCsoki = false;

                string[] adatok = new string[11];

                
                string csokiFajta = csokiFelek[vel.Next(5)];

                double kakaoTartalom = 0;

                switch (csokiFajta)
                {
                    case "keserűcsoki": kakaoTartalom = (vel.Next(680) + 300) / 10.0;  break;
                    case "étcsoki": kakaoTartalom = (vel.Next(210) + 440) / 10.0;  break;
                    case "tejcsoki": kakaoTartalom = (vel.Next(350) + 50) / 10.0;  break;
                    //case "fehércsoki": kakaoTartalom = 0;  break;
                    case "töltöttcsoki": kakaoTartalom = (vel.Next(500)) / 10.0;  break;
                    default:  break;
                }

                List<string> alapanyagLista = new List<string>();

                int rand = vel.Next(10) + 1;

                if (csokiFajta != "keserűcsoki" && csokiFajta != "étcsoki")
                {
                    if (rand <= 9) alapanyagLista.Add(osszetevok[0, 0]);
                    else alapanyagLista.Add(osszetevok[0, 1]);

                    rand = vel.Next(10) + 1;
                    if (rand <= 4) alapanyagLista.Add(osszetevok[1, 0]);
                    else alapanyagLista.Add(osszetevok[1, 1]);

                }
                else if (csokiFajta == "étcsoki" && rand <= 9) alapanyagLista.Add(osszetevok[0, vel.Next(2)]);

                rand = vel.Next(10) + 1;
                if (csokiFajta == "keserűcsoki" && rand == 1) alapanyagLista.Add(osszetevok[2, 0]);
                else if (csokiFajta == "keserűcsoki") alapanyagLista.Add(osszetevok[2, 1]);
                else if (csokiFajta != "fehércsoki" && rand <= 2) alapanyagLista.Add(osszetevok[2, 0]);
                else if (csokiFajta != "fehércsoki") alapanyagLista.Add(osszetevok[2, 1]);

                rand = vel.Next(3) + 1;
                if (csokiFajta != "keserűcsoki" && csokiFajta != "étcsoki" && rand == 1) alapanyagLista.Add(osszetevok[3, vel.Next(2)]);

                rand = vel.Next(10) + 1;
                if (csokiFajta == "fehércsoki" || csokiFajta == "keserűcsoki") alapanyagLista.Add(osszetevok[4, 1]);
                else if (csokiFajta == "étcsoki" && rand <= 6) alapanyagLista.Add(osszetevok[4, 0]);
                else if (csokiFajta == "étcsoki") alapanyagLista.Add(osszetevok[4, 1]);
                else if (rand <= 3) alapanyagLista.Add(osszetevok[4, 0]);
                else alapanyagLista.Add(osszetevok[4, 1]);
                
                rand = vel.Next(10) + 1;
                if ((csokiFajta == "étcsoki" && rand <= 3) || (csokiFajta == "keserűcsoki" && rand <= 2) || 
                    (csokiFajta != "étcsoki" && csokiFajta != "keserűcsoki" && rand <= 7)) alapanyagLista.Add(osszetevok[5, vel.Next(2)]);


                rand = vel.Next(10) + 1;
                switch (csokiFajta)
                {
                    case "keserűcsoki": if (rand == 1) alapanyagLista.Add(osszetevok[6, 1]); break;
                    case "étcsoki": if (rand == 1) alapanyagLista.Add(osszetevok[6, 0]); else if (rand == 2) alapanyagLista.Add(osszetevok[6, 1]); break;
                    case "tejcsoki": if (rand <= 4) alapanyagLista.Add(osszetevok[6, 0]); else if (rand == 5) alapanyagLista.Add(osszetevok[6, 1]); break;
                    case "fehércsoki": if (rand <= 3) alapanyagLista.Add(osszetevok[6, 0]); else if (rand <= 6) alapanyagLista.Add(osszetevok[6, 1]); break;
                    case "töltöttcsoki": if (rand <= 4) alapanyagLista.Add(osszetevok[6, 0]); else if (rand <= 6) alapanyagLista.Add(osszetevok[6, 1]); break;
                    default: break;
                }

                rand = vel.Next(10) + 1;
                if (csokiFajta == "tejcsoki" && rand <= 4) alapanyagLista.Add(osszetevok[7, 1]);
                else if (csokiFajta == "fehércsoki" && rand <= 2) alapanyagLista.Add(osszetevok[7, 0]);
                else if (csokiFajta == "fehércsoki" && rand == 3) alapanyagLista.Add(osszetevok[7, 1]);
                else if ((csokiFajta == "keserűcsoki" || csokiFajta == "étcsoki") && rand == 1) alapanyagLista.Add(osszetevok[7, 1]);
                else if (csokiFajta == "töltöttcsoki")
                {
                    if (rand <= 4) alapanyagLista.Add(osszetevok[7, 0]);
                    else alapanyagLista.Add(osszetevok[7, 1]);
                    
                }

                string alapanyagok = "";
                alapanyagLista.ForEach(a => { alapanyagok += ";" + a; });

                if ((alapanyagLista.Contains("kakaómassza") || alapanyagLista.Contains("kakaóvaj")) &&
                    !alapanyagLista.Contains("szójalecitin") && !alapanyagLista.Contains("emulgeálószerek") &&
                    !alapanyagLista.Contains("vajzsír") && !alapanyagLista.Contains("tejsavópor") &&
                    (!alapanyagLista.Contains("sovány tejpor") || !alapanyagLista.Contains("vaníliaaroma")) &&
                    (!alapanyagLista.Contains("vaníliaaroma") || !alapanyagLista.Contains("mogyorópaszta")) &&
                    ((csokiFajta == "keserűcsoki" && kakaoTartalom >= 55) ||
                    (csokiFajta == "étcsoki" && kakaoTartalom >= 45) ||
                    (csokiFajta != "keserűcsoki" && csokiFajta != "étcsoki" && kakaoTartalom >= 25))) premiumCsoki = true;

                if (premiumCsoki) sw.WriteLine(csokiFajta + ";" + kakaoTartalom.ToString() + alapanyagok + ";PRÉMIUM");
                else sw.WriteLine(csokiFajta + ";" + kakaoTartalom.ToString() + alapanyagok);


            }

            sw.Flush();
            sw.Close();

            
            //Innen kezdődik a beadott dolgozat kódja ==>

            try
            {

                sr = new StreamReader("input.txt");

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);

            }

            // A fájl első sora tartalmazza azt, hogy hány további sor van a fájlban. ->
            int sorok = int.Parse(sr.ReadLine());


            List<Csokigyar> csokiLista = new List<Csokigyar>();



            for (int i = 0; i < sorok; i++)
            {

                try
                {
                    // A további sorok pontosvesszővel elválasztott stringeket tartalmaznak: az első elem a csoki fajtáját, 
                    // a második a kakaótartalmát (ez egy szám), a további elemek pedig az alapanyagokat. -->

                    string[] adatok = sr.ReadLine().Split(';');

                    // A sor végén opcionálisan álló prémium string jelzi, ha az adott objektum prémium típusú. ->
                    bool premiumCsoki = adatok[adatok.Length - 1].ToLower() == "prémium";

                    string csokiFajta = adatok[0];
                    double kakaoTartalom = double.Parse(adatok[1]);

                    string[] alapAnyagok;

                    int reszAdatok = adatok.Length;

                    if (premiumCsoki) reszAdatok -= 3;
                    else reszAdatok -= 2;


                    alapAnyagok = new string[reszAdatok];

                    for (int j = 0; j < alapAnyagok.Length; j++)
                    {
                        alapAnyagok[j] = adatok[j + 2];

                    }
                    
                    // Dolgozd fel a sorokat, és hozd létre a megadott számú Csokigyar vagy PremiumCsokigyar objektumokat. ->
                    // (MEGJEGYZÉS, EZT VÉGZI EL AZ IMÉNTI CIKLUSUNK!!! ;)) 

                    if (premiumCsoki) csokiLista.Add(new PremiumCsokiGyar(csokiFajta, alapAnyagok, kakaoTartalom));
                    else csokiLista.Add(new Csokigyar(csokiFajta, alapAnyagok, kakaoTartalom));

                    

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);

                }




            }


            // Ezután sorban írasd ki a standard outputra az egyes objektumok toString-jét ->
            
            // ...A ki-, bemeneti és más hibákat kapd el, és írj ki valamilyen
            // tájékoztató hibaüzenetet!  --> Ehhez kellettek a try-catch blokkok!!

            try
            {
                csokiLista.ForEach(c => {

                    string message = c.ToString();

                    // valamint a megfeleloMinoseg metódus segítségével azt, hogy jó vagy rossz minőségű csokit gyártanak-e, 
                    // hibadobás esetén pedig a „Nem igazi csoki!” szöveget. ->

                    if (!c.megfeleloMinoseg) message += " Rossz minőségű!";
                    else message += " JÓ minőségű!";

                    Console.WriteLine(message);
                    sw2.WriteLine(message);

                });

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }

            sr.Close();  //+kód  -> a beadott verzióból véletlen kimaradt!!

            sw2.Flush();
            sw2.Close();

            Console.ReadLine();

        }

    }
}