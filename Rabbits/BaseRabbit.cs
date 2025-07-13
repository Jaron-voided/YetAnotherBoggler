using YetAnotherBoggler.Boards;
using YetAnotherBoggler.Utils;
using YetAnotherBoggler.WordFinding;

namespace YetAnotherBoggler.Rabbits;

public class BaseRabbit : IRabbit
{
    public char[] WordSoFar { get; set; }
    public Position CurrentPosition { get; set; }
    public BoggleTrie.TrieIterator Iterator { get; set; }
    
    public bool CheckLetter(char c)
    {
        return Iterator.HasChild(c);
    }
}