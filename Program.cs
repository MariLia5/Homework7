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

            string taskPattern = @"(?<=\s|^)\d{3,}(?:[\.\*]*)(?=\s|$)";

            foreach (string file in files)
            {
                string text = FSWorker.ReadAllFile(file);
                if (text == "<empty>")
                {
                    continue;
                }

                // Находим все задания
                var allTasks = Regex.Matches(text, taskPattern);
                int totalTasks = allTasks.Count;

                // Подсчитываем задания со звёздочкой
                int starredTasks = allTasks.Cast<Match>().Count(m => Regex.IsMatch(m.Value, @"\*"));

                Console.WriteLine($"Файл: {Path.GetFileName(file)}");
                Console.WriteLine($"Количество заданий - {totalTasks}, из них со \"звёздочкой\" - {starredTasks}.");
                Console.WriteLine();
            }
        }
    }
}