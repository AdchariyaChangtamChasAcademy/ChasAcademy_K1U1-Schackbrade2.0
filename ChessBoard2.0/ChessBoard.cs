using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ChessBoard2._0
{
    public class ChessBoard
    {
        public ChessBoard() { }

        public void ReadSize()
        {
            //// Code BEFORE AI START ////
            /*
            // LOOP START
            while (true)
            {
                Console.WriteLine("Size of board? (3-50) or [Q] to quit");
                string input = Console.ReadLine();

                if(string.Equals(input, "q", StringComparison.OrdinalIgnoreCase))
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
            */
            //// Code BEFORE AI END ////

            // Inserted above code to ChatGPT and promted "Can you improve this method for my chess board program in C#?"
            // In return it suggested the following solution

            //// Code AFTER AI START ////
            /*
            while (true)
            {
                Console.WriteLine("Size of board? (3–50) or [Q] to quit");
                string input = Console.ReadLine();

                // Exit if user chooses to quit
                if (string.Equals(input, "q", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                // Validate board size
                if (!int.TryParse(input, out int boardSize) || boardSize < 3 || boardSize > 50)
                {
                    Console.WriteLine("❌ Invalid input. Please enter a number between 3 and 50.");
                    continue;
                }

                // Ask for black square symbol
                Console.WriteLine($"\nInput symbol for BLACK squares (default: 'B'):");
                Console.Write("B: ");
                string blackSquare = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(blackSquare))
                    blackSquare = "B";

                // Ask for white square symbol
                Console.WriteLine($"\nInput symbol for WHITE squares (default: 'W'):");
                Console.Write("W: ");
                string whiteSquare = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(whiteSquare))
                    whiteSquare = "W";

                // Prevent same symbols (optional safeguard)
                if (blackSquare == whiteSquare)
                {
                    Console.WriteLine("❌ Black and White squares cannot use the same symbol. Try again!");
                    continue;
                }

                // Render the board
                RenderBoard(boardSize, blackSquare, whiteSquare);
            }
            */
            //// Code AFTER AI END ////

            // Reasoning for why it is better from ChatGPT
            /*
             * What’s improved here:
             * ✅ Quitting is immediate — no nested ifs.
             * ✅ Default values shown in the prompt (B and W).
             * ✅ Input validation is clear and user-friendly.
             * ✅ Safety check so black/white squares can’t be identical (optional but helpful).
             */

            //// USED VERSION START ////
            while (true)
            {
                Console.WriteLine("Size of board? (3–50) or [Q] to quit");
                string input = Console.ReadLine();

                // Exit if user chooses to quit
                if (string.Equals(input, "q", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                // Validate board size
                if (!int.TryParse(input, out int boardSize) || boardSize < 3 || boardSize > 50)
                {
                    Console.WriteLine("❌ Invalid input. Please enter a number between 3 and 50.");
                    continue;
                }

                // Ask for black square symbol
                Console.WriteLine($"\nInput symbol for BLACK squares (default: 'B'):");
                Console.Write("B: ");
                string blackSquare = Console.ReadLine();

                // ALTER: Added check for non case sensitive check for the letter "b" that can be used as default as well as empty input
                if (string.IsNullOrWhiteSpace(blackSquare) || string.Equals(blackSquare, "b", StringComparison.OrdinalIgnoreCase))
                {
                    // ALTER: Swapped "B" to "\u25A0" because I wanted a black square symbol to be default and not the letter B
                    blackSquare = "\u25A0";
                }

                // Ask for white square symbol
                Console.WriteLine($"\nInput symbol for WHITE squares (default: 'W'):");
                Console.Write("W: ");
                string whiteSquare = Console.ReadLine();

                // ALTER: Added check for non case sensitive check for the letter "w" that can be used as default as well as empty input
                if (string.IsNullOrWhiteSpace(whiteSquare) || string.Equals(whiteSquare, "w", StringComparison.OrdinalIgnoreCase))
                {
                    // ALTER: Swapped "B" to "\u25A0" because I wanted a white square symbol to be default and not the letter W
                    whiteSquare = "\u25A1";
                }

                // Prevent same symbols (optional safeguard)
                if (blackSquare == whiteSquare)
                {
                    Console.WriteLine("❌ Black and White squares cannot use the same symbol. Try again!");
                    continue;
                }

                // Render the board
                RenderBoard(boardSize, blackSquare, whiteSquare);
            }
            //// USED VERSION END ////
        }

        public void RenderBoard(int boardSize, string symbolBlack, string symbolWhite)
        {
            //// Code BEFORE AI START ////
            /*
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
            */
            //// Code BEFORE AI END ////

            // Inserted above code to ChatGPT and promted "Can you improve this method for my chess board program in C#?"
            // In return it suggested the following solution

            //// Code AFTER AI START ////
            /*
            // Default symbols if none are provided
            var black = string.IsNullOrEmpty(symbolBlack) ? "\u25A0" : symbolBlack;
            var white = string.IsNullOrEmpty(symbolWhite) ? "\u25A1" : symbolWhite;

            var sb = new StringBuilder();
            Console.OutputEncoding = Encoding.UTF8;

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    sb.Append((row + col) % 2 == 0 ? black : white);
                }
                sb.AppendLine(); // newline at end of row
            }

            var boardString = sb.ToString();

            // Output to console
            Console.WriteLine(boardString);
            */
            //// Code AFTER AI END ////

            // Reasoning for why it is better from ChatGPT
            /*
             * Why this is better
             * Removed duplication — just pick black and white once at the top.
             * StringBuilder — faster and cleaner than many Console.Write.
             */

            //// USED VERSION START ////
            // Default symbols if none are provided
            var black = string.IsNullOrEmpty(symbolBlack) ? "\u25A0" : symbolBlack;
            var white = string.IsNullOrEmpty(symbolWhite) ? "\u25A1" : symbolWhite;

            var sb = new StringBuilder();
            Console.OutputEncoding = Encoding.UTF8;

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    sb.Append((row + col) % 2 == 0 ? black : white);
                }
                sb.AppendLine(); // newline at end of row
            }

            var boardString = sb.ToString();

            // Output to console
            Console.WriteLine(boardString);
            //// USED VERSION END ////
        }
    }
}
