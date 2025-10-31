using System;
using TextLibrary;

namespace TextLibrary.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Демонстрация TextLibrary (плохой структуры) ===\n");

            while (true)
            {
                Console.WriteLine("Введите текст (или пустую строку для выхода):");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Завершение работы программы...");
                    break;
                }

                TextProcessor processor = new TextProcessor(input);

                bool backToTextInput = false;
                while (!backToTextInput)
                {
                    Console.WriteLine("\nВыберите режим обработки:");
                    Console.WriteLine("1 — Подсчёт слов");
                    Console.WriteLine("2 — Самое длинное слово");
                    Console.WriteLine("3 — Частота символов");
                    Console.WriteLine("4 — Удаление лишних пробелов");
                    Console.WriteLine("5 — Изменение регистра");
                    Console.WriteLine("6 — Выравнивание по ширине");
                    Console.WriteLine("7 — Ввести новый текст");
                    Console.WriteLine("0 — Выход");
                    Console.Write("Ваш выбор: ");

                    string choice = Console.ReadLine();

                    if (choice == "0")
                    {
                        Console.WriteLine("Завершение программы...");
                        return;
                    }
                    else if (choice == "7")
                    {
                        backToTextInput = true;
                        continue;
                    }

                    if (int.TryParse(choice, out int mode))
                    {
                        processor.ProcessText(mode);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: введите номер операции!");
                    }

                    Console.WriteLine("\nНажмите Enter, чтобы продолжить...");
                    Console.ReadLine();
                }
            }
        }
    }
}
