using YetAnotherBoggler.Boards;
using YetAnotherBoggler.Utils;

namespace YetAnotherBoggler.WordFinding;

public sealed class WordRabbit
{
    internal VisitHistory History { get; set; }
    private char[] WordSoFar { get; set; }
    //internal string WordSoFar { get; set; }
    internal Position CurrentPosition { get; set; }
    internal BoggleTrie.TrieNode CurrentNode { get; set; }
    internal int Depth { get; set; }

    public static WordRabbit Create(Position startingPosition, BoggleTrie trie)
    {
        WordRabbit rabbit = new WordRabbit();
        rabbit.History = new VisitHistory();
        rabbit.WordSoFar = new char[16];
        //rabbit.WordSoFar = "";
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
                return new string(WordSoFar, 0, Depth);
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
    
    public bool CheckLetter(char c)
    {
        if (CurrentNode.HasChild(c))
            return true;
        
        return false;
    }

    public void AddToWordSoFar(char c)
    {
        WordSoFar[Depth] = c;
        if (c == 'Q')
        {
            // Add another depth because I'm adding an extra letter
            Depth++;
            WordSoFar[Depth] = 'U';
        }
        // Took depth++ out of Start and Move
        Depth++;
    }

    public void Start(BoggleBoard board)
    {
        History.Visit(CurrentPosition, board);
        char letter = board.GetLetter(CurrentPosition.PX, CurrentPosition.PY);
        AddToWordSoFar(letter);
        CurrentNode = CurrentNode.Traverse(letter);
    }

    public bool Move(Direction dir, BoggleBoard board, out string? foundWord)
    {
        foundWord = null;
        
        if (!CheckMove(board, dir))
            return false;
        
        Position positionToMoveTo = CurrentPosition.TryMove(dir);
        char letter = board.GetLetter(positionToMoveTo.PX, positionToMoveTo.PY);

        if (!CheckLetter(letter))
            return false;
        
        var nextNode = CurrentNode.Traverse(letter);
        if (nextNode == null)
            return false;
        
        AddToWordSoFar(letter);

        CurrentPosition.Move(dir);
        CurrentNode = nextNode;
        History.Visit(CurrentPosition, board);

        foundWord = IsWord();
        
        return true;
    }

    // I had to make TrieNode public to pass this parameter??
    public void Rewind(Position position, IBoard board, BoggleTrie.TrieNode previousNode)
    {
        History.UnVisit(position, board);
        Depth--;
        Array.Clear(WordSoFar, Depth, WordSoFar.Length - Depth);
        //WordSoFar = WordSoFar.Substring(0, Depth);
        CurrentPosition = position;
        CurrentNode = previousNode;
    }
}