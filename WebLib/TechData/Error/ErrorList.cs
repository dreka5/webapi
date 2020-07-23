using System;
using System.Collections.Generic;
using System.Text;

namespace WebLib.TechData.Error
{

    public class ErrorList
    {
        public static ErrorData WrongLogin_100 = new ErrorData() { errorCode = 100, errorMessage = "логин/пароль не верный" };
        public static ErrorData NoUser_101 = new ErrorData() { errorCode = 101, errorMessage = "нет пользователя" };
        public static ErrorData NoFirm_102 = new ErrorData() { errorCode = 101, errorMessage = "нет фирмы" };

        public static ErrorData ValidationError_999 = new ErrorData() { errorCode = 999, errorMessage = "валидация" };
        public static ErrorData ServerError_1000 = new ErrorData() { errorCode = 1000, errorMessage = "ошибка сервера" };
    }
}
