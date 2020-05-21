using CensusAnalyzerMain.exceptions;
using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace CensusAnalyzerMain
{
    public class CensusAnalyzer : ICSVBuilder
    {
        /// <summary>
        /// Load the data from the csv file
        /// </summary>
        /// <param name="indiaCensusCSVFilePath"></param>
        /// <returns></returns>
        public int LoadIndiaCensusData(string indiaCensusCSVFilePath)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(indiaCensusCSVFilePath);
                string typeOfFile = fileInfo.Extension;
                string expectedType = ".csv";

                if (typeOfFile != expectedType)
                {
                    throw new CensusAnalyzerExceptions("CSV file type is Incorrect", CensusAnalyzerExceptions.ExceptionType.WRONG_FILE_TYPE);
                }
                ICSVBuilder CSVBuilder = CSVBuilderFactory.createCSVBuilder();
               // CSVBuilder.LoadIndiaCensusData
                return GetCount(indiaCensusCSVFilePath);
            }
            catch (DirectoryNotFoundException e)
            {
                throw new CensusAnalyzerExceptions("CSV file path is Incorrect", CensusAnalyzerExceptions.ExceptionType.WRONG_FILE_PATH);
            }

        }

        /// <summary>
        /// Get the count of number of records
        /// </summary>
        /// <param name="indiaCensusCSVFilePath"></param>
        /// <returns></returns>
        public static int GetCount(string indiaCensusCSVFilePath)
        {
            int numberOfRecords = 0;
            StreamReader readCsvData = new StreamReader(indiaCensusCSVFilePath);
            CsvReader loadCsvData = new CsvReader(readCsvData, true);
            while (loadCsvData.ReadNextRecord())
            {
                numberOfRecords++;
            }
            return numberOfRecords;
        }

        /// <summary>
        /// Check if the csv file has the correct delimiter
        /// </summary>
        /// <param name="indiaCensusCSVFilePath"></param>
        /// <param name="c"></param>
        public static void LoadIndiaCensusData(string indiaCensusCSVFilePath, char c)
        {
            StreamReader readCsvData = new StreamReader(indiaCensusCSVFilePath);
            CsvReader loadCsvData = new CsvReader(readCsvData, true);
            char delimiter = loadCsvData.Delimiter;
            if (delimiter != c)
            {
                throw new CensusAnalyzerExceptions("CSV file delimiter is Incorrect", CensusAnalyzerExceptions.ExceptionType.WRONG_FILE_DELIMITER);
            }
        }
    }
}

