using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace Homework7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> files = FSWorker.ListOfFiles(FSWorker.GetCurrentDir());

            foreach (string file in files)
            {
                string text = FSWorker.ReadAllFile(file);
                if (text == "<empty>") continue;

                // Основной паттерн для номеров заданий
                var taskMatches = Regex.Matches(text, @"(?<number>\d{3,})(?<mark>[\*\.]*)");
                int totalTasks = taskMatches.Count;
                int starredTasks = taskMatches.OfType<Match>().Count(m => m.Groups["mark"].Value.Contains("*"));

                Console.WriteLine($"Файл: {Path.GetFileName(file)}");
                Console.WriteLine($"Количество заданий - {totalTasks}, из них со \"звёздочкой\" - {starredTasks}.");
                Console.WriteLine();
            }
        }
    }
}