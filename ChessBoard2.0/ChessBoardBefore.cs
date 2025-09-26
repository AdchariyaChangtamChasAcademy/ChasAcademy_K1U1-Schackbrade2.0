using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard2._0
{
    internal class ChessBoardBefore
    {
        public void ReadSize()
        {
            // LOOP START
            while (true)
            {
                Console.WriteLine("Size of board? (3-50) or [Q] to quit");
                string input = Console.ReadLine();

                if (string.Equals(input, "q", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                // Tip from task page for error handling
                if (!int.TryParse(input, out int number))
                {
                    Console.WriteLine("Invalid input. Try again! (Input a number between 3-50)");
                    continue;
                }
                else if (number < 3 || number > 50)
                {
                    Console.WriteLine("Invalid size. Try again! (3-50)");
                    continue;
                }

                // Asks for input for use as black squares
                Console.WriteLine("\nInput symbol for BLACK squares? [Enter] for default black squares");
                Console.Write("B: ");
                string blackSquare = Console.ReadLine();

                // Asks for input for use as white squares
                Console.WriteLine("\nInput symbol for WHITE squares? [Enter] for default white squares");
                Console.Write("W: ");
                string whiteSquare = Console.ReadLine();

                RenderBoard(number, blackSquare, whiteSquare);
            }

            // Inserted above code to ChatGPT and promted "Can you improve this method for my chess board program in C#?"
            // In return it suggested the code in ReadSize() in ChessBoardAfter.cs
        }

        public void RenderBoard(int boardSize, string symbolBlack, string symbolWhite)
        {
            string SymbolBlack = symbolBlack;
            string SymbolWhite = symbolWhite;

            /// Tip from task page for typing out correct black/white squares
            Console.OutputEncoding = Encoding.UTF8;

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        // If blackSquare is empty, use default black square.
                        if (!string.IsNullOrEmpty(SymbolBlack))
                        {
                            Console.Write(SymbolBlack);
                        }
                        else
                        {
                            Console.Write("\u25A0"); // black square code as default
                        }
                    }
                    else
                    {
                        // If whiteSquare is left empty, use default black square.
                        if (!string.IsNullOrEmpty(SymbolWhite))
                        {
                            Console.Write(SymbolWhite);
                        }
                        else
                        {
                            Console.Write("\u25A1"); // white square code as default
                        }
                    }
                }
                Console.WriteLine(" ");
            }

            // Spacing for next loop
            Console.WriteLine("\n");

            // Inserted above code to ChatGPT and promted "Can you improve this method for my chess board program in C#?"
            // In return it suggested the code in RenderBoard() in ChessBoardAfter.cs
        }
    }
}
