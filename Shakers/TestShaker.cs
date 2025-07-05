using YetAnotherBoggler.Interfaces;

namespace YetAnotherBoggler.Shakers;

public class TestShaker : IShaker
{
    public string[] Shake(List<string[]> letterSets)
    {
        string[] shake = new string[letterSets.Count];
        for (int i = 0; i < letterSets.Count; i++)
        {
            shake[i] = letterSets[i][0];
        }

        return shake;
    }
}