using YetAnotherBoggler.Interfaces;

namespace YetAnotherBoggler.Boards;

public class BoggleBoard : IBoard
{
    public int Size { get; set; } = 4;
    public string[,] LetterGrid { get; set; }

    public static BoggleBoard Create(string[] letters, int size = 4)
    {
        BoggleBoard board = new BoggleBoard();
        board.Size = size;
        board.LetterGrid = board.MakeGrid(letters);

        return board;
    }
    public string[,] MakeGrid(string[] letters)
    {
        string[,] grid = new string[Size, Size];

        int index = 0;
        for (int x = 0; x < Size; x++)
        {
            for (int y = 0; y < Size; y++)
            {
                grid[x, y] = letters[index];
                index++;
            }
        }

        return grid;
    }
}