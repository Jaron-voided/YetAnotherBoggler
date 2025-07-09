using YetAnotherBoggler.Boards;
using YetAnotherBoggler.Utils;

namespace YetAnotherBoggler.WordFinding;

public sealed class WordFinder
{
    public static void ExploreBoard(WordRabbit wordRabbit, BoggleBoard board)
    {
        wordRabbit.Start(board);
        ExploreBoard(wordRabbit, wordRabbit.CurrentPosition, board);
        
        //return WordRabbit.Words;
    }

    public static void ExploreBoard(WordRabbit wordRabbit, Position position, BoggleBoard board)
    {
        Direction[] directions = Direction.AllDirections;

        foreach (Direction direction in directions)
        {
            WordRabbit babyRabbit = wordRabbit.Breed();
            if (babyRabbit.Move(direction, board))
                ExploreBoard(babyRabbit, babyRabbit.CurrentPosition, board);
        }
    }
} 