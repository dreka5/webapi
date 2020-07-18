using System;
using System.Collections.Generic;
using System.Text;

namespace WebLib.TechData.Error
{
    /// <summary>
    /// Класс проверки полей при валидации
    /// </summary>
    public static class CheckData
    {
        /// <summary>
        /// Проверка поля на прочность
        /// </summary>
        /// <param name="fieldName">название поля</param>
        /// <param name="value">значение</param>
        /// <param name="minLen"></param>
        /// <param name="maxLen"></param>
        public static void Name(string fieldName,string value,int minLen=-1,int maxLen=-1)
        {
            if (value==null)
                throw new ValidationException(fieldName, "Поле не может быть пустым");
            var len = value.Length;
            if (minLen > 0 && len <= minLen)
                throw new ValidationException(fieldName, $"Поле короткое. Не менее {minLen} символов");
            if (maxLen > 0 && len >= maxLen)
                throw new ValidationException(fieldName, $"Поле длинное. Не более {maxLen} символов");
        }
    }
}
