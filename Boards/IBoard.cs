using System.Collections;

namespace YetAnotherBoggler.Boards;

public interface IBoard : IEnumerable<char>
{
    int Size { get;  }
    char this[int x, int y] { get; set; }
}