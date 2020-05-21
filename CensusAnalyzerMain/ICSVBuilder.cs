using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerMain
{
    interface ICSVBuilder
    {
        int LoadIndiaCensusData(string indiaCensusCSVFilePath);

    }
}
