using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Stefania_Sanna_Week7
{
    class StudenteNonTrovatoException: Exception
    {
        public Studente StudenteEccezione { get; set; }

        public StudenteNonTrovatoException()
        {

        }

        public StudenteNonTrovatoException(string messaggio) : base(messaggio)
        {

        }

        public StudenteNonTrovatoException(string messaggio, Exception innerException) : base(messaggio, innerException)
        {

        }

        protected StudenteNonTrovatoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
