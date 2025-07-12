using YetAnotherBoggler.Boards;
using YetAnotherBoggler.Utils;

namespace YetAnotherBoggler.WordFinding;

public interface IRabbit
{
    Position CurrentPosition { get; set; }
    int Depth { get; set; }

    void Start(IBoard board);
    bool Move(Direction dir, IBoard board, out string? foundWord);
    bool CheckMove(IBoard board, Direction dir);
    bool CheckLetter(char c);
    string? IsWord();
    void Rewind(Position position, IBoard board);
}