using System;
using System.Collections.Generic;
using System.Text;

namespace WebLib.TechData.Error
{

    /// <summary>
    /// вызывается при ошибке валидации
    /// </summary>
    public class ValidationException:Exception
    {
        public class ValidErrorData : ErrorData
        {
            public string fieldName;
        }
        public byte[] BadResultArray;
        public ValidErrorData err;
        public ValidationException(string fieldName, string errorMessage)
        {
            err = new ValidErrorData()
            {
                fieldName = fieldName,
                errorMessage = errorMessage,
                errorCode = 300
            };
            BadResultArray = err.ToBjson();
        }
    }
}
