using System;

namespace jeu_de_math
{
    internal class Program
    {
        // utilisation de enum
        enum e_Operateur
        {
            ADDITION = 1,
            MULTIPLICATION = 2,
            SOUSTRACTION = 3
        }

        // création de le fonction poser question 
        static bool PoserQuestion(int min, int max)
        {
            //appel classe 
            Random rand = new Random();

            // varriable 
            int a = rand.Next(min, max + 1);
            int b = rand.Next(min, max + 1);

            int reponseQuestion = 0;
           
            while (true)
            {
                e_Operateur o = (e_Operateur)rand.Next(1, 4);
                int resultatAttendu;
                switch (o)
                {
                    case e_Operateur.ADDITION:
                        Console.Write(a + " + " + b + " = ");
                        resultatAttendu = a + b;
                        break;
                    case e_Operateur.MULTIPLICATION:
                        Console.Write(a + " x " + b + " = ");
                        resultatAttendu = a * b;
                        break;
                    case e_Operateur.SOUSTRACTION:
                        Console.Write(a + " - " + b + " = ");
                        resultatAttendu = a - b;
                        break;
                    default:
                        // cas inconnu
                        Console.WriteLine("ERREUR : opérateur inconnu");
                        return false;
                }
                string reponse = Console.ReadLine();

                try
                {
                    reponseQuestion = int.Parse(reponse);

                    if (reponseQuestion == resultatAttendu)
                    {
                       return true;
                       
                    }
                        return false;
                }
                catch
                {
                    Console.WriteLine("ERREUR : Vous devez rentrer un nombre");
                }
            }
        }


        static void Main(string[] args)
        {
            // constante 
            const int MIN = 1;
            const int MAX = 10;
            const int NUMBER_TURN = 10;

            // compteur de bonne réponse
            int point = 0;

            //variable pour la moyenne 
            int moyenne = NUMBER_TURN / 2;

            for ( int i = 0;  i < NUMBER_TURN; i++)
            {
                //question
                Console.WriteLine($"Question n° {(i+1)}/{NUMBER_TURN} !");
                bool result = PoserQuestion(MIN, MAX);

                if (result)
                {
                    Console.WriteLine("Bonne réponse!!\n");
                    point++;
                }
                else
                {
                    Console.WriteLine("Mauvaise réponse!!\n");
                }
            }

            Console.WriteLine($"Vous avez réussie {point}/{NUMBER_TURN} de questions !");
            if (point == NUMBER_TURN)
            {
                Console.WriteLine("Exélent parcour");
            }else if (point == 0)
            {
                Console.WriteLine("Au boulot !!");
            }else if (point > moyenne)
            {
                Console.WriteLine("Pas mal!!");
            }else if (point <= moyenne)
            {
                Console.WriteLine("peut mieu faire.");
            }


        }
    }
}
