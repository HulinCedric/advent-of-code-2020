using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day1
{
    public static class ReportRepair
    {
        private const int TargetedSum = 2020;

        public static int GetFixedExpenseReportValueWithTwoEntries(IEnumerable<int> expenseReport)
            =>
            (from first in expenseReport
             from second in expenseReport
             select new
             {
                 sum = first + second,
                 product = first * second
             })
             .Where(result => result.sum == TargetedSum)
             .Select(result => result.product)
             .First();

        public static int GetFixedExpenseReportValueWithThreeEntries(List<int> expenseReport)
            =>
            (from first in expenseReport
             from second in expenseReport
             from third in expenseReport
             select new
             {
                 sum = first + second + third,
                 product = first * second * third
             })
            .Where(result => result.sum == TargetedSum)
            .Select(result => result.product)
            .First();
    }
}