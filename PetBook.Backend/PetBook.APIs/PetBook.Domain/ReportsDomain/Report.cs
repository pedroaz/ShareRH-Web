using System;
using System.Collections.Generic;
using System.Text;

namespace PetBook.Domain.ReportsDomain
{
    public class Report
    {
        public string ReportName { get; set; } = "Lucas";

        public string Content { get; set; }

        public void GenerateBasicReportContent(int petCount, int petAverageAge)
        {
            Content = $"The current pet count is {petCount} with an average age of {petAverageAge}";
        }
    }
}
