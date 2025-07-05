using System.Text.Json;

namespace YetAnotherBoggler.Utils;

public class BoggleDictionary
{
    internal List<string> Words = new List<string>();
    
    public static BoggleDictionary Create()
    {
        string filePath = "/home/izaya/RiderProjects/YetAnotherBoggler/YetAnotherBoggler/Utils/dictionary.json";
        string fileContent = File.ReadAllText(filePath);

        List<string> wordList = JsonSerializer.Deserialize<List<string>>(fileContent);

        BoggleDictionary dictionary = new BoggleDictionary
        {
            Words = wordList
                .Where(word => !string.IsNullOrEmpty(word) && word.Length <= 16 && word.Length > 2)
                .Select(word => word.ToUpper())
                .ToList()
        };
        
        return dictionary;
    }
}