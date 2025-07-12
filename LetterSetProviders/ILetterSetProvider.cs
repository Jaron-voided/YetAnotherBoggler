namespace YetAnotherBoggler.LetterSetProviders;

// Should these be Enumerables?
public interface ILetterSetProvider
{
    List<char[]> GetLetterSetFaces();
}