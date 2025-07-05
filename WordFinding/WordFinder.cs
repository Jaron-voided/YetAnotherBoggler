using YetAnotherBoggler.Interfaces;
using YetAnotherBoggler.Utils;

namespace YetAnotherBoggler.WordFinding;

public class WordFinder
{

    public string BuildWord(BoggleTrie trie, Position pos, string wordSoFar, IBoard board)
    {
        
    }
    public bool CheckLetter(string letter, BoggleTrie trie)
    {
        char c = letter[0];
        
        if (trie.CurrentNode.HasChild(c))
            return true;
        
        return false;
    }

    public bool CheckMove(IBoard board, VisitHistory history, BoggleTrie trie, Position pos, Direction dir)
    {
        // Checks if the move is on the board
        if (dir.IsValidMove(pos, board))
            return false;

        var positionToMoveTo = pos.Move(dir);
        if (history.IsVisited(positionToMoveTo, board))
            return false;

        return true;
    }

    public bool IsWord(string wordSoFar, BoggleTrie trie, out string word)
    {
        wordSoFar += trie.CurrentNode.Letter;
        if (trie.CurrentNode.IsWord)
        {
            word = wordSoFar;
            return true;
        }

        word = null;
        return false;
    }
    
}