using AllGoRithmFramework.Domain.DataObjects;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace AllGoRithmFramework.Service.UtilServices
{
    public class HttpService
    {
        private HttpClient Client { get; set; }

        public HttpService()
        {
            this.Client = new HttpClient();
        }
        
        public object Get(string baseUrl, Dictionary<string, string> parameters = null, Dictionary<string, string> headers = null)
        {
            this.AddHeaders(headers);

            baseUrl = this.BuildQueryString(baseUrl, parameters);

            var result = this.Client.GetAsync(baseUrl).Result;

            return result.Content.ReadAsAsync<object>().Result;
        }
        
        public T Get<T>(string baseUrl, Dictionary<string, string> parameters = null, Dictionary<string, string> headers = null) where T : BaseDto
        {
            var response = this.Get(baseUrl, parameters, headers);
            return  JsonConvert.DeserializeObject<T>(response.ToString());
        }
        
        public object Post(string baseUrl, object data, Dictionary<string, string> headers = null)
        {
            this.AddHeaders(headers);

            var result = this.Client.PostAsJsonAsync(baseUrl, data).Result;

            return result.Content.ReadAsAsync<object>().Result;
        }
        
        public T Post<T>(string baseUrl, object data, Dictionary<string, string> headers) where T : BaseDto
        {
            var response = this.Post(baseUrl, data, headers);
            return JsonConvert.DeserializeObject<T>(response.ToString()); ;
        }

        public object ExecuteRequest(HttpMethod httpMethod, string baseUrl, Dictionary<string, string> headers = null, Dictionary<string, string> parameters = null, object data = null)
        {
            this.AddHeaders(headers);
            this.BuildQueryString(baseUrl, parameters);

            if (httpMethod == HttpMethod.Get)
            {
                return this.Get(baseUrl, parameters, headers);
            }
            else if (httpMethod == HttpMethod.Post) 
            {
                return this.Post(baseUrl, data, headers);
            }
            else
            {
                return null;
            }
        }

        public T ExecuteRequest<T>(HttpMethod httpMethod, string baseUrl, Dictionary<string, string> headers = null, Dictionary<string, string> parameters = null, object data = null) where T : BaseDto
        {
            return this.ExecuteRequest(httpMethod, baseUrl, headers, parameters, data) as T;
        }

        private string BuildQueryString(string baseUrl, Dictionary<string, string> parameters)
        {
            if(parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    string querystring = string.Empty;
                    string separator = string.IsNullOrEmpty(querystring) ? "?" : "&";
                    querystring += string.Format("{0}{1}={2}", separator, parameter.Key, parameter.Value);

                    baseUrl += querystring;
                }
            }
            
            return baseUrl;
        }

        private void AddHeaders(Dictionary<string, string> headers)
        {
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    if (!this.Client.DefaultRequestHeaders.Contains(header.Key))
                        this.Client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
        }
    }
}
