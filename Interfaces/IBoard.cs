namespace YetAnotherBoggler.Interfaces;

public interface IBoard
{
    int Size { get; set; }
    string[,] GetLetters();
}