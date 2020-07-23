using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebLib.TechData;
using WebLib.TechData.Error;

namespace WebApi.Middleware
{
    /// <summary>
    /// Обработчик ошибок
    /// </summary>
    public class MiddlewareErrorCatcher
    {
        private readonly RequestDelegate Next;

        public MiddlewareErrorCatcher(RequestDelegate next) => Next = next;
        
        /// <summary>
        /// Отправить ошибку во фронт
        /// </summary>
        async Task SendErrorToFront(int errorCode, string errorMessage, Exception exception, HttpContext context, byte[] data)
        {
            var response = context.Response;
            var request = context.Request;
            var callStack = exception.StackTrace.ToString();
           

            var path = request.Path + "/" + request.Query.Join() ;
            var requestBodyData = await ReadBody(context);

            var jsonData = new
            {
                localIp = context.Connection.LocalIpAddress.ToString(),
                remoteIp = context.Connection.RemoteIpAddress.ToString(),
                headers = request.Headers.JoinRN(),
                callStack,
                host = request.Host
            };

            var userId = 0;
            try
            {
                userId = context.User.UserId();
            }
            catch { }
            var serverErrorMessage = new 
            {
                innerException= exception.InnerException,
                statusCode = 400,
                errorCode,
                userId,
                path,
                requestBodyData,
                errorMessage,
                datetime = DateTime.Now.ToShortDateString(),
                time = DateTime.Now.ToShortTimeString(),
                jdata = jsonData.ToJson()
            };

           
            response.StatusCode = 400;
            response.ContentType = "application/json; charset=utf-8";

            if (errorCode == ErrorList.ValidationError_999.errorCode)
            {
                await response.Body.WriteAsync(data);
                return;
            }
            //  TODO -> Send to server serverErrorMessage 
            var errorId = 0;
            var edata = new
            {
                errorId,
                errorMessage,
                errorCode
            };
            await response.Body.WriteAsync(edata.ToBjson());
        }

        /// <summary>
        /// Перехват исключений.
        /// в зависимости от типа ошибки , высылаем обратно то что нужно фронту
        /// </summary>
        /// <param name="context"></param>
        public async Task Invoke(HttpContext context)
        {
            //это позволит читать боди в случае ошибки
            context.Request.EnableBuffering();
            try
            {
                await Next(context);
            }
            catch (ValidationException validException)
            {
                await SendErrorToFront(ErrorList.ValidationError_999.errorCode, validException.err.errorMessage, validException, context, validException.BadResultArray);
            }
            catch (WebLibException except)
            {
                await SendErrorToFront(except.EData.errorCode, except.EData.errorMessage, except, context, except.BadResultArray);
            }
            catch (Exception commonExeption)
            {
                var error = ErrorList.ServerError_1000;
                error.errorMessage = commonExeption.Message;
                await SendErrorToFront(error.errorCode, error.errorMessage, commonExeption, context, error.ToBjson());
            }
        }
        async Task<string> ReadBody(HttpContext context)
        {
            //перепрочитаем body
            var request = context.Request;
            var body = request.Body;
            var buffer = new byte[request.ContentLength.ToInt()];

            body.Seek(0, SeekOrigin.Begin);
            body.Position = 0;
            await body.ReadAsync(buffer, 0, buffer.Length);
            return System.Text.Encoding.UTF8.GetString(buffer);
        }
    }
}
