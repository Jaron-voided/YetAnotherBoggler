using YetAnotherBoggler.Boards;
using YetAnotherBoggler.Interfaces;
using YetAnotherBoggler.Utils;

namespace YetAnotherBoggler.WordFinding;

public class WordFinder
{
    Direction[] directions = Direction.AllDirections;
    public List<string> ExploreBoard(WordRabbit wordRabbit, BoggleBoard board)
    {
        wordRabbit.Start(board);
        ExploreBoard(wordRabbit, wordRabbit.CurrentPosition, board);
        
        return wordRabbit.Words;
    }

    public void ExploreBoard(WordRabbit wordRabbit, Position position, BoggleBoard board)
    {
        foreach (Direction direction in directions)
        {
            WordRabbit babyRabbit = wordRabbit.Breed();
            babyRabbit.Move(direction, board);
            ExploreBoard(babyRabbit, babyRabbit.CurrentPosition, board);
        }
    }
}