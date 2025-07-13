using YetAnotherBoggler.Boards;
using YetAnotherBoggler.Utils;
using YetAnotherBoggler.WordFinding;

namespace YetAnotherBoggler.Rabbits;

public class RecursiveRabbit : BaseRabbit
{
    public static RecursiveRabbit Create(Position startingPosition, BoggleTrie trie)
    {
        RecursiveRabbit rabbit = new RecursiveRabbit();
        rabbit.WordSoFar = new char[16];
        rabbit.CurrentPosition = startingPosition;
        rabbit.Iterator = trie.GetIterator();
        
        return rabbit;
    }
    
    public string? IsWord(int depth)
    {
        if (Iterator.IsWord())
            return new string(WordSoFar, 0, depth);
        
        return null;
    }
    
    
    public bool CheckMove(IBoard board, Direction dir, VisitHistory history)
    {
        // Checks if the move is on the board
        if (!dir.IsValidMove(CurrentPosition, board))
            return false;

        var positionToMoveTo = CurrentPosition.TryMove(dir);
        if (history.IsVisited(positionToMoveTo, board))
            return false;

        return true;
    } 
    
    public void AddToWordSoFar(char c, int depth)
    {
        WordSoFar[depth] = c;
        if (c == 'Q')
        {
          // Add another depth because I'm adding an extra letter
          depth++;
          WordSoFar[depth] = 'U';
        }
        // Took depth++ out of Start and Move
        depth++;
    }

    public void Start(IBoard board, VisitHistory history, int depth)
    {
        history.Visit(CurrentPosition, board);
        char letter = board[CurrentPosition.PX, CurrentPosition.PY];
        AddToWordSoFar(letter, depth);

        // Is this correct? Can I use the bool it returns somehow??
        Iterator.Traverse(letter);
    }

    public bool Move(Direction dir, IBoard board, out string? foundWord, VisitHistory history, int depth)
    {
        foundWord = null;

        if (!CheckMove(board, dir, history))
            return false;

        Position positionToMoveTo = CurrentPosition.TryMove(dir);
        char letter = board[positionToMoveTo.PX, positionToMoveTo.PY];

        if (!CheckLetter(letter))
            return false;

        AddToWordSoFar(letter, depth);

        CurrentPosition = positionToMoveTo;
        Iterator.Traverse(letter);
        history.Visit(CurrentPosition, board);

        foundWord = IsWord(depth);

        return true;
    }
}