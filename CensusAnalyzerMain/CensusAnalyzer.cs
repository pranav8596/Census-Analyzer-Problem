using CensusAnalyzerMain.exceptions;
using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace CensusAnalyzerMain
{
    public static class CensusAnalyzer
    {
        public static int LoadIndiaCensusData(string indiaCensusCSVFilePath)
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
                int numberOfRecords = 0;
                StreamReader readCsvData = new StreamReader(indiaCensusCSVFilePath);
                CsvReader loadCsvData = new CsvReader(readCsvData, true);
                while (loadCsvData.ReadNextRecord())
                {
                    numberOfRecords++;
                }
                return numberOfRecords;
            }
            catch (DirectoryNotFoundException e)
            {
                throw new CensusAnalyzerExceptions("CSV file path is Incorrect", CensusAnalyzerExceptions.ExceptionType.WRONG_FILE_PATH);
            }

        }

        public static int LoadIndiaStateCodeData(string indiaStateCodeCSVFilePath)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(indiaStateCodeCSVFilePath);
                string typeOfFile = fileInfo.Extension;
                string expectedType = ".csv";

                if (typeOfFile != expectedType)
                {
                    throw new CensusAnalyzerExceptions("CSV file type is Incorrect", CensusAnalyzerExceptions.ExceptionType.WRONG_FILE_TYPE);
                }
                int numberOfRecords = 0;
                StreamReader readCsvData = new StreamReader(indiaStateCodeCSVFilePath);
                CsvReader loadCsvData = new CsvReader(readCsvData, true);
                while (loadCsvData.ReadNextRecord())
                {
                    numberOfRecords++;
                }
                return numberOfRecords;
            }
            catch (DirectoryNotFoundException e)
            {
                throw new CensusAnalyzerExceptions("CSV file path is Incorrect", CensusAnalyzerExceptions.ExceptionType.WRONG_FILE_PATH);
            }

        }

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

