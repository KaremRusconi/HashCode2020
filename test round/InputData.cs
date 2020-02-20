using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_round
{
    public class InputData
    {
        public static Tuple<decimal,IEnumerable<decimal>> ReadDataFile(string path)
        {
            Dictionary<string, string[]> csvDictionary = new Dictionary<string, string[]>();
            var result = new Tuple<decimal, IEnumerable<decimal>>(0,new List<decimal>());
            List<string[]> csvList = new List<string[]>();
            FileStream _fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using (StreamReader reader = new StreamReader(_fileStream, Encoding.Default, true, 1024))
            {
                string currentLine = reader.ReadLine();
                decimal max = Convert.ToDecimal(currentLine.Split(new char[] { ' ' }, StringSplitOptions.None).ToList().First());
                currentLine = reader.ReadLine();
                List<string> temp = currentLine.Split(new char[] { ' ' }, StringSplitOptions.None).ToList();
                List<decimal> values = temp.Where(x => !string.IsNullOrEmpty(x)).Select(x =>  Convert.ToDecimal(x)).ToList();
                result = new Tuple<decimal, IEnumerable<decimal>>(max, values);
            }

            return result;
        }
        public static void WriteDataFile(string path, IEnumerable<int> data)
        {
            int numLines = data.Count();
            if (numLines > 1)
            {
                string pathFile = path;
                string concatres = string.Empty;
                foreach(decimal num in data)
                {
                    concatres += $"{num} ";
                }
                string output = data.Count() + Environment.NewLine + concatres;
                File.WriteAllText(pathFile, output);
            }


        }
    }
}
