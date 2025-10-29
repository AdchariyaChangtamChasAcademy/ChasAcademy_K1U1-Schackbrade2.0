using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Dynamic;
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
                    // Reflection: A bit nicer to have a affirmed end rather then just closing the app.
                    Console.WriteLine("Goodbye!");
                    break;
                }

                // Validate board size

                /* 
                 * Reflection:
                 * Smarter and a bit more efficient to have a generalised checker for common faulty inputs
                 * and better guide for the user rather then just "(3-50).
                 */
                if (!int.TryParse(input, out int boardSize) || boardSize < 3 || boardSize > 50)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 3 and 50.");
                    continue;
                }


                /*
                 * Reflection:
                 * - Liked the given console print better than mine.
                 * 
                 * - Better to set the default colored squares here 
                 *   near the input so you know earlier when it happens.
                 *   
                 * - AI checking for null or white space made me also 
                 *   want to check for capital letter when choosing default.
                 */

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

             /*
             * Reflection: 
             * Checking the symbol once rather than for each time in the loop
             * is better for performance and is cleaner in this ternary operator
             * form rather than the former basic if statement.
             */

            var black = string.IsNullOrEmpty(symbolBlack) ? "\u25A0" : symbolBlack;
            var white = string.IsNullOrEmpty(symbolWhite) ? "\u25A1" : symbolWhite;

            var sb = new StringBuilder();
            Console.OutputEncoding = Encoding.UTF8;

            // Reflection: Naming it row and col is more understandable than i and j
            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    /*
                    * Reflection: 
                    * This line feels cleaner and is more intuitive to understand
                    * when, the modulus operator to check odd or even, is in the
                    * same line as the append happens. Instead of being before/above.
                    */
                    sb.Append((row + col) % 2 == 0 ? black : white);
                }
                sb.AppendLine(); // newline at end of row
            }

            /*
            * Reflection: 
            * Feels cleaner to have one appended string rather then
            * having to call Console.Write/WriteLine several times.
            */

            var boardString = sb.ToString();
            
            // Output to console
            Console.WriteLine(boardString);
        }
    }
}
