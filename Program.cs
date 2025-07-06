// See https://aka.ms/new-console-template for more information

using YetAnotherBoggler.Boards;
using YetAnotherBoggler.Interfaces;
using YetAnotherBoggler.LetterSetProviders;
using YetAnotherBoggler.Printers;
using YetAnotherBoggler.Shakers;
using YetAnotherBoggler.Utils;
using YetAnotherBoggler.WordFinding;

ILetterSetProvider letterProvider = new TestLetterSetProvider();
List<string[]> letterSets = letterProvider.GetLetterSetFaces();

TestShaker shaker = new TestShaker();
string[] shake = shaker.Shake(letterSets);

BoggleBoard boggleBoard = BoggleBoard.Create(shake);

IBoardPrinter printer = new ConsoleBoardPrinter();
printer.DisplayBoard(boggleBoard);

BoggleDictionary dictionary = BoggleDictionary.Create();

BoggleTrie trie = BoggleTrie.Create(dictionary.Words);
Position pos =  new Position(0, 0);

/*WordRabbit rabbit = WordRabbit.Create(pos, trie);
WordFinder.ExploreBoard(rabbit, boggleBoard);
foreach (string word in WordRabbit.Words)
{
    Console.WriteLine(word);
}*/
List<WordRabbit> rabbits = new();

for (int x = 0; x < boggleBoard.Size; x++)
{
    for (int y = 0; y < boggleBoard.Size; y++)
    {
        Position position = new Position(x, y);
        BoggleTrie rabbitTrie = BoggleTrie.Create(dictionary.Words);
        WordRabbit rabbit = WordRabbit.Create(position, rabbitTrie);
        rabbits.Add(rabbit);
    }
}

foreach (WordRabbit rabbit in rabbits)
{
    WordFinder.ExploreBoard(rabbit, boggleBoard);
}

foreach (string word in WordRabbit.Words)
{
    Console.WriteLine(word);
}


/*
Position startingPosition = new Position(0, 0);
WordRabbit rabbit = WordRabbit.Create(startingPosition, trie);

rabbit.Start(boggleBoard);

Direction[] directions = Direction.AllDirections;

for (var i = 0; i < 3; i++)
{
    rabbit.Move(directions[4], boggleBoard);
}

Console.WriteLine("Word rabbit found the following words...");

foreach (string word in rabbit.Words)
{
    Console.WriteLine(word);
}
*/

