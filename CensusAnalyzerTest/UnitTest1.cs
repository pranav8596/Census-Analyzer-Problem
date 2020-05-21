using NUnit.Framework;
using CensusAnalyzerMain;
using CensusAnalyzerMain.exceptions;

namespace CensusAnalyzerTest
{
    public class Tests
    {
        public const string IndiaCensusCSVFilePath = @"D:\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\resources\IndiaStateCensusData.csv";
        public const string WrongIndiaCensusCSVFilePath = @"C:\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\resources\IndiaStateCensusData.csv";
        public const string WrongIndiaCensusCSVFileType = @"D:\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\resources\IndiaStateCensusData.json";
        public const string IndiaStateCodeCSVFilePath = @"D:\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\resources\IndiaStateCode.csv";
        public const string WrongIndiaStateCodeCSVFilePath = @"C:\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\resources\IndiaStateCode.csv";        
        public const string WrongIndiaStateCodeCSVFileType = @"D:\source\repos\CensusAnalyzerProblem\CensusAnalyzerTest\resources\IndiaStateCode.json";

        [SetUp]
        public void Setup()
        {
        }

        CensusAnalyzer censusAnalyzer = new CensusAnalyzer();

        [Test]
        public void GivenIndiaStatesCensusFileName_WhenProper_ShouldReturnTotalRecords()
        {
            int noOfRecords = censusAnalyzer.LoadIndiaCensusData(IndiaCensusCSVFilePath);
            Assert.AreEqual(29, noOfRecords);
        }

        [Test]
        public void GivenIndiaStatesCensusFileName_WhenImProper_ShouldReturnException()
        {
            CensusAnalyzer censusAnalyzer = new CensusAnalyzer();

            try
            {
                censusAnalyzer.LoadIndiaCensusData(WrongIndiaCensusCSVFilePath);
            }
            catch (CSVBuilderException e)
            {
                Assert.AreEqual(CSVBuilderException.ExceptionType.WRONG_FILE_PATH, e.type);
            }
        }

        [Test]
        public void GivenIndiaStatesCensusFileName_WhenImProperType_ShouldReturnException()
        {
            try
            {
                censusAnalyzer.LoadIndiaCensusData(WrongIndiaCensusCSVFileType);
            }
            catch (CSVBuilderException e)
            {
                Assert.AreEqual(CSVBuilderException.ExceptionType.WRONG_FILE_TYPE, e.type);
            }
        }

        [Test]
        public void GivenIndiaStatesCensusFileName_WhenImProperDelimiter_ShouldReturnException()
        {
            try
            {
                CensusAnalyzer.LoadIndiaCensusData(IndiaCensusCSVFilePath, ';');
            }
            catch (CSVBuilderException e)
            {
                Assert.AreEqual(CSVBuilderException.ExceptionType.WRONG_FILE_DELIMITER, e.type);
            }
        }

        [Test]
        public void GivenIndiaStateCodeFileName_WhenProper_ShouldReturnTotalRecords()
        {
            int noOfRecords = censusAnalyzer.LoadIndiaCensusData(IndiaStateCodeCSVFilePath);
            Assert.AreEqual(37, noOfRecords);
        }

        [Test]
        public void GivenIndiaStateCodeCensusFileName_WhenImProper_ShouldReturnException()
        {
            try
            {
                censusAnalyzer.LoadIndiaCensusData(WrongIndiaStateCodeCSVFilePath);
            }
            catch (CSVBuilderException e)
            {
                Assert.AreEqual(CSVBuilderException.ExceptionType.WRONG_FILE_PATH, e.type);
            }
        }

        [Test]
        public void GivenIndiaStateCodeCensusFileName_WhenImProperType_ShouldReturnException()
        {
            try
            {
                censusAnalyzer.LoadIndiaCensusData(WrongIndiaStateCodeCSVFileType);
            }
            catch (CSVBuilderException e)
            {
                Assert.AreEqual(CSVBuilderException.ExceptionType.WRONG_FILE_TYPE, e.type);
            }
        }

        [Test]
        public void GivenIndiaStateCodeCensusFileName_WhenImProperDelimiter_ShouldReturnException()
        {
            try
            {
                CensusAnalyzer.LoadIndiaCensusData(IndiaStateCodeCSVFilePath, ';');
            }
            catch (CSVBuilderException e)
            {
                Assert.AreEqual(CSVBuilderException.ExceptionType.WRONG_FILE_DELIMITER, e.type);
            }
        }

    }
}