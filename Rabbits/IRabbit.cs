using YetAnotherBoggler.Boards;
using YetAnotherBoggler.Utils;
using YetAnotherBoggler.WordFinding;

namespace YetAnotherBoggler.Rabbits;

public interface IRabbit
{
    // I can't make interface methods have different parameters for different rabbits, can I?
    // Adding members here forces me to make them public, is this ok?
    Position CurrentPosition { get; set; }
    BoggleTrie.TrieIterator Iterator { get; set; }
    char[] WordSoFar { get; set; }
    bool CheckLetter(char c);
}