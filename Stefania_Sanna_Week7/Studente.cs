using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefania_Sanna_Week7
{
    public class Studente
    {
        public int IdStudente { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public Studente()
        {

        }
        public Studente(int id, string nome, string cognome)
        {
            IdStudente = id;
            Nome = nome;
            Cognome = cognome;
        }


        public void VerificaEsistenzaStudente()
        {          
            if (Nome == null && Cognome == null && IdStudente==0)
            {
                throw new StudenteNonTrovatoException("Errore!!Non è stato trovato lo studente")
                {
                    StudenteEccezione = this                  
                };               
            }            
        }

        public override string ToString()
        {
            return $"{IdStudente} - {Nome} - {Cognome}";
        }
    }
}
