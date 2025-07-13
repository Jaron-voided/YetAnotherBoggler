using YetAnotherBoggler.Boards;
using YetAnotherBoggler.Rabbits;
using YetAnotherBoggler.Utils;

namespace YetAnotherBoggler.WordFinding;

public class BreedingRabbit : BaseRabbit
{
    internal VisitHistory History { get; set; }
    internal static List<string> Words { get; set; } = new List<string>();
    internal string WordSoFar { get; set; }

    public static BreedingRabbit Create(Position startingPosition, BoggleTrie trie)
    {
        BreedingRabbit rabbit = new BreedingRabbit();
        
        rabbit.History = new VisitHistory();
        rabbit.WordSoFar = "";
        rabbit.CurrentPosition = startingPosition;
        rabbit.Iterator = trie.GetIterator();
        
        return rabbit;
    }
    
    public bool IsWord()
    {
        return Iterator.IsWord();
    }

    public void AddWord()
    {
        if (IsWord())
        {
            Words.Add(WordSoFar);
        }
    }
    public bool CheckMove(IBoard board, Direction dir)
    {
        // Checks if the move is on the board
        if (!dir.IsValidMove(CurrentPosition, board))
            return false;

        var positionToMoveTo = CurrentPosition.TryMove(dir);
        if (History.IsVisited(positionToMoveTo, board))
            return false;

        return true;
    }

    public void Start(IBoard board)
    {
        History.Visit(CurrentPosition, board);
        char letter = board[CurrentPosition.PX, CurrentPosition.PY];
        WordSoFar += letter;
        Iterator.Traverse(letter);
    }

    public bool Move(Direction dir, IBoard board, out string? foundWord)
    {
        foundWord = null;
        
        if (!CheckMove(board, dir))
            return false;
        
        Position positionToMoveTo = CurrentPosition.TryMove(dir);
        char letter = board[positionToMoveTo.PX, positionToMoveTo.PY];

        if (!CheckLetter(letter))
            return false;
        
        WordSoFar += letter;

        CurrentPosition = positionToMoveTo;
        Iterator.Traverse(letter);
        History.Visit(CurrentPosition, board);

        AddWord();
        
        return true;
    }

    public BreedingRabbit Breed()
    {
        BreedingRabbit babyRabbit = new BreedingRabbit();

        babyRabbit.History = this.History.Copy();
        babyRabbit.WordSoFar = this.WordSoFar;
        babyRabbit.CurrentPosition = this.CurrentPosition;
        babyRabbit.Iterator = this.Iterator;

        return babyRabbit;
    }
}