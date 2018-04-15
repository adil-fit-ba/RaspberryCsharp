using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FIT_IoT.Core.Helper;

namespace FIT_IoT.Client.Helper
{
    public class MyApiRequests
    {
        public class P
        {
            public string _name;
            public object _value;

            public P(string name, object value)
            {
                _name = name;
                _value = value;
            }
        }
        public static ApiResult<T> Get<T>(string controllerName, string action, params P[] ps)
        {
            return Get<T>(controllerName + "/" + action, ps);
        }

        public static ApiResult<T> Get<T>(string route, params P[] ps)
        {
            WebClient wc = new WebClient();
            string address = MyConfig.ServerUrl + "/" + route + "?";

            foreach (P p in ps)
            {
                address += p._name + "=" + p._value + "&";
            }
            try
            {
                string json = wc.DownloadString(address);
                ApiResult<T> result = JsonConvert.DeserializeObject<ApiResult<T>>(json);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Api.Get " + address + " -> " + e);
                return new ApiResult<T>
                {
                    isException = true,
                    exceptionCode = -10,
                    exceptionMessage = "exception: " + address+ " -> " + e.Message
                };
            }
          
        }
    }
}
