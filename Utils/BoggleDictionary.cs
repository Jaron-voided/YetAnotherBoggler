using System.Text.Json;

namespace YetAnotherBoggler.Utils;

public sealed class BoggleDictionary
{
    // Had to make Words public for testing
    public List<string> Words = new List<string>();
    
    public static BoggleDictionary Create(string? filePath = null)
    {
        filePath ??= "/home/izaya/RiderProjects/YetAnotherBoggler/YetAnotherBoggler/Utils/dictionary.txt";
        string[] lines = File.ReadAllLines(filePath);

        List<string> wordList = lines
            .Where(word => !string.IsNullOrEmpty(word) && word.Length <= 16 && word.Length > 2)
            .Select(word => word.ToUpper())
            .ToList();

        BoggleDictionary dictionary = new BoggleDictionary
        {
            Words = wordList
        };
        
        return dictionary;
    }
}