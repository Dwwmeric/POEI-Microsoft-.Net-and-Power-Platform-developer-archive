using System;
using System.Security.Cryptography.X509Certificates;
using FormationCS;

namespace password_generator
{
    internal class Program
    {
     
        static void Main(string[] args)
        {
            // constante 
            const int NUMBER_PASSWORD = 10;

            // appel la fonction de la longeur du mot de passe
            int longuerPassword = Outils.DemanderUnNombreNonNul("Longeur du mot de passe : ");
            Console.WriteLine();
            // récupération de la réponse 
            int composition = Outils.DemanderNombreEntreMInMax("Composer votre mot de passe ?\n"+
                "1 - Uniquement des caractères en minuscule.\n" +
                "2 - Des caractères minuscules et majuscules.\n" +
                "3 - Des caractères minuscules, majuscules et chiffres.\n" +
                "4 - Caratères minuscules, majsucules, chiffres et spéciaux.\n" +
                "Votre choix:"
                ,1,4);


           
            // varriable des élèments du mot de passe 
            string minuscules = "abcdefghijklmnopqrstuvwxyz";
            string majuscules = minuscules.ToUpper();
            string chiffres = "0123456789";
            string speciale = "&~#{[(-|`_^@])°+=}¤$£%§/.?!:;,*/²";
            string alphabet = "";

            // condition de la composition attention avec raccoursi de code 
            if (composition == 1)
                alphabet = minuscules;
            else if (composition == 2)  
                alphabet = minuscules + majuscules;
            else if (composition == 3)
                alphabet = minuscules + chiffres + majuscules;
            else 
                alphabet = minuscules + chiffres + majuscules + speciale;

            // variable qui prent en compte la longeur des caractères 
            int longAlphabet = alphabet.Length;

            // appel la classe Random 
            Random rand = new Random();

            // variable qui contient le mot de passe 
            string password = "";

            // boucle qui génère le nombre définie de mot de passe 
            for (int j = 0; j < NUMBER_PASSWORD; j++)
            {
                //rénisialide la variable 
                password = "";
                // boucle pour inplémenter le mot de passe 
                for (int i = 0; i < longuerPassword; i++)
                {
                    int index = rand.Next(0,alphabet.Length);
                    password += alphabet[index];
                }
            
                //affiche le mot de passe 
                Console.WriteLine($"Mot de passe : {password}");
            }

        }
    }
}
