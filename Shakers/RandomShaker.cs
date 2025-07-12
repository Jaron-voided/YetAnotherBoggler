namespace YetAnotherBoggler.Shakers;

public class RandomShaker : IShaker
{
    public char[] Shake(List<char[]> letterSets)
    {
        Random random = new Random();
        char[] shake = new char[letterSets.Count];

        // Step 1: Shuffle the letter sets
        var shuffledSets = letterSets.OrderBy(_ => random.Next()).ToList();

        // Step 2: Pick one random letter from each set
        for (int i = 0; i < shuffledSets.Count; i++)
        {
            var currentSet = shuffledSets[i];
            char chosenLetter = currentSet[random.Next(currentSet.Length)];
            shake[i] = chosenLetter;
        }

        return shake;
    }
}