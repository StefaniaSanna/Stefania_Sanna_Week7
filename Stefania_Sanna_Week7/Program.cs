using System;
using System.Collections.Generic;

namespace Stefania_Sanna_Week7
{
    class Program
    {
        //Esercizi teoria
        //Domanda 1 : C
        //Domanda 2 : B, C
        //Damanda 3 : A, D
        private static StudentiManager db = new StudentiManager();
        static void Main(string[] args)
        {
            bool continua = true;
            do
            {
                Console.WriteLine("----------Menù----------");
                Console.WriteLine("[1] Visualizza tutti gli studenti");
                Console.WriteLine("[2] Visualizza uno studente tramite l'ID");
                Console.WriteLine("[0] Esci");

                int scelta;
                do
                {
                    Console.WriteLine("Selezionare una scelta");
                }
                while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0));

                switch (scelta)
                {
                    case 1:
                        StampaTuttiStudenti();
                        break;
                    case 2:
                        StampaStudenteDaID();
                        break;
                    default:
                        Console.WriteLine("Scelta non disponibile");
                        break;
                    case 0:
                        continua = false;
                        break;
                }
            }
            while (continua == true);

        }

        private static void StampaTuttiStudenti()
        {
            List<Studente> studenti = db.GetAllStudents();
            if (studenti != null)
            {          
                Console.WriteLine("Gli studenti sono:");

                foreach (var item in studenti)
                {
                    Console.WriteLine($"{item.ToString()}");
                }
            }
        }

        private static void StampaStudenteDaID()
        {
            Studente studente = new Studente();
            StampaTuttiStudenti();
            try
            {
                Console.WriteLine("Inserire ID dello studente:");
                int id = int.Parse(Console.ReadLine());
                studente = db.GetStudentByID(id);
                studente.VerificaEsistenzaStudente();
                if (studente != null)
                {
                    Console.WriteLine($"{studente.ToString()}");
                }
            }
            catch (StudenteNonTrovatoException snte)
            {
                Console.WriteLine(snte.Message);
            }
            catch(FormatException f)
            {
                Console.WriteLine($"Errore di forma {f.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine("Errore!!");
            }           
        }
    }
}
