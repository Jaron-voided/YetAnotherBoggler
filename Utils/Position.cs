namespace YetAnotherBoggler.Utils;

public struct Position
{
    public int PX { get; set; }
    public int PY { get; set; }

    public Position(int x, int y)
    {
        PX = x;
        PY = y;
    }

    public static int ToIndex(Position pos, int boardWidth)
    {
        return pos.PX + (pos.PY * boardWidth);
    }

    public static (int x, int y) FromIndex(int index, int boardWidth)
    {
        int x = index % boardWidth;
        int y = index / boardWidth;
        return (x, y);
    }

    public Position Move(Direction dir)
    {
        var position = new Position(PX, PY);
        position.PX += dir.DX;
        position.PY += dir.DY;
        
        return position;
    }
}