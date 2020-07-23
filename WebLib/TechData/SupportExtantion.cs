using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Text;
using WebLib.TechData.Error;

namespace WebLib.TechData
{
    public static class SupportExtantion
    {

        /// <summary>
        /// Объединение в строки
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string JoinRN<T>(this IEnumerable<T> array) => Join(array, "\r\n");
        /// <summary>
        /// Объединение в строку с разделителем
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static string Join<T>(this IEnumerable<T> array,string symbol="")
        {
            var sb = new StringBuilder();
            foreach (var q in array)
            {
                if (q == null) continue;
                sb.Append(q.ToString()+symbol);
            }
            return sb.ToString();
        }
        /// <summary>
        /// получение ID пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int UserId(this ClaimsPrincipal user)
        {
            var c = user.FindFirst("id");
            if (c == null)
                throw new WebLibException(ErrorList.NoUser_101);
            return c.Value.ToInt();
        }

        /// <summary>
        /// Конвертируем в Byte[] JSON
        /// </summary>
        /// <param name="data"></param>
        public static byte[] ToBjson(this object data)
        {
            return System.Text.Encoding.UTF8.GetBytes(ToJson(data));
        }

        /// <summary>
        /// конвертируем в JSON
        /// </summary>
        /// <param name="data"></param>
        public static string ToJson(this object data)
        {
            if (data == null) return Newtonsoft.Json.JsonConvert.SerializeObject("{}");
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        /// <summary>
        /// получаем число из объекта. Почему ToString есть,  а ToInt нету
        /// </summary>
        /// <param name="q"></param>
        public static int ToInt(this object value)
        {
            if (value == null) return 0;
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }



    }
}
