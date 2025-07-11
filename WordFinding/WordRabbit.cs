using YetAnotherBoggler.Boards;
using YetAnotherBoggler.Utils;

namespace YetAnotherBoggler.WordFinding;

public sealed class WordRabbit
{
    internal VisitHistory History { get; set; }
    internal string WordSoFar { get; set; }
    //internal List<string> Words { get; set; }
    internal Position CurrentPosition { get; set; }
    internal BoggleTrie.TrieNode CurrentNode { get; set; }
    internal int Depth { get; set; }

    public static WordRabbit Create(Position startingPosition, BoggleTrie trie)
    {
        WordRabbit rabbit = new WordRabbit();
        rabbit.History = new VisitHistory();
        rabbit.WordSoFar = "";
        rabbit.CurrentPosition = startingPosition;
        rabbit.CurrentNode = trie.Root;
        rabbit.Depth = 0;
        
        return rabbit;
    }
    
    public string? IsWord()
    {
        if (CurrentNode.IsWord)
        {
            if (CurrentNode.IsWord)
                return WordSoFar;
        }

        return null;
    }
    
    public bool CheckMove(BoggleBoard board, Direction dir)
    {
        // Checks if the move is on the board
        if (!dir.IsValidMove(CurrentPosition, board))
            return false;

        var positionToMoveTo = CurrentPosition.TryMove(dir);
        if (History.IsVisited(positionToMoveTo, board))
            return false;

        return true;
    }
    
    public bool CheckLetter(string letter)
    {
        char c = letter[0];
        
        if (CurrentNode.HasChild(c))
            return true;
        
        return false;
    }

    public void Start(BoggleBoard board)
    {
        History.Visit(CurrentPosition, board);
        string letter = board.GetLetter(CurrentPosition.PX, CurrentPosition.PY);
        WordSoFar += letter;
        CurrentNode = CurrentNode.Traverse(letter[0]);
        Depth++;
    }

    public bool Move(Direction dir, BoggleBoard board, out string? foundWord)
    {
        foundWord = null;
        
        if (!CheckMove(board, dir))
            return false;
        
        Position positionToMoveTo = CurrentPosition.TryMove(dir);
        string letter = board.GetLetter(positionToMoveTo.PX, positionToMoveTo.PY);

        if (!CheckLetter(letter))
            return false;
        
        var nextNode = CurrentNode.Traverse(letter[0]);
        if (nextNode == null)
            return false;
        
        WordSoFar += letter;

        CurrentPosition.Move(dir);
       // CurrentPosition = positionToMoveTo;
        CurrentNode = nextNode;
        History.Visit(CurrentPosition, board);

        foundWord = IsWord();
        Depth++;
        
        return true;
    }

    public WordRabbit Breed()
    {
        WordRabbit babyRabbit = new WordRabbit();

        babyRabbit.History = this.History.Copy();
        babyRabbit.WordSoFar = this.WordSoFar;
        babyRabbit.CurrentPosition = this.CurrentPosition;
        babyRabbit.CurrentNode = this.CurrentNode;

        return babyRabbit;
    }

    // I had to make TrieNode public to pass this parameter??
    public void Rewind(Position position, IBoard board, BoggleTrie.TrieNode previousNode)
    {
        History.UnVisit(position, board);
        Depth--;
        WordSoFar = WordSoFar.Substring(0, Depth);
        CurrentPosition = position;
        CurrentNode = previousNode;
    }
}