using YetAnotherBoggler.Boards;
using YetAnotherBoggler.Interfaces;
using YetAnotherBoggler.Utils;

namespace YetAnotherBoggler.WordFinding;

public class WordRabbit
{
    internal VisitHistory History { get; set; }
    internal string WordSoFar { get; set; }
    // Made this static so all rabbits add to the same list
    // Might cause problems eventually??
    internal static List<string> Words { get; set; }
    internal Position CurrentPosition { get; set; }
    internal BoggleTrie Trie { get; set; }

    public static WordRabbit Create(Position startingPosition, BoggleTrie trie)
    {
        WordRabbit rabbit = new WordRabbit();
        rabbit.History = new VisitHistory();
        rabbit.WordSoFar = "";
        Words = new List<string>();
        rabbit.CurrentPosition = startingPosition;
        rabbit.Trie = trie;
        
        return rabbit;
    }
    
    public bool IsWord()
    {
        if (Trie.CurrentNode.IsWord)
        {
            if (!Words.Contains(WordSoFar))
                Words.Add(WordSoFar);
            //WordSoFar = "";
            return true;
        }

        return false;
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
        
        if (Trie.CurrentNode.HasChild(c))
            return true;
        
        return false;
    }

    public void Start(BoggleBoard board)
    {
        History.Visit(CurrentPosition, board);
        string letter = board.LetterGrid[CurrentPosition.PX, CurrentPosition.PY];
        WordSoFar += letter;
        Trie.Traverse(letter[0]);
    }

    public bool Move(Direction dir, BoggleBoard board)
    {
        if (!CheckMove(board, dir))
            return false;
        
        Position positionToMoveTo = CurrentPosition.TryMove(dir);
        string letter = board.LetterGrid[positionToMoveTo.PX, positionToMoveTo.PY];

        if (!CheckLetter(letter))
            return false;
        
        WordSoFar += letter;

        //CurrentPosition.Move(dir);
        CurrentPosition = positionToMoveTo;
        Trie.Traverse(letter[0]);
        History.Visit(CurrentPosition, board);

        IsWord();
        return true;
    }

    public WordRabbit Breed()
    {
        WordRabbit babyRabbit = new WordRabbit();

        babyRabbit.History = this.History.Copy();
        babyRabbit.WordSoFar = this.WordSoFar;
        //babyRabbit.Words = this.Words;
        babyRabbit.CurrentPosition = this.CurrentPosition;
        babyRabbit.Trie = this.Trie;

        return babyRabbit;
    }
}