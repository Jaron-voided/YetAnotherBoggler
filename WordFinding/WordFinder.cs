using YetAnotherBoggler.Boards;
using YetAnotherBoggler.Rabbits;
using YetAnotherBoggler.Utils;

namespace YetAnotherBoggler.WordFinding;

public sealed class WordFinder
{
    // Had to make CompletedWords public for testing
    public List<string> CompletedWords { get; } = new();
    public void ExploreBoard(IRabbit wordRabbit, BaseBoard board)
    {
        wordRabbit.Start(board);
        ExploreBoard(wordRabbit, wordRabbit.CurrentPosition, board);
    }

    public void ExploreBoard(IRabbit wordRabbit, Position position, BaseBoard board)
    {
        Direction[] directions = Direction.AllDirections;
        //Direction[] directions = Direction.Right;
        //Direction[] directions = Direction.Down;
        foreach (Direction direction in directions)
        {
            // I don't need this anymore??
            //var currentNode = wordRabbit.CurrentNode;
            if (wordRabbit.Move(direction, board, out string? foundWord))
            {
                if (foundWord != null && !CompletedWords.Contains(foundWord))
                    CompletedWords.Add(foundWord);
                
                ExploreBoard(wordRabbit, wordRabbit.CurrentPosition, board);
                
                wordRabbit.Rewind(position, board);
            }
        }
    }
} 