using System;
using System.Collections.Generic;
using System.Text;

namespace WebLib.TechData
{
    public class WebApiConfig: IWebApiConfig
    {
        public string con { get; set; } = "hello";
    }
    public interface IWebApiConfig
    {
        string con { get; set; }
    }
}
