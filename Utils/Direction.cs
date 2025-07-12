using YetAnotherBoggler.Boards;

namespace YetAnotherBoggler.Utils;

public struct Direction
{
    public int DX { get; }
    public int DY { get; }

    public Direction(int dx, int dy)
    {
        DX = dx;
        DY = dy;
    }

    public static readonly Direction[] AllDirections = new[]
    {
        new Direction(-1, -1),  // Up Left
        new Direction(0, -1),   // Up
        new Direction(1, -1),   // Up Right
        new Direction(-1, 0),   // Left
        new Direction(1, 0),    // Right
        new Direction(-1, 1),   // Down Left
        new Direction(0, 1),    // Down
        new Direction(1, 1)     // Down Right
    };
    
    public static readonly Direction[] Right = new[]
    {
        new Direction(1, 0),    // Right
        new Direction(1, 0),    // Right
        new Direction(1, 0),    // Right
    };
    

    public bool IsValidMove(Position pos, IBoard board)
    {
        int newX = pos.PX + DX;
        int newY = pos.PY + DY;

        if (newX < 0 || newX >= board.Size || newY < 0 || newY >= board.Size)
            return false;

        return true;
    }
}