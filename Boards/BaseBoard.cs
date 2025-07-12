using System.Collections;

namespace YetAnotherBoggler.Boards;

public class BaseBoard : IBoard
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

    public BaseBoard(int size)
    {
        Size = size;
        _letterGrid = new char[Size, Size];
    }

    // Do I need a factory method if this is just a base class?
    public static BaseBoard Create(char[] letters, int size )
    {
        BaseBoard board = new BaseBoard(size);
        board.MakeGrid(letters);

        return board;
    }
    
    internal void MakeGrid(char[] letters)
    {
        int index = 0;
        for (int y = 0; y < Size; y++)
        {
            for (int x = 0; x < Size; x++)
            {
                this[x, y] = letters[index];
                index++;
            }
        }
    }
}