namespace YetAnotherBoggler.Boards;

public class BigBoggleBoard : BaseBoard
{
    const int size = 5;
    private BigBoggleBoard()
        : base(size)
    { }

    public static BigBoggleBoard Create(char[] letters)
    {
        BigBoggleBoard board = new BigBoggleBoard();
        board.MakeGrid(letters);
        return board;
    }
}