using YetAnotherBoggler.Boards;
using YetAnotherBoggler.Interfaces;
using YetAnotherBoggler.Utils;

namespace YetAnotherBoggler.WordFinding;

public class WordFinder
{

    public string BuildWord(VisitHistory history, Direction dir, BoggleTrie trie, Position pos, string wordSoFar, BoggleBoard board)
    {
        Position newPosition = pos.Move(dir);
        string letterToCheck = board.LetterGrid[newPosition.PX, newPosition.PY];
        if (CheckLetter(letterToCheck, trie) && CheckMove(board, history, trie, pos, dir))
        {
            wordSoFar += letterToCheck;
            pos = newPosition;
        }
    }

}