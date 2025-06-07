using System;

namespace nombre_magique
{
    internal class Program
    {
        // fonction qui demande un nombre a l'user
        static int DemanderNombre(int min , int max )
        {
            // varriable de départ 
            int number = min - 1 ;

            while (( number < min ) || (number > max ))
            {
                Console.Write($" Rentré un nombre  entre {min} et {max} ? ");
                string number_str = Console.ReadLine();

                try
                {
                    number = int.Parse(number_str);

                    if ( number < min)
                    {
                        Console.WriteLine($"ERREUR : le nombre est inférrieur à {min} !");
                    } else if ( number > max)
                    {
                        Console.WriteLine($"ERREUR : le nombre est superrieur à {max} !");
                    }
                }
                catch
                {
                    Console.WriteLine("Le nombre est invalide !");
                }

            }

            return number;
        }
        static void Main(string[] args)
        {
            // constante min et max 
            const int number_min = 1;
            const int number_max = 10;

            // appel la classe rambon 
            Random rand = new Random();
            int number_magic = rand.Next(number_min,number_max+1);

            int userNumber = number_min - 1;

            for (int numVie = 4; numVie >0 ; numVie--)
            {
                // appel la fonction 
                Console.WriteLine();
                Console.WriteLine($"Il  vous reste {numVie}");
                userNumber = DemanderNombre( number_min , number_max);

                if (userNumber > number_magic)
                {
                    Console.WriteLine($"Le nombre magique est plus petit que  {userNumber}");
                }
                else if (userNumber < number_magic)
                {
                    Console.WriteLine($"Le nombre magique est plus grand que  {userNumber}");
                }
                else
                {
                    Console.WriteLine($"Le nombre magique est {userNumber} Bravo !!!");
                    break;
                }
            }

            if (userNumber != number_magic)
            {
                Console.WriteLine($"vous avez perdue le nombre magique est {number_magic}");
            }
            
        }
    }
}
