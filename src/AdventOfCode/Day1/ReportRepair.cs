using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day1
{
    public static class ReportRepair
    {
        public static int GetFixedExpenseReportValue(IEnumerable<int> expenseReport)
        {
            int? fixedExpenseReportValue = expenseReport
            .SelectMany(x => expenseReport, (x, y) => new { x, y })
            .Select(cartesianJoinedExpenseReport => new
            {
                first = cartesianJoinedExpenseReport.x,
                second = cartesianJoinedExpenseReport.y,
                sum = cartesianJoinedExpenseReport.x + cartesianJoinedExpenseReport.y
            })
            .Where(result => result.sum == 2020)
            .Select(result => result.first * result.second)
            .FirstOrDefault();

            return fixedExpenseReportValue ?? 0;
        }
    }
}