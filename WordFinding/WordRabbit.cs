using YetAnotherBoggler.Boards;
using YetAnotherBoggler.Utils;

namespace YetAnotherBoggler.WordFinding;

public class WordRabbit
{
    internal VisitHistory History { get; set; }
    internal string WordSoFar { get; set; }
    internal List<string> Words { get; set; }
    internal Position CurrentPosition { get; set; }
    internal BoggleTrie Trie { get; set; }

    public static WordRabbit Create(Position startingPosition, BoggleTrie trie)
    {
        WordRabbit rabbit = new WordRabbit();
        rabbit.History = new VisitHistory();
        rabbit.WordSoFar = "";
        rabbit.Words = new List<string>();
        rabbit.CurrentPosition = startingPosition;
        rabbit.Trie = trie;
        
        return rabbit;
    }
    
    public bool IsWord()
    {
        if (Trie.CurrentNode.IsWord)
        {
            Words.Append(WordSoFar);
            //WordSoFar = "";
            return true;
        }

        return false;
    }
    
    public bool CheckMove(BoggleBoard board, Direction dir)
    {
        // Checks if the move is on the board
        if (dir.IsValidMove(CurrentPosition, board))
            return false;

        var positionToMoveTo = CurrentPosition.Move(dir);
        if (History.IsVisited(positionToMoveTo, board))
            return false;

        return true;
    }
    
    public bool CheckLetter(string letter)
    {
        char c = letter[0];
        
        if (Trie.CurrentNode.HasChild(c))
            return true;
        
        return false;
    }

    public void Move(Direction dir, BoggleBoard board)
    {
        if (!CheckMove(board, dir))
            return;
        
        Position positionToMoveTo = CurrentPosition.Move(dir);
        string letter = board.LetterGrid[positionToMoveTo.PX, positionToMoveTo.PY];

        if (!CheckLetter(letter))
            return;

        CurrentPosition = positionToMoveTo;
        Trie.Traverse(letter[0]);
        History.Visit(CurrentPosition, board);

        IsWord();

    }
}