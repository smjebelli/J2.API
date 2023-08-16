using Newtonsoft.Json;
using System.Text;

namespace J2.API.Utilities
{
    public interface IApiClient
    {
        TOut CallRestService<TOut, TInput>(TInput input, string url, HttpMethod httpMethod = null, string bearerToken = null, List<KeyValuePair<string, string>> headerValues = null);
        Task<TOut> CallRestServiceAsync<TOut, TInput>(TInput input, string url, HttpMethod httpMethod = null, string bearerToken = null, List<KeyValuePair<string, string>> headerValues = null);
        Task<TOut> CallRestServiceUrlEncodedAsync<TOut>(Dictionary<string, string> inputParams, string url, HttpMethod httpMethod, string bearerToken = null, List<KeyValuePair<string, string>> headerValues = null);
        Task<TOut> CallRestServiceUrlEncodedAsync<TOut, TInput>(TInput input, Dictionary<string, string> inputParams, string url, HttpMethod httpMethod, string bearerToken = null, List<KeyValuePair<string, string>> headerValues = null);
    }

    public class ApiClient : IApiClient
    {
        public TOut CallRestService<TOut, TInput>(TInput input, string url, HttpMethod httpMethod, string bearerToken = null, List<KeyValuePair<string, string>> headerValues = null)
        {
            var jsonInString = JsonConvert.SerializeObject(input);

            // Log(LogLevels.Trace, jsonInString);
            Serilog.Log.Verbose(jsonInString);

            using var client = new HttpClient();
            try
            {
                if (httpMethod == null)
                {
                    httpMethod = HttpMethod.Get;
                }
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var content = new StringContent(jsonInString, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = httpMethod,
                    RequestUri = new Uri(url),
                    Content = content,
                };

                if (headerValues != null && headerValues.Any())
                {
                    foreach (var headerValue in headerValues)
                    {
                        request.Headers.TryAddWithoutValidation(headerValue.Key, headerValue.Value);
                    }
                }

                if (bearerToken is not null)
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue($"Bearer", $"{bearerToken}");


                HttpResponseMessage result = client.Send(request);

                var returnData = result.Content.ReadAsStream();

                StreamReader reader = new StreamReader(returnData);

                string text = reader.ReadToEnd();


                #region ______ hard coded result ______

                //StreamReader sr = new StreamReader(@"d:\reissue.txt");
                //string text = sr.ReadToEndAsync().Result;
                //sr.Close();

                #endregion

                //Log(LogLevels.Trace, text);
                Serilog.Log.Verbose(text);

                var output = JsonConvert.DeserializeObject<TOut>(text);

                return output;
            }
            catch (Exception ex)
            {
                //Log(LogLevels.Fatal, $"ApiClient.CallRestService \n{ex.Message}", ex);
                Serilog.Log.Fatal($"ApiClient.CallRestService \n{ex.Message}", ex);
                throw ex;
            }
        }

        public async Task<TOut> CallRestServiceAsync<TOut, TInput>(TInput input, string url, HttpMethod httpMethod, string bearerToken = null, List<KeyValuePair<string, string>> headerValues = null)
        {
            var jsonInString = JsonConvert.SerializeObject(input);

            //Log(LogLevels.Trace, jsonInString);
            Serilog.Log.Verbose(jsonInString);

            using var client = new HttpClient();
            try
            {
                if (httpMethod == null)
                {
                    httpMethod = HttpMethod.Get;
                }
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var content = new StringContent(jsonInString, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = httpMethod,
                    RequestUri = new Uri(url),
                    Content = content,

                };
                if (headerValues != null && headerValues.Any())
                {
                    foreach (var headerValue in headerValues)
                    {
                        request.Headers.Add(headerValue.Key, headerValue.Value);
                    }
                }


                if (bearerToken is not null)
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue($"Bearer", $"{bearerToken}");


                HttpResponseMessage result = await client.SendAsync(request);

                if (result.StatusCode.ToString()[0] == '4')
                {
                    //Log(LogLevels.Info, result.StatusCode.ToString());
                    Serilog.Log.Information(result.StatusCode.ToString());

                }

                var returnData = await result.Content.ReadAsStringAsync();

                //Log(LogLevels.Trace, returnData);
                Serilog.Log.Verbose(returnData);

                var output = JsonConvert.DeserializeObject<TOut>(returnData);

                return output;
            }
            catch (Exception ex)
            {
                //Log(LogLevels.Fatal, $"ApiClient.CallRestServiceAsync \n{ex.Message}", ex);
                Serilog.Log.Fatal($"ApiClient.CallRestServiceAsync \n{ex.Message}", ex);
                throw ex;
            }
        }

        public async Task<TOut> CallRestServiceUrlEncodedAsync<TOut>(Dictionary<string, string> inputParams, string url, HttpMethod httpMethod, string bearerToken = null, List<KeyValuePair<string, string>> headerValues = null)
        {
            //var jsonInString = JsonConvert.SerializeObject(input);
            using var client = new HttpClient();
            try
            {
                if (httpMethod == null)
                {
                    httpMethod = HttpMethod.Get;
                }
                //client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                //var content = new StringContent(jsonInString, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = httpMethod,
                    RequestUri = new Uri(url),
                    //Content = content,
                };

                if (headerValues != null && headerValues.Any())
                {
                    foreach (var headerValue in headerValues)
                    {
                        request.Headers.Add(headerValue.Key, headerValue.Value);
                    }
                }
                HttpResponseMessage result = await client.PostAsync(url, new FormUrlEncodedContent(inputParams));

                var returnData = await result.Content.ReadAsStringAsync();

                //Log(LogLevels.Trace, returnData);

                //StreamReader reader = new StreamReader(returnData);
                //string text = reader.ReadToEnd();

                var output = JsonConvert.DeserializeObject<TOut>(returnData);

                return output;
            }
            catch (Exception ex)
            {
                //Log(LogLevels.Fatal, $"ApiClient.CallRestServiceUrlEncodedAsync \n{ex.Message}", ex);
                Serilog.Log.Fatal($"ApiClient.CallRestServiceUrlEncodedAsync \n{ex.Message}", ex);
                throw ex;
            }
        }

        public async Task<TOut> CallRestServiceUrlEncodedAsync<TOut, TInput>(TInput input, Dictionary<string, string> inputParams, string url, HttpMethod httpMethod, string bearerToken = null, List<KeyValuePair<string, string>> headerValues = null)
        {
            var jsonInString = JsonConvert.SerializeObject(input);

            //Log(LogLevels.Trace, jsonInString);
            Serilog.Log.Verbose(jsonInString);

            using var client = new HttpClient();
            try
            {
                if (httpMethod == null)
                {
                    httpMethod = HttpMethod.Get;
                }
                //client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var content = new StringContent(jsonInString, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = httpMethod,
                    RequestUri = new Uri(url),
                    Content = content,
                };

                if (headerValues != null && headerValues.Any())
                {
                    foreach (var headerValue in headerValues)
                    {
                        request.Headers.Add(headerValue.Key, headerValue.Value);
                    }
                }



                if (bearerToken is not null)
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue($"Bearer", $"{bearerToken}");

                HttpResponseMessage result = await client.SendAsync(request);

                var returnData = await result.Content.ReadAsStringAsync();

                //Log(LogLevels.Trace, returnData);
                Serilog.Log.Verbose(returnData);

                var output = JsonConvert.DeserializeObject<TOut>(returnData);

                return output;
            }
            catch (Exception ex)
            {
                //Log(LogLevels.Fatal, $"ApiClient.CallRestServiceUrlEncodedAsync \n{ex.Message}", ex);
                Serilog.Log.Fatal($"ApiClient.CallRestServiceUrlEncodedAsync \n{ex.Message}", ex);
                throw ex;
            }
        }
    }

}
