using System;
using TextLibrary;
using TextLibrary.Implementations;
using TextLibrary.Interfaces;
using TextLibrary.Services;

namespace TextLibrary.Client
{
    internal class Program
    {
        static void Main()
        {
            var wordCounter = new WordCounter();
            var longestFinder = new LongestWordFinder();
            var charAnalyzer = new CharFrequencyAnalyzer();
            var cleaner = new TextCleaner();
            var caseConverter = new CaseConverter();
            var justifier = new Justifier();
            ITextProcessingService service = new TextProcessingService(
                wordCounter,
                longestFinder,
                charAnalyzer,
                cleaner,
                caseConverter,
                justifier
            );

            while (true)
            {
                Console.WriteLine("Введите текст (пустая строка — выход):");
                string text = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(text)) break;

                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Выберите режим:");
                    Console.WriteLine("1 - Подсчёт слов");
                    Console.WriteLine("2 - Самое длинное слово");
                    Console.WriteLine("3 - Частота символов");
                    Console.WriteLine("4 - Удалить лишние пробелы");
                    Console.WriteLine("5 - Преобразовать в верхний регистр");
                    Console.WriteLine("6 - Преобразовать в нижний регистр");
                    Console.WriteLine("7 - Выравнивание по ширине");
                    Console.WriteLine("8 - Средняя длина слова");
                    Console.WriteLine("9 - Ввести новый текст");
                    Console.WriteLine("0 - Выход");
                    Console.Write("Ваш выбор: ");
                    var choice = Console.ReadLine();

                    if (choice == "0") return;
                    if (choice == "9") break;

                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine($"Количество слов: {service.CountWords(text)}");
                            break;
                        case "2":
                            Console.WriteLine($"Самое длинное слово: {service.FindLongestWord(text)}");
                            break;
                        case "3":
                            var freq = service.CharFrequency(text);
                            foreach (var kv in freq)
                                Console.WriteLine($"'{kv.Key}' = {kv.Value}");
                            break;
                        case "4":
                            text = service.RemoveExtraSpaces(text);
                            Console.WriteLine("Результат:");
                            Console.WriteLine(text);
                            break;
                        case "5":
                            text = service.ConvertToUpper(text);
                            Console.WriteLine("Результат:");
                            Console.WriteLine(text);
                            break;
                        case "6":
                            text = service.ConvertToLower(text);
                            Console.WriteLine("Результат:");
                            Console.WriteLine(text);
                            break;
                        case "7":
                            Console.Write("Введите ширину (число): ");
                            if (int.TryParse(Console.ReadLine(), out int w) && w > 0)
                                Console.WriteLine(service.JustifyText(text, w));
                            else
                                Console.WriteLine("Неверная ширина");
                            break;
                        case "8":
                            double avg = service.GetAverageWordLength(text);
                            Console.WriteLine($"Средняя длина слова: {avg:F2}");
                            break;
                        default:
                            Console.WriteLine("Неверный выбор");
                            break;
                    }

                    Console.WriteLine();
                    Console.WriteLine("Нажмите Enter чтобы продолжить...");
                    Console.ReadLine();
                }
            }
        }
    }
}
