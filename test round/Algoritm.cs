using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_round
{
    class Algoritm
    {


        // Sub optimal algorithm greedy heuristic
        public static IEnumerable<int> GetSubsetSum(IEnumerable<decimal> rows, decimal liqAmount)
        {
  

        List<decimal> res = new List<decimal>();
        List<NumId> resId = new List<NumId>();
            for(int i=0;i<rows.Count();i++)
            {
                resId.Add(new NumId { Id = i, Value = rows.ToList()[i] });
            }
        List<List<NumId>> combinations = new List<List<NumId>>();
            //Order the claim rows from max to min value and take only the ones with amount less or equal than liq amount
            NumId[] rowsarray = resId.Where(t => t.Value <= liqAmount).OrderByDescending(x => x.Value).ToArray();
            //For each claim row calculate a subset of rows with sum less or equal than liq amount
            for (int i = 0; i<rowsarray.Length; i++)
            {
                List<NumId> subset = new List<NumId> { rowsarray[i] };
        List<NumId> subsetId = new List<NumId> { rowsarray[i] };
                if (rowsarray[i].Value < liqAmount)
                {
                    //If the current row's amount is less than the liq amount cycle the following ones, adding them until they no longer fit
                    for (int k = i + 1; k<rowsarray.Length; k++)
                    {
                        //check if the sum of the current subset's values plus the current row's one still fits the liq amount
                        decimal subSum = subset.Sum(x => x.Value) + rowsarray[k].Value;
                        if (subSum <= liqAmount)
                        {
                            //The liq amount is greater then the sum of the rows in the subset, add the current row and keep going
                            subset.Add(rowsarray[k]);
                            if (subSum == liqAmount)
                            {
                                //Perfect match found, no need to go on, the subset is complete
                                break;
                            }
                        }
}
                }
                combinations.Add(subset);
            }
            //At the end of the cycle above multiple subsets have been calculated. The preferrable one is the one with maximum value and minimum number of rows
            var result = combinations.OrderByDescending(p => (decimal)p.Sum(x => Math.Abs(x.Value)))
                .ThenBy(p => p.Count())
                .FirstOrDefault();
            return result.Select(t => t.Id).ToList();
        }
    }
    public class NumId
    {
        public decimal Value { get; set; }
        public int Id { get; set; }
    }
}
