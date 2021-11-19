using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefania_Sanna_Week7
{
    public class StudentiManager
    {
        //Qui sotto ci sono la stringa corretta (per la seconda parte) e quella errata (per la prima)

        //const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Studenti;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        const string connectionString = @"gjfgl";
        internal List<Studente> GetAllStudents()
        {
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from Studente";
                    SqlDataReader reader = command.ExecuteReader();
                    List<Studente> studenti = new List<Studente>();

                    while (reader.Read())
                    {
                        var id = reader["IdStudente"];
                        var nome = reader["Nome"];
                        var cognome = reader["Cognome"];

                        Studente newStudente = new Studente()
                        {
                            IdStudente = (int)id,
                            Nome = (string)nome,
                            Cognome = (string)cognome
                        }; 
                        studenti.Add(newStudente);
                    }

                    if (studenti.Count() == 0)
                    {
                        connection.Close();
                        return null;
                    }
                    return studenti;
                }

            }
            catch (System.ArgumentException arg)
            {
                Console.WriteLine($"Errore argomento iniziale!!{arg.Message}");
                return null;
            }

            catch (SqlException ex) 
            {
                Console.WriteLine($"Errore tipo SqlException!!{ex.Message}");
                return null;
            }
            catch (Exception e) 
            {
                Console.WriteLine($"Errore!!{e.Message}");
                return null; 
            }
            finally 
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
        internal Studente GetStudentByID(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Studente";
                SqlDataReader reader = command.ExecuteReader();
                Studente newStudente = new Studente();             
                while (reader.Read())
                {
                    var idstud = reader["IdStudente"];
                    var nome = reader["Nome"];
                    var cognome = reader["Cognome"];

                    if((int)idstud == id)
                    {
                        newStudente.IdStudente = (int)id;
                        newStudente.Nome = (string)nome;
                        newStudente.Cognome = (string)cognome;                        
                    }                                                        
                }                            
                connection.Close();
                return newStudente;
            }
        }
    }
}
