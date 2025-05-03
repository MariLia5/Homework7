using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework7
{
    internal class FSWorker
    {
        static public string GetCurrentDir()
        {
            return Directory.GetCurrentDirectory();
        }
        static public string ReadAllFile(string _filename)
        {
            string result = string.Empty;
            try
            {
                using (StreamReader sr = new StreamReader(_filename))
                {
                    result = sr.ReadToEnd();
                }
            }
            catch
            {
                result = "<empty>";
            }
            return result;
        }
        static public List<string> ListOfFiles(string _path)
        {
            List<string> result = new List<string>();
            foreach (string filename in Directory.EnumerateFiles(_path, "*.txt"))
            {
                result.Add(filename);
            }
            return result;
        }
    }
}