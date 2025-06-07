using System;

namespace generator_discourt
{

    internal class Program
    {
        //fontion de selection d'élèment aléatoire
        static string ObtenirElementAleetoire(string[] t)
        {
            Random rand = new Random();
            
            int i = rand.Next(t.Length);
            return t[i];
        }
        static void Main(string[] args)
        {
            // constante 
            const int NUMBER_MAX = 20; 
            var phraseUnique = new List<string>();
            int doublons = 0;

            // tableau sujet 
            var sujets = new string[] {
                "Un militaire",
                "Un gendarme",
                "Un chien",
                "Un magicien",
                "Un pompier",
                "Une femmme",
                "Une saucisse",
                "Un tonton",
            };

            // tableau verbe 
            var verbes = new string[] {
                "mange",
                "boit",
                "écrase",
                "attrape",
                "avale",
                "regarde",
                "observe",
                "lit",
                "se bat avec",
                "s'accroche à",
            };

            // tableau complement
            var complements = new string[] { 
                "un arbre",
                "un livre",
                "la lune",
                "le soleil",
                "le ciel",
                "une piscine",
                "un segent",
                "une carte",
                "une montre",
                "un tapis",
                "une voiture",
                "un troll",
            };

            while ( phraseUnique.Count < NUMBER_MAX)
            {
                var sujet = ObtenirElementAleetoire(sujets);
                var verbe = ObtenirElementAleetoire(verbes);
                var complement = ObtenirElementAleetoire(complements);

                var phrase = sujet +" "+ verbe +" "+ complement;

                // remplace avec replace 
                phrase = phrase.Replace("à le", "au");

                if (!phraseUnique.Contains(phrase))
                {
                    phraseUnique.Add(phrase);
                }else
                {
                    doublons++;
                }

            }
                foreach ( var p in phraseUnique)
                {
                    Console.WriteLine(p);
                }

                Console.WriteLine($"on a évité {doublons} de double!");
                Console.WriteLine($"Nombre de phrase {phraseUnique.Count}!");
        }
    }
}
