using System;
using System.Collections.Generic;
using System.Text;

namespace WebLib.TechData
{
    /// camelCase
    /// <summary>
    /// раздаваемый наружу ответ с токеном
    /// </summary>
    public partial class TokenData
    {
        /// <summary>
        /// роль токена
        /// </summary>
        public String role { get; set; }
        /// <summary>
        /// токен
        /// </summary>
        public String accessToken { get; set; }
        /// <summary>
        /// ид
        /// </summary>
        public Int32 id { get; set; }
        public String userName { get; set; }
    }
}
