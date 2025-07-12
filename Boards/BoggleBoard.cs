using System.Collections;

namespace YetAnotherBoggler.Boards;

public class BoggleBoard : IBoard
{
    private readonly char[,] _letterGrid;
    public int Size { get; }

    public IEnumerator<char> GetEnumerator()
    {
        for (int y = 0; y < Size; y++)
        {
            for (int x = 0; x < Size; x++)
            {
                yield return _letterGrid[x, y];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
  
    public char this[int x, int y]
    {
        get => _letterGrid[x, y];
        set => _letterGrid[x, y] = value;
    }

    // Should size be hardcoded for 4 since this is "BoggleBoard"??
    public BoggleBoard(int size)
    {
        Size = size;
        _letterGrid = new char[Size, Size];
    }

    // Do I need a factory method if this is just a base class?
    public static BoggleBoard Create(char[] letters, int size )
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
                this[x, y] = letters[index];
                index++;
            }
        }
    }
}