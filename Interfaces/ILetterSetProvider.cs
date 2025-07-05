namespace YetAnotherBoggler.Interfaces;

public interface ILetterSetProvider
{
    List<string[]> GetLetterSetFaces(IBoard board);
}