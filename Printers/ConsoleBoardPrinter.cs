using YetAnotherBoggler.Boards;
using YetAnotherBoggler.Interfaces;

namespace YetAnotherBoggler.Printers;

public class ConsoleBoardPrinter : IBoardPrinter
{
    public void DisplayBoard(BoggleBoard board)
    {
        int size = board.Size;

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                Console.Write(board.LetterGrid[x, y].PadRight(3));
            }
            
            Console.WriteLine();
        }
    }
}