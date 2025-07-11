namespace YetAnotherBoggler.LetterSetProviders;

// Returns a simple, testable baord setup
public class TestLetterSetProvider : ILetterSetProvider
{
    private readonly List<char[]> _faces = new()
    {
        new[] { 'C' }, new[] { 'A' }, new[] { 'T' }, new[] { 'S' },
        new[] { 'L' }, new[] { 'X' }, new[] { 'U' }, new[] { 'X' },
        new[] { 'U' }, new[] { 'X' }, new[] { 'B' }, new[] { 'X' },
        new[] { 'B' }, new[] { 'X' }, new[] { 'U' }, new[] { 'N' },
    };

    public List<char[]> GetLetterSetFaces()
    {
        return _faces;
    }
}