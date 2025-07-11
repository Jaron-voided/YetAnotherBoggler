namespace YetAnotherBoggler.Boards;

public class BoggleBoard : IBoard
{
    private readonly char[,] _letterGrid;
    public int Size { get; }

    public char GetLetter(int x, int y)
    {
        return _letterGrid[x, y];
    }

    private void SetLetter(int x, int y, char letter)
    {
        _letterGrid[x, y] = letter;
    }

    // Should size be hardcoded for 4 since this is "BoggleBoard"??
    public BoggleBoard(int size)
    {
        Size = size;
        _letterGrid = new char[Size, Size];
    }

    public static BoggleBoard Create(char[] letters, int size = 4)
    {
        BoggleBoard board = new BoggleBoard(size);
        board.MakeGrid(letters);

        return board;
    }
    
    internal void MakeGrid(char[] letters)
    {
        int index = 0;
        for (int x = 0; x < Size; x++)
        {
            for (int y = 0; y < Size; y++)
            {
                SetLetter(x, y, letters[index]);
                index++;
            }
        }
    }
    
    public void CopyFrom(IBoard other)
    {
        if (other.Size != Size)
            throw new ArgumentException("Board sizes do not match.");

        for (int x = 0; x < Size; x++)
        {
            for (int y = 0; y < Size; y++)
            {
                SetLetter(x, y, other.GetLetter(x, y));
            }
        }
    }
}