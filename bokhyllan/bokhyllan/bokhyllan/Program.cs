using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bokhyllan
{
    class Bok                                                                           // skapar en klass

    {

        public string Titel;                                                            // här sparas böckernas titel

        public string Författare;                                                       // här sparas böckernas författare

        public string Typ;                                                              // här sparas vilken typ av bok det är

        public int Utgivningsår;

        public Bok(string titel, string författare, string typ, int utgivningsår)       // bokens konstruktor
        {

            Titel = titel;                                                              // inmatad titel tilldelas till objektets titel

            Författare = författare;                                                    // inmatad författare tilldelas till objektets författare

            Typ = typ;                                                                  // inmatad typ av bok tilldelas till objektets typ

            Utgivningsår = utgivningsår;

        }
        public override string ToString()                                              // ToString metod för att kunna presentera varje objekt

        {

            return Titel + ": " + Författare + ", " + Typ + " och gavs ut år " + Utgivningsår;

        }



    }


    class Roman : Bok                                                                  // tre underklasser till bok klassen

    {
        public Roman(string titel, string författare, string typ, int utgivningsår) : base(titel, författare, typ, utgivningsår)

        {

            Typ = "(Roman)";

        }


    }

    class Tidskrift : Bok

    {

        public Tidskrift(string titel, string författare, string typ, int utgivningsår) : base(titel, författare, typ, utgivningsår)

        {

            Typ = "(Tidskrift)";

        }


    }

    class Novellsamling : Bok

    {

        public Novellsamling(string titel, string författare, string typ, int utgivningsår) : base(titel, författare, typ, utgivningsår)

        {

            Typ = "(Novellsamling)";

        }


    }

    internal class Program
    {

        static void Main(string[] args)
        {

            bool myBool = true;                                                       // loopen fortsätter tills den är false

            List<Bok> mittBibliotek = new List<Bok>();                                // skapar en lista för menyn


            while (myBool)                                                            // skapar loopen till min bool

            {
                Console.Clear();                                                      // rensar konsolfönstret

                Console.WriteLine("Hej och välkommen till biblioteket!");             // skapar olika menyval

                Console.WriteLine("[1] - Lägg till bok.");

                Console.WriteLine("[2] - Visa böcker.");

                Console.WriteLine("[3] - Rensa alla böcker.");

                Console.WriteLine("[4] - Avsluta.");


                Int32.TryParse(Console.ReadLine(), out int input);                   // förhindrar körtidsfel



                switch (input)                                                   // skapar en meny

                {
                    case 1:                                                      // om användaren gör menyval 1

                        string titel;                                              // initierar titel, författare, boktyp och utgivningsår 

                        string författare;

                        string typ;

                        int utgivningsår;


                        Console.WriteLine("Skriv in bokens titel:");               // ber användaren mata in titel, författare, utgivningsår och boktyp

                        titel = Console.ReadLine();

                        Console.WriteLine("Skriv in bokens författare:");

                        författare = Console.ReadLine();

                        Console.WriteLine("Ange bokens utgivningsår:");

                        if (Int32.TryParse(Console.ReadLine(), out utgivningsår))

                            Console.WriteLine("Ange typ av bok [1] Roman [2] Tidskrift [3] Novellsamling");

                        typ = Console.ReadLine();

                        int indata = Convert.ToInt32(typ);                        // konverterar string till int

                        if (indata == 1)                                          // om användaren väljer 1


                        {                                                       // så sparas boken som en roman

                            Roman r = new Roman(titel, författare, typ, utgivningsår);

                            mittBibliotek.Add(r);

                            Console.WriteLine("Sparat!");                     // berättar för användaren att boken sparats

                        }


                        else if (indata == 2)                                    // om användaren väljer 2


                        {                                                          // så sparas boken som en tidskrift

                            Tidskrift r = new Tidskrift(titel, författare, typ, utgivningsår);

                            mittBibliotek.Add(r);

                            Console.WriteLine("Sparat!");                         // berättar för användaren att boken sparats



                        }

                        else if (indata == 3)                                    // om användaren väljer 3

                        {                                                          // så sparas boken som en novellsamling

                            Novellsamling r = new Novellsamling(titel, författare, typ, utgivningsår);

                            mittBibliotek.Add(r);

                            Console.WriteLine("Sparat!");                            // berättar för användaren att boken sparats


                        }

                        else if (indata > 3)                                    // om användaren matar in en siffra som är större än 3 så kommer ett felmeddelande

                        {

                            Console.WriteLine("Du måste ange en siffra mellan 1-3. Tryck ENTER för att börja om.");

                        }






                        break;

                    case 2:                                                 // om användaren gör menyval 2

                        if (mittBibliotek.Count > 0)

                        {
                            Console.Clear();                                   // rensar gammal inmatning

                            foreach (Bok item in mittBibliotek)                 // för varje bok i vår lista med böcker

                            {

                                Console.WriteLine(item);                       // så skriver vi ut - ToString

                            }

                            Console.WriteLine("Dina sparade böcker är " + mittBibliotek.Count + "."); // berättar för användaren vilka böcker som finns

                            Console.ReadLine();                               // stannar upp programmet lite


                        }

                        else                                                  // om listan med böcker är tom

                        {
                            // skrivs ett felmeddelande ut
                            Console.WriteLine("Det finns inga böcker registrerade!");

                        }

                        break;

                    default:                                          // om användaren matar in något annat än 1-4 kommer ett felmeddelande

                        Console.WriteLine("Du har gjort ett felaktigt val!");

                        break;

                    case 3:                                              // om användaren gör menyval 3

                        Console.WriteLine("Nu rensar vi alla böcker!");      // så rensas listan med böcker
                        mittBibliotek.Clear();
                        break;

                    case 4:                                              // om användaren gör menyval 4

                        myBool = false;                                  // så avslutas programmet 

                        break;


                }

                Console.ReadLine();                                     // rensar innehållet när användaren trycker enter efter varje menyval 

            }
            
        }
    }
}
