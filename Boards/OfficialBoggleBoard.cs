namespace YetAnotherBoggler.Boards;

public class OfficialBoggleBoard : BaseBoard
{
    const int size = 4;
    private OfficialBoggleBoard()
        : base(size)
    { }

    public static OfficialBoggleBoard Create(char[] letters)
    {
        OfficialBoggleBoard board = new OfficialBoggleBoard();
        board.MakeGrid(letters);
        return board;
    }
}