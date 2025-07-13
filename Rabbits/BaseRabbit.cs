using YetAnotherBoggler.Boards;
using YetAnotherBoggler.Utils;
using YetAnotherBoggler.WordFinding;

namespace YetAnotherBoggler.Rabbits;

public class BaseRabbit : IRabbit
{
    //private VisitHistory History { get; set; }
    protected char[] WordSoFar { get; set; }
    public Position CurrentPosition { get; set; }

    protected BoggleTrie.TrieIterator Iterator { get; set; }
    //public int Depth { get; set; }

    /*
    public static BaseRabbit Create(Position startingPosition, BoggleTrie trie)
    {
        BaseRabbit rabbit = new BaseRabbit();
        //rabbit.History = new VisitHistory();
        rabbit.WordSoFar = new char[16];
        rabbit.CurrentPosition = startingPosition;
        rabbit.Iterator = trie.GetIterator();
        //rabbit.Depth = 0;
        
        return rabbit;
    }
    */
    
    /*
    public string? IsWord(int depth)
    {
        if (Iterator.IsWord())
                return new string(WordSoFar, 0, depth);
        
        return null;
    }
    */
    
    /*public bool CheckMove(IBoard board, Direction dir)
    {
        // Checks if the move is on the board
        if (!dir.IsValidMove(CurrentPosition, board))
            return false;

        var positionToMoveTo = CurrentPosition.TryMove(dir);
        if (History.IsVisited(positionToMoveTo, board))
            return false;

        return true;
    }*/
    
    public bool CheckLetter(char c)
    {
        return Iterator.HasChild(c);
    }

    /*public void AddToWordSoFar(char c)
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
    }*/

    /*public void Start(IBoard board)
    {
        History.Visit(CurrentPosition, board);
        char letter = board[CurrentPosition.PX, CurrentPosition.PY];
        AddToWordSoFar(letter);
        
        // Is this correct? Can I use the bool it returns somehow??
        Iterator.Traverse(letter);
    }*/

    /*public bool Move(Direction dir, IBoard board, out string? foundWord)
    {
        foundWord = null;
        
        if (!CheckMove(board, dir))
            return false;
        
        Position positionToMoveTo = CurrentPosition.TryMove(dir);
        char letter = board[positionToMoveTo.PX, positionToMoveTo.PY];

        if (!CheckLetter(letter))
            return false;
        
        /*var nextNode = CurrentNode.Traverse(letter);
        if (nextNode == null)
            return false;#1#
        
        AddToWordSoFar(letter);

        CurrentPosition = positionToMoveTo;
        //CurrentPosition.Move(dir);
        Iterator.Traverse(letter);
        History.Visit(CurrentPosition, board);

        foundWord = IsWord();
        
        return true;
    }*/

    // I had to make TrieNode public to pass this parameter??
    /*public void Rewind(Position position, IBoard board)
    {
        History.UnVisit(position, board);
        Depth--;
        Array.Clear(WordSoFar, Depth, WordSoFar.Length - Depth);
        CurrentPosition = position;
        Iterator.Rewind();
    }*/
}