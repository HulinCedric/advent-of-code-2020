using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day01
{
    public static class ReportRepair
    {
        private const int TargetedSum = 2020;

        public static int GetFixedExpenseReportValueWithThreeEntries(List<int> expenseReport)
            =>
            (from first in expenseReport
             from second in expenseReport
             from third in expenseReport
             where first + second + third == TargetedSum
             select first * second * third)
            .First();

        public static int GetFixedExpenseReportValueWithTwoEntries(IEnumerable<int> expenseReport)
                    =>
            (from first in expenseReport
             from second in expenseReport
             where first + second == TargetedSum
             select first * second)
            .First();
    }
}