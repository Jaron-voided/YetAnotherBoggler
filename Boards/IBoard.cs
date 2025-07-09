namespace YetAnotherBoggler.Boards;

public interface IBoard
{
    int Size { get;  }
    string GetLetter(int x, int y);
    void CopyFrom(IBoard otherBoard);
}