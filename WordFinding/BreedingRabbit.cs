using YetAnotherBoggler.Boards;
using YetAnotherBoggler.Utils;

namespace YetAnotherBoggler.WordFinding;

public class BreedingRabbit : IRabbit
{
    public Position CurrentPosition { get; set; }
    public int Depth { get; set; }
    
    public void Start(IBoard board)
    {
        throw new NotImplementedException();
    }

    public bool Move(Direction dir, IBoard board, out string? foundWord)
    {
        throw new NotImplementedException();
    }

    public bool CheckMove(IBoard board, Direction dir)
    {
        throw new NotImplementedException();
    }

    public bool CheckLetter(char c)
    {
        throw new NotImplementedException();
    }

    public string? IsWord()
    {
        throw new NotImplementedException();
    }

    public void Rewind(Position position, IBoard board)
    {
        throw new NotImplementedException();
    }
}