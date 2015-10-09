using Bootstrap.Core;
using Bootstrap.Core.Code;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bootstrap.REST.Services
{
    public partial class ServiceBroker
    {

        Core.Interfaces.IPlatform _global;
        public string BaseUrl { get; set; }

        System.Net.Http.HttpClient client = new HttpClient();

        public ServiceBroker(Core.Interfaces.IPlatform platform)
        {

            client.DefaultRequestHeaders.Clear();
            _global = platform;

        }

        public ServiceBroker()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authKey"> Global.xAuthKey</param>
        /// <param name="authUser"> Global.xAuthUser</param>
        /// <param name="format"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        private Dictionary<string, string> GetDefaultParameters(string format = "xml", bool language = false)
        {
            Dictionary<string, string> oParameters = new Dictionary<string, string>();
            oParameters.Add("format", format);
         

            if (language)
            {
                oParameters.Add("Language", System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName);
            }
            return oParameters;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>

   







        private Uri ProcessRequest(string sURL, Dictionary<string, string> oParameters)
        {

            string sSeparator = "&";

      
            // Argument validation
            if (string.IsNullOrEmpty(sURL))
            {
                throw new ArgumentException("Request URL is mandatory parameter.");
            }

            // Build the URL
            var sRequest = sURL;
            foreach (var oParameter in oParameters.Keys)
            {
                var bIndInsertSeparator = !((sRequest[sRequest.Length - 1] == '&') || (sRequest[sRequest.Length - 1] == '?'));
                sRequest = string.Concat(sRequest, (bIndInsertSeparator ? sSeparator : ""), oParameter, "=", oParameters[oParameter]);
            }
            return new Uri(sRequest);





        }

        async Task<REST.Models.RESTResult<T>> DoHttpGet<T>(StringBuilder Url)
        {


            var r = new REST.Models.RESTResult<T>();

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(Uri.EscapeUriString(Url.ToString()), UriKind.RelativeOrAbsolute));

                response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //var content = await response.Content.ReadAsStringAsync();
                    //Debug.WriteLine(content);
                    // r.DATA = content.FromJson<T>();

                    var content = await response.Content.ReadAsStringAsync();
                    r.Error = new REST.Models.Error { HasError = false };
                    if (typeof(T) != typeof(String))
                        r.DATA = content.FromJson<T>();
                    else
                        r.RAW = content;
                }
                else
                {
                    r.Error.HasError = true;
                    r.Error.Message = string.Format("http error: {0}", response.StatusCode.ToString());
                    r.Error.ErrorCode = response.StatusCode.ToString();
                    r.RAW = await response.Content.ReadAsStringAsync();
                }
            }
            catch (HttpRequestException hex)
            {
                r.Error.HasError = true;
                r.Error.Message = string.Format("http error: {0}", hex.Message);
                r.Error.ErrorCode = response.StatusCode.ToString();

            }
            catch (Exception ex)
            {
                r.Error.HasError = true;
                r.Error.Message = string.Format("http error: {0}", ex.Message);

            }
            return r;
        }


        async Task<REST.Models.RESTResult<T>> DoHttpDelete<T>(StringBuilder Url)
        {


            var r = new REST.Models.RESTResult<T>();
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, new Uri(Url.ToString(), UriKind.RelativeOrAbsolute));
                response = await client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(content);
                r.Error = new REST.Models.Error { HasError = false };
                r.DATA = content.FromJson<T>();
            }
            catch (HttpRequestException hex)
            {
                r.Error.HasError = true;
                r.Error.Message = string.Format("http error: {0}", hex.Message);
                r.Error.ErrorCode = response.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                r.Error.HasError = true;
                r.Error.Message = string.Format("http error: {0}", ex.Message);
            }
            return r;

        }

        async Task<REST.Models.RESTResult<T>> DoHttpPut<T>(StringBuilder Url)
        {


            var r = new REST.Models.RESTResult<T>();
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, new Uri(Url.ToString(), UriKind.RelativeOrAbsolute));
                response = await client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(content);
                r.Error = new REST.Models.Error { HasError = false };
                r.DATA = content.FromJson<T>();
            }
            catch (HttpRequestException hex)
            {
                r.Error.HasError = true;
                r.Error.Message = string.Format("http error: {0}", hex.Message);
                r.Error.ErrorCode = response.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                r.Error.HasError = true;
                r.Error.Message = string.Format("http error: {0}", ex.Message);

            }
            return r;
        }


        /// <summary>
        /// Post JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        async Task<REST.Models.RESTResult<T>> DoHttpPostJson<T>(StringBuilder Url, Object data)
        {


            var r = new REST.Models.RESTResult<T>();
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(Url.ToString(), UriKind.RelativeOrAbsolute));
                request.Content = new StringContent(data.ToJson(), Encoding.UTF8, "application/json");
                response = await client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                r.DATA = content.FromJson<T>();
                r.RAW = content;
                //response.EnsureSuccessStatusCode();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    r.Error = new REST.Models.Error { HasError = false };
                }
                else
                {
                    r.Error = new REST.Models.Error { HasError = true };
                    r.Error.Message = string.Format("http error: {0}", response.StatusCode.ToString());
                    r.Error.ErrorCode = response.StatusCode.ToString();
                }
            }
            catch (HttpRequestException hex)
            {
                r.Error.HasError = true;
                r.Error.Message = string.Format("http error: {0}", hex.Message);
                r.Error.ErrorCode = response.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                r.Error.HasError = true;
                r.Error.Message = string.Format("http error: {0}", ex.Message);

            }

            return r;

        }

        /// <summary>
        /// POST FORM
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        async Task<REST.Models.RESTResult<T>> DoHttpPostForm<T>(StringBuilder Url, List<KeyValuePair<string, string>> data)
        {


            var r = new REST.Models.RESTResult<T>();
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {

                response = await client.PostAsync(Url.ToString(), new FormUrlEncodedContent(data));
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    r.Error = new REST.Models.Error { HasError = false };
                    if (typeof(T) != typeof(String))
                        r.DATA = content.FromJson<T>();
                    else
                        r.RAW = content;
                }
                else
                {
                    r.Error.HasError = true;
                    var body = await response.Content.ReadAsStringAsync();
                    r.Error.Message = string.Format("http error: {0}", response.StatusCode.ToString());
                    r.Error.ErrorCode = response.StatusCode.ToString();
                    r.RAW = body;
                }
            }
            catch (HttpRequestException hex)
            {
                r.Error.HasError = true;
                r.Error.Message = string.Format("http error: {0}", hex.Message);
                r.Error.ErrorCode = response.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                r.Error.HasError = true;
                r.Error.Message = string.Format("http error: {0}", ex.Message);
            }
            return r;
        }




    }
}
