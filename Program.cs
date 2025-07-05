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

Position startingPosition = new Position(0, 0);
WordRabbit rabbit = WordRabbit.Create(startingPosition, trie);

rabbit.Start(boggleBoard);

Direction[] directions = Direction.AllDirections;

for (var i = 0; i < 3; i++)
{
    rabbit.Move(directions[4], boggleBoard);
}

foreach (string word in rabbit.Words)
{
    Console.WriteLine(word);
}

