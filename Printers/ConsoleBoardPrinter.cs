using YetAnotherBoggler.Boards;

namespace YetAnotherBoggler.Printers;

public class ConsoleBoardPrinter : IBoardPrinter
{
    public void DisplayBoard(IBoard board)
    {
        int size = board.Size;

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                char letter = board[x, y];
                string QU = "QU";
                if (letter == 'Q')
                    Console.Write(QU);
                else
                    Console.Write(board[x, y]);
            }
            
            Console.WriteLine();
        }
    }
}