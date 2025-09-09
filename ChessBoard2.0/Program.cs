using System;
using static System.Net.Mime.MediaTypeNames;

namespace ChessBoard2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // När programmet startar ska användaren få mata in en siffra N(3–50).Validera inmatningen.
            // Skriv ut ett N×N "schackbräde" med så många rader och kolumner som användaren angav.
            ReadSize();
        }

        static void ReadSize()
        {
            while (true)
            {
                Console.Write("Antalet rader och kolumner: ");
                string text = Console.ReadLine();

                if (!int.TryParse(text, out int number))
                {
                    Console.WriteLine("Ogiltig siffra, försök igen.");
                }
                else if (number < 3 || number > 50)
                {
                    Console.WriteLine("Ogiltigt antal, försök igen.");
                }
                else
                {
                    RenderBoard(number);
                }
            }
        }

        static void RenderBoard(int n)
        {
            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Från uppgift tips
                    if ((i + j) % 2 == 0)
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write("o");
                    }
                }
                Console.WriteLine(" ");
            }
        }
    }
}
