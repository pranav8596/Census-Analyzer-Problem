using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerMain.exceptions
{
    public class CSVBuilderException : Exception
    {
        public enum ExceptionType
        {
            WRONG_FILE_PATH, WRONG_FILE_TYPE, WRONG_FILE_DELIMITER
        }
        public ExceptionType type;
        public CSVBuilderException(String message, ExceptionType type) : base(message)
        {   
            this.type = type;
        }
    }
}
