using YetAnotherBoggler.Boards;
using YetAnotherBoggler.Utils;

namespace YetAnotherBoggler.WordFinding;

public sealed class WordFinder
{
    internal List<string> CompletedWords { get; } = new();
    public void ExploreBoard(WordRabbit wordRabbit, BoggleBoard board)
    {
        wordRabbit.Start(board);
        ExploreBoard(wordRabbit, wordRabbit.CurrentPosition, board);
    }

    public void ExploreBoard(WordRabbit wordRabbit, Position position, BoggleBoard board)
    {
        Direction[] directions = Direction.AllDirections;

        foreach (Direction direction in directions)
        {
            var currentNode = wordRabbit.CurrentNode;
            //WordRabbit babyRabbit = wordRabbit.Breed();
            if (wordRabbit.Move(direction, board, out string? foundWord))
            {
                if (foundWord != null && !CompletedWords.Contains(foundWord))
                    CompletedWords.Add(foundWord);
                
                ExploreBoard(wordRabbit, wordRabbit.CurrentPosition, board);
                
                wordRabbit.Rewind(position, board, currentNode);
            }
        }
    }
} 