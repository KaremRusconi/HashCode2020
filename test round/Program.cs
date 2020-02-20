using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_round
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = args[0];
            var data = InputData.ReadDataFile(fileName);
            var result = Algoritm.GetSubsetSum(data.Item2, data.Item1);
            InputData.WriteDataFile(fileName.Replace(".in",".out"), result);
        }
    }
}
