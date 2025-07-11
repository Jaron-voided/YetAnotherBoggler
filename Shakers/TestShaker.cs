namespace YetAnotherBoggler.Shakers;

public class TestShaker : IShaker
{
    public char[] Shake(List<char[]> letterSets)
    {
        char[] shake = new char[letterSets.Count];
        for (int i = 0; i < letterSets.Count; i++)
        {
            shake[i] = letterSets[i][0];
        }

        return shake;
    }
}