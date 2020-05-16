using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerMain.exceptions
{
    public class CensusAnalyzerExceptions : Exception
    {
        public enum ExceptionType
        {
            WRONG_FILE_PATH, WRONG_FILE_TYPE, WRONG_FILE_DELIMITER
        }
        public ExceptionType type;
        public CensusAnalyzerExceptions(String message, ExceptionType type) : base(message)
        {   
            this.type = type;
        }
    }
}
