using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS
{
    static class Outils
    {
        // fonction nombre non nul 
        public static int DemanderUnNombreNonNul(string question)
        {
            return DemanderNombreEntreMInMax(question, 1, int.MaxValue, "ERREUR: Le nombre doit être positif et non nul");
        }
        // fonction demander nombre entre min et max 
        public static int DemanderNombreEntreMInMax(string question, int min, int max, string message = null )
        {

            //pose la question 
            int number = DemanderNombre(question);

            // verrifie la condition 
            if ((number >= min) && (number <= max))
            {
                // retourn le résulta si bon 
                return number;
            }
            // si Erreur
            if (message == null)
            {
                Console.WriteLine("ERREUR : Le nombre doit être compris entre " + min + " et " + max);
            }
            else
            {
                Console.WriteLine(message);
            }

            Console.WriteLine();

            return DemanderNombreEntreMInMax(question, min, max, message);
        }


        // fonction demmanderNombre
        public static int DemanderNombre(string question)
        {

            while (true)
            {
                Console.Write(question);
                string longPassword = Console.ReadLine();

                try
                {
                    int number = int.Parse(longPassword);
                    return number;
                }
                catch
                {
                    Console.WriteLine(" ERREUR : Veuillez rentrer un nombre valide !");
                    Console.WriteLine();
                }

            }
            return 0;
        }
    }
}
