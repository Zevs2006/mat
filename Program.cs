using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        // Путь к файлу с заменами
        string replacementsFile = "C:\\Users\\Student406-11\\Desktop\\replacements.txt";

        // Словарь для хранения матерных слов и их замен
        Dictionary<string, string> replacements = new Dictionary<string, string>();

        // Чтение файла с заменами
        foreach (var line in File.ReadAllLines(replacementsFile))
        {
            var parts = line.Split(',');
            if (parts.Length == 2)
            {
                replacements[parts[0].Trim()] = parts[1].Trim();
            }
        }

        Console.WriteLine("Введите предложение (вводите 'exit' для выхода):");

        while (true)
        {
            string input = Console.ReadLine();

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                break; // Выход из цикла при вводе 'exit'
            }

            // Замена матерных слов на культурные с использованием регулярных выражений
            foreach (var word in replacements)
            {
                // Заменяем только целые слова, используя регулярное выражение
                input = Regex.Replace(input, $@"\b{Regex.Escape(word.Key)}\b", word.Value, RegexOptions.IgnoreCase);
            }

            // Вывод результата
            Console.WriteLine("Результат: " + input);
        }
    }
}
