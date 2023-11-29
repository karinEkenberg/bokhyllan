using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bokhyllan
{
    class Bok// skapar en klass
    {
        public string Titel;// här sparas böckernas titel
        public string Författare;// här sparas böckernas författare
        public string Typ;// här sparas vilken typ av bok det är
        public int Utgivningsår;

        public Bok(string titel, string författare, string typ, int utgivningsår)// bokens konstruktor
        {
            Titel = titel;// inmatad titel tilldelas till objektets titel
            Författare = författare;// inmatad författare tilldelas till objektets författare
            Typ = typ;// inmatad typ av bok tilldelas till objektets typ
            Utgivningsår = utgivningsår;// inmatad utgivningsår tilldelas till objektets utgivningsår
        }

        internal string ToUpper()
        {
            throw new NotImplementedException();
        }
    }

    class Roman : Bok// tre underklasser till bok klassen
    {
        public Roman(string titel, string författare, string typ, int utgivningsår) : base(titel, författare, typ, utgivningsår)
        {
            Typ = "Romanen ";
        }
        public override string ToString()// ToString metod för att kunna presentera varje objekt
        {
            return Typ + Titel + " är skriven av " + Författare + " \r\noch gavs ut år " + Utgivningsår + 
                " och kan hittas vid avdelningen för böcker.";
        }
    }

    class Tidskrift : Bok
    {
        public Tidskrift(string titel, string författare, string typ, int utgivningsår) : base(titel, författare, typ, utgivningsår)
        {
            Typ = "Tidskriften ";
        }
        public override string ToString()
        {
            return Typ + Titel + " är skriven av " + Författare + " \r\noch gavs ut år " + Utgivningsår + 
                " den hittar du vid hyllan med tidningar.";
        }
    }

    class Novellsamling : Bok

    {
        public Novellsamling(string titel, string författare, string typ, int utgivningsår) : base(titel, författare, typ, utgivningsår)
        {
            Typ = "Novellsamlingen ";
        }
        public override string ToString()
        {
            return Typ + Titel + " är skriven av " + Författare + " \r\nden gavs ut år " + Utgivningsår + 
                " du hittar den i bokhyllan borta i hörnet.";
        }
    }

    class Bibliotekarie
    {
        private List<Bok> mittBibliotek = new List<Bok>();// skapar en lista för menyn
        public void HämtaBokLista()// skapar en metod för att visa alla böcker i listan
        {
            if (mittBibliotek.Count > 0)
            {
                Console.Clear();// rensar gammal inmatning
                foreach (Bok item in mittBibliotek)// för varje bok i vår lista med böcker
                {
                    Console.WriteLine(item);// så skriver vi ut - ToString
                }
                Console.WriteLine("Dina sparade böcker är " + mittBibliotek.Count + "."); // berättar för användaren vilka böcker som finns
                Console.ReadLine();// stannar upp programmet lite
            }
            else// om listan med böcker är tom
            {
                // skrivs ett felmeddelande ut
                Console.WriteLine("Det finns inga böcker registrerade!");
            }
        }
        public void SkapaBok()// skapar en metod för att lägga till böcker
        {
            string titel;// initierar titel, författare, boktyp och utgivningsår 
            string författare;
            string typ;
            int utgivningsår;

            Console.WriteLine("Skriv in bokens titel:");// ber användaren mata in titel, författare, utgivningsår och boktyp
            titel = Console.ReadLine();
            Console.WriteLine("Skriv in bokens författare:");
            författare = Console.ReadLine();
            Console.WriteLine("Ange bokens utgivningsår:");
            if (Int32.TryParse(Console.ReadLine(), out utgivningsår))
                Console.WriteLine("Ange typ av bok [1] Roman [2] Tidskrift [3] Novellsamling");
            typ = Console.ReadLine();
            int indata = Convert.ToInt32(typ);// konverterar string till int

            if (indata == 1)// om användaren väljer 1
            {// så sparas boken som en roman
                Roman r = new Roman(titel, författare, typ, utgivningsår);
                mittBibliotek.Add(r);
                Console.WriteLine("Sparat!");// berättar för användaren att boken sparats
            }

            else if (indata == 2)// om användaren väljer 2
            {         // så sparas boken som en tidskrift
                Tidskrift r = new Tidskrift(titel, författare, typ, utgivningsår);
                mittBibliotek.Add(r);
                Console.WriteLine("Sparat!");// berättar för användaren att boken sparats
            }

            else if (indata == 3)// om användaren väljer 3
            {           // så sparas boken som en novellsamling
                Novellsamling r = new Novellsamling(titel, författare, typ, utgivningsår);
                mittBibliotek.Add(r);
                Console.WriteLine("Sparat!");// berättar för användaren att boken sparats
            }

            else if (indata > 3) // om användaren matar in en siffra som är större än 3 så kommer ett felmeddelande
            {
                Console.WriteLine("Du måste ange en siffra mellan 1-3. Tryck ENTER för att börja om.");
            }
        }
        public void SökBok()// skapar en metod för att söka efter böcker
        {
            Console.WriteLine("Sök efter en bok genom att skriva titeln du söker:");//ber användaren söka efter en specifik bok
            string sökord = Console.ReadLine();//läser in det användaren skriver
            bool knapp = false;//deklarerar en bool för att sökningen ska kunna vara sann eller falsk

            for (int i = 0; i < mittBibliotek.Count; i++)//gör en forloop för att kunna söka i bloggen
            {
                if (mittBibliotek[i].Titel.ToUpper() == sökord.ToUpper())//om sökordet stämmer med boktitlar
                /*la till toupper för att stora eller små bokstäver inte ska 
                 spela någon roll när användaren matar in sökordet*/
                {
                    knapp = true;//när bool är sann skrivs nedstående ut
                    Console.WriteLine("Boken " + sökord + " finns i biblioteket på index: " + i + ".");
                }
            }

            if (knapp == false)//om sökningen misslyckas så skrivs följande ut:
            {
                Console.WriteLine("Boken hittades inte.");
            } 
        }
        public void RensaBöcker()//skapar en metod för att rensa böcker
        {
            Console.WriteLine("Nu rensar vi alla böcker!");      // så rensas listan med böcker
            mittBibliotek.Clear();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Bibliotekarie Gudrun = new Bibliotekarie();
            bool myBool = true; // loopen fortsätter tills den är false
            while (myBool)  // skapar loopen till min bool
 
            {
                Console.Clear();     // rensar konsolfönstret
                Console.WriteLine("Hej och välkommen till biblioteket!");  // skapar olika menyval
                Console.WriteLine("[1] - Lägg till bok.");
                Console.WriteLine("[2] - Visa böcker.");
                Console.WriteLine("[3] - Rensa alla böcker.");
                Console.WriteLine("[4] - Sök bok.");
                Console.WriteLine("[5] - Avsluta.");

                Int32.TryParse(Console.ReadLine(), out int input); // förhindrar körtidsfel

                switch (input) // skapar en meny
                {
                    case 1: // om användaren gör menyval 1
                        Gudrun.SkapaBok(); //kallar på metoden
                        break;
                    case 2:   // om användaren gör menyval 2
                        Gudrun.HämtaBokLista();
                        break;
                    default:  // om användaren matar in något annat än 1-4 kommer ett felmeddelande
                        Console.WriteLine("Du har gjort ett felaktigt val!");
                        break;
                    case 3: // om användaren gör menyval 3
                       Gudrun.RensaBöcker();
                        break;
                    case 4:  // om användaren gör menyval 4
                        Gudrun.SökBok();
                        break;
                    case 5: // om användaren gör menyval 5
                        myBool = false; // så avslutas programmet 
                        Console.WriteLine("Tack för att du besökte biblioteket, på återseende!");
                        break;
                }
                Console.ReadLine(); // rensar innehållet när användaren trycker enter efter varje menyval 
            }
        }
    }
}
