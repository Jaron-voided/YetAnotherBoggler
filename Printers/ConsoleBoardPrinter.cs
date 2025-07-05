using YetAnotherBoggler.Interfaces;

namespace YetAnotherBoggler.Printers;

public class ConsoleBoardPrinter : IBoardPrinter
{
    public void DisplayBoard(IBoard board)
    {
        string[,] grid = board.GetLetters();
        int size = board.Size;

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                Console.Write(grid[x, y].PadRight(3));
            }
            
            Console.WriteLine();
        }
    }
}