using System.Security.Cryptography;
using System.Text;

namespace ChessBoard
{
    internal class Program
    {
        // Draws a checkerboard of ◻/◼ squares in the console.
        static void Main(string[] args)
        {
            // Prompt user for board size (Swedish) and placing a piece on the board.
            int sizeNumeric;
            do
            {
                Console.WriteLine("Hur stor bräda(max 10)");
                string size = Console.ReadLine();
                if (!int.TryParse(size, out sizeNumeric) || sizeNumeric < 1 || sizeNumeric > 10)
                {
                    Console.WriteLine("För stort eller felaktigt värde. Försök igen.");
                }
            }
            while (sizeNumeric < 1 || sizeNumeric > 10);
            
            Console.WriteLine("Vill du placera en ♕ på Schackbrädan? Ange kordinater: ex. E6");
            string pieceCoordinates = Console.ReadLine();
            
            // Parse coordinate: letter → column index, digit → row number
            char first = pieceCoordinates[0];
            int second = int.Parse(pieceCoordinates.Substring(1));
            string[] rowChar = { "A ", "B ","C ","D ", "E ", "F ", "G ", "H ", "I ", "J "};
            int numFirstCoordinate =  Array.IndexOf(rowChar, first + " ");

            // Column header
            Console.Write("  ");
            for (int z = 1; z <= sizeNumeric; z++)
            { Console.Write(z + " ");    }
            Console.WriteLine();
            
            //Print chessboard with letters on the leftside from the Array
            for (int i = 1; i <= sizeNumeric; i++) 
            {
                Console.OutputEncoding = Encoding.UTF8;
                 Console.Write(rowChar[i-1]);

                // Alternating cells: empty (◻) and filled (◼) square ; ♕ replaces one cell based on the coordinates from user.
                for (int j = 0; j < sizeNumeric; j++)
                {

                    if (i - 1 == (numFirstCoordinate) && j + 1 == second)
                        Console.Write("♕ ");
                    else if ((i + j) % 2 == 0)
                        Console.Write("\u25FC ");
                    else
                        Console.Write("\u25FB ");
                }
                Console.WriteLine();
            }
        }
    }
}
