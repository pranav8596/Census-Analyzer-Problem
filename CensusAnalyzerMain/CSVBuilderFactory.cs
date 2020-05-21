using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerMain
{
    class CSVBuilderFactory
    {
        public static ICSVBuilder createCSVBuilder()
        {
            return new CensusAnalyzer();
        }
    }
}
