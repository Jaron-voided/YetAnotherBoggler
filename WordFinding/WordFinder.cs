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
        
        //return WordRabbit.Words;
    }

    public void ExploreBoard(WordRabbit wordRabbit, Position position, BoggleBoard board)
    {
        Direction[] directions = Direction.AllDirections;

        foreach (Direction direction in directions)
        {
            WordRabbit babyRabbit = wordRabbit.Breed();
            if (babyRabbit.Move(direction, board, out string? foundWord))
            {
                if (foundWord != null && !CompletedWords.Contains(foundWord))
                    CompletedWords.Add(foundWord);
                
                ExploreBoard(babyRabbit, babyRabbit.CurrentPosition, board);
            }
        }
    }
} 