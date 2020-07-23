using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebLib.TechData
{
    //TODO -> по хорошему , это надо как то структурировать , а то всё в кучу , кони , люди....
    public interface IRemoteDataProvider
    {
        Task<FirmData[]> GetFirm();
    }
    public class RemoteDataProvider : IRemoteDataProvider
    {
        public string API = "";
        public async Task<FirmData[]> GetFirm() => await HttpRequester.FindDataArray<FirmData[]>(API + "firm");
    }
    public class HttpRequester
    {
        public static async Task<T> FindDataArray<T>(string url)
        {

            var realUrl = url;
            var client = new HttpClient() { Timeout = TimeSpan.FromSeconds(4) };
            string resultArray = "[]";
            try
            {
                var result = await client.GetAsync(realUrl);
                var byteResult = await result.Content.ReadAsByteArrayAsync();
                resultArray = Encoding.UTF8.GetString(byteResult);
            }
            catch (Exception ex)
            {
                // TODO обработка ошибки
            }
            return JsonConvert.DeserializeObject<T>(resultArray);
        }
        static HttpContent Content(object q)
        {
            string json = JsonConvert.SerializeObject(q);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return content;
        }
    }
}
