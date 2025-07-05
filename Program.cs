// See https://aka.ms/new-console-template for more information

using YetAnotherBoggler.Boards;
using YetAnotherBoggler.Interfaces;
using YetAnotherBoggler.LetterSetProviders;
using YetAnotherBoggler.Printers;
using YetAnotherBoggler.Shakers;
using YetAnotherBoggler.Utils;

ILetterSetProvider letterProvider = new TestLetterSetProvider();
List<string[]> letterSets = letterProvider.GetLetterSetFaces();

TestShaker shaker = new TestShaker();
string[] shake = shaker.Shake(letterSets);

IBoard boggleBoard = BoggleBoard.Create(shake);

IBoardPrinter printer = new ConsoleBoardPrinter();
printer.DisplayBoard(boggleBoard);

BoggleDictionary dictionary = BoggleDictionary.Create();
foreach (string word in dictionary.Words)
{
    Console.WriteLine(word);
}