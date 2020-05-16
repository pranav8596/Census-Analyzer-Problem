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


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenIndiaStatesCensusFileName_WhenProper_ShouldReturnTotalRecords()
        {
            int noOfRecords = CensusAnalyzer.LoadIndiaCensusData(IndiaCensusCSVFilePath);
            Assert.AreEqual(29, noOfRecords);
        }

        [Test]
        public void GivenIndiaStatesCensusFileName_WhenImProper_ShouldReturnException()
        {
            try
            {
                CensusAnalyzer.LoadIndiaCensusData(WrongIndiaCensusCSVFilePath);
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExceptionType.WRONG_FILE_PATH, e.type);
            }
        }

        [Test]
        public void GivenIndiaStatesCensusFileName_WhenImProperType_ShouldReturnException()
        {
            try
            {
                CensusAnalyzer.LoadIndiaCensusData(WrongIndiaCensusCSVFileType);
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExceptionType.WRONG_FILE_TYPE, e.type);
            }
        }

        [Test]
        public void GivenIndiaStatesCensusFileName_WhenImProperDelimiter_ShouldReturnException()
        {
            try
            {
                CensusAnalyzer.LoadIndiaCensusData(IndiaCensusCSVFilePath, ';');
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExceptionType.WRONG_FILE_DELIMITER, e.type);
            }
        }

    }
}