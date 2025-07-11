using YetAnotherBoggler.Boards;

namespace YetAnotherBoggler.Utils;

public sealed class VisitHistory
{
    // Private integer used as a bitmask to track visited positions.
    // Each bit represents whether a position has been visited.
    private int _history;

    public void Visit(Position pos, IBoard board)
    {
        int index = Position.ToIndex(pos, board.Size);
        
        // Set the bit at 'index' position to 1 in _history.
        // Example: if index = 5, (1 << 5) = 0b00100000, so _history |= 0b00100000 sets bit 5.
        _history |= (1 << index);    
    }    
    
    public void UnVisit(Position pos, IBoard board)
    {
        int index = Position.ToIndex(pos, board.Size);
        
        // Sets the bitmask with one at the index we want to unvisit
        // then flips the bitmask to all ones except the previous one is now zero
        // Applies the AND operator to keep all 1's still 1, but change what we want to unvisit to zero
        _history &= ~(1 << index);  
    }

    public bool IsVisited(Position pos, IBoard board)
    {
        int index = Position.ToIndex(pos, board.Size);
        
        // Check whether the bit at 'index' is set to 1.
        // If (_history & (1 << index)) != 0, it means this position has been visited.
        return (_history & (1 << index)) != 0;    
    }

    public VisitHistory Copy()
    {
        VisitHistory copy = new VisitHistory();
        copy._history = this._history;
        return copy;
    }
}