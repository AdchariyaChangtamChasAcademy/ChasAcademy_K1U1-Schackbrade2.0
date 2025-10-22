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
            // Revised version of ReadSize()

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
                    Console.WriteLine("Invalid input. Please enter a number between 3 and 50.");
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
                    Console.WriteLine("Black and White squares cannot use the same symbol. Try again!");
                    continue;
                }

                // Render the board
                RenderBoard(boardSize, blackSquare, whiteSquare);
            }
        }

        public void RenderBoard(int boardSize, string symbolBlack, string symbolWhite)
        {
            // Revised version of RenderBoard()

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
        }
    }
}
