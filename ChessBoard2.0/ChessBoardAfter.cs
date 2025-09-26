using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard2._0
{
    internal class ChessBoardAfter
    {
        public void ReadSize()
        {
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

            // Reasoning for why this is better than before from ChatGPT
            /*
             * What’s improved here:
             * ✅ Quitting is immediate — no nested ifs.
             * ✅ Default values shown in the prompt (B and W).
             * ✅ Input validation is clear and user-friendly.
             * ✅ Safety check so black/white squares can’t be identical (optional but helpful).
             */
        }

        public void RenderBoard(int boardSize, string symbolBlack, string symbolWhite)
        {
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

            // Reasoning for why this is better than before from ChatGPT
            /*
             * Why this is better
             * Removed duplication — just pick black and white once at the top.
             * StringBuilder — faster and cleaner than many Console.Write.
             */
        }
    }
}
