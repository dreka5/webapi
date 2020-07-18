using System;
using System.Collections.Generic;
using System.Text;
using WebLib.TechData.Error;

namespace WebLib.TechData
{
    /// <summary>
    /// Перехват ошибок логики. не те данные. Защита системы
    /// </summary>
    public class WebLibException : Exception
    {
        public ErrorData EData;
        public byte[] BadResultArray;
        public WebLibException(ErrorData d)
        {
            EData = d;
            BadResultArray = d.ToBjson();
        }
    }
}
