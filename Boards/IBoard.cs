namespace YetAnotherBoggler.Boards;

public interface IBoard
{
    int Size { get;  }
    char GetLetter(int x, int y);
    void CopyFrom(IBoard otherBoard);
}