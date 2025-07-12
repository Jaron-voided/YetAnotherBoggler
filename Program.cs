using YetAnotherBoggler.Boards;
using YetAnotherBoggler.LetterSetProviders;
using YetAnotherBoggler.Printers;
using YetAnotherBoggler.Shakers;
using YetAnotherBoggler.Utils;
using YetAnotherBoggler.WordFinding;

// Should these all be static so I don't have to instantiate every class to use it?
var testProvider = new TestLetterSetProvider();
List<char[]> testLetters = testProvider.GetLetterSetFaces();

var testShaker = new TestShaker();
char[] shakenTestLetters = testShaker.Shake(testLetters);

var board = OfficialBoggleBoard.Create(shakenTestLetters);

var printer = new ConsoleBoardPrinter();
printer.DisplayBoard(board);

var dictionary = BoggleDictionary.Create();
var boggleTrie = BoggleTrie.Create(dictionary.Words);

Console.WriteLine("Created dictionary and trie!");
/*Position pos = new Position(0,0);
var rabbit = WordRabbit.Create(pos, boggleTrie);
var wordFinder = new WordFinder();
wordFinder.ExploreBoard(rabbit, board);
foreach (var word in wordFinder.CompletedWords)
{
    Console.WriteLine(word);
}*/
var wordFinder = new WordFinder();
List<WordRabbit> rabbits = new List<WordRabbit>();

for (var x = 0; x < board.Size; x++)
{
    for (var y = 0; y < board.Size; y++)
    {
        Position pos = new Position(x, y);
        var rabbit = WordRabbit.Create(pos, boggleTrie);
        rabbits.Add(rabbit);
    }
}

Parallel.ForEach(rabbits, rabbit =>
{
    wordFinder.ExploreBoard(rabbit, board);
});

Console.WriteLine("Rabbits found the following words");
foreach (var word in wordFinder.CompletedWords)
{
    Console.WriteLine(word);
}