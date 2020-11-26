using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace UIFrameworkCore.Helper.NetWork
{
    public class ProjectServicesAPI
    {
        public class HttpRequest
        {

            public static string Url = ConfigurationManager.AppSettings["URL"].ToString();

            #region 单例模式
            private static HttpRequest _HttpRequest = null;
            private static object obj = new object();

            private HttpRequest() { }

            static HttpRequest()
            {
                _HttpRequest = new HttpRequest();
            }

            public static HttpRequest GetSingleObj()
            {
                if (_HttpRequest == null)
                {
                    lock (obj)
                    {
                        if (_HttpRequest == null)
                        {
                            _HttpRequest = new HttpRequest();
                        }
                    }
                }
                return _HttpRequest;
            }
            #endregion

            public string HttpPost(string Api, string postData, bool needAdd = true)
            {
                string api = Api;
                if (needAdd)
                {
                    api = Api + postData.Replace(",", "&").Replace("\":", "=").Replace("\"", "").Replace("{", "?").Replace("}", "").Replace(":", "%3A");
                }

                return HttpPost(api, postData, string.Empty);
            }

            public string HttpPost(string Api, string postData, string token, HttpMethod httpMethod)
            {
                return HttpPost(Api, postData, token, 10, httpMethod);
            }

            public string HttpPost(string Api, string postData, string token, long timeout = 10, HttpMethod httpMethod = HttpMethod.POST)
            {
                System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
                s.Start();
                string strReturn = string.Empty;
                try
                {
                    GC.Collect();
                    ServicePointManager.DefaultConnectionLimit = 50;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + Api);
                    request.Method = Enum.GetName(typeof(HttpMethod), httpMethod);
                    // request.Headers.Add("token:" + token);
                    request.ContentType = "application/json;charset=utf-8";
                    //request.ContentLength = Encoding.UTF8.GetByteCount(postData);
                    //request.CookieContainer = cookie;
                    request.Timeout = (int)(1000 * timeout);

                    Stream myRequestStream = request.GetRequestStream();
                    StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("utf-8"));
                    myStreamWriter.Write(postData);
                    myStreamWriter.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    //response.StatusCode
                    //response.Cookies = cookie.GetCookies(response.ResponseUri);
                    Stream myResponseStream = response.GetResponseStream();
                    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                    strReturn = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                    myResponseStream.Close();
                }
                catch (WebException exxx)
                {
                    strReturn = GetMsg(Api + "[" + postData + "]");
                    throw new Exception(strReturn);
                }
                catch (Exception ex)
                {
                    FileHelper.Appand系统日志Info(ex.Message, "Error");
                    throw (ex);
                }
                s.Stop();

                return strReturn;
            }

            public string HttpGet(string Api)
            {
                return HttpGet(Api, string.Empty, string.Empty);
            }

            public string HttpGet(string Api, string token)
            {
                return HttpGet(Api, string.Empty, token);
            }

            public string HttpGet(string Api, string getData, string token, HttpMethod httpMethod)
            {
                return HttpGet(Api, getData, token, 10, httpMethod);
            }

            public string HttpGet(string Api, string getData, string token, long timeout = 10, HttpMethod httpMethod = HttpMethod.GET)
            {
                System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
                s.Start();
                string strReturn = string.Empty;
                try
                {
                    GC.Collect();
                    ServicePointManager.DefaultConnectionLimit = 50;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + Api + (getData == "" ? "" : "?") + getData);
                    request.Method = Enum.GetName(typeof(HttpMethod), httpMethod);
                    request.Headers.Add("token:" + token);
                    request.ContentType = "text/html;charset=UTF-8";
                    request.Timeout = 1000 * 10;

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream myResponseStream = response.GetResponseStream();
                    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                    strReturn = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                    myResponseStream.Close();
                }
                catch (WebException)
                {
                    strReturn = GetMsg(Api + "[" + getData + "]");
                }
                catch (Exception ex)
                {
                    FileHelper.Appand系统日志Info(ex.Message, "Error");
                    throw (ex);
                }
                s.Stop();


                return strReturn;
            }


            public string HttpGet(string Url,  long timeout = 10, HttpMethod httpMethod = HttpMethod.GET)
            {
                System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
                s.Start();
                string strReturn = string.Empty;
                string sHTML="";
                try
                {
                    GC.Collect();
                    ServicePointManager.DefaultConnectionLimit = 50;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                    request.Method = Enum.GetName(typeof(HttpMethod), httpMethod);
                    request.ContentType = "application/json;charset=UTF-8";
               
                    request.Timeout = 1000 * 10;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (response.ContentEncoding.ToLower().Contains("gzip"))
                    {
                        using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                sHTML = reader.ReadToEnd();
                            }
                        }
                    }
                    else if (response.ContentEncoding.ToLower().Contains("deflate"))
                    {
                        using (DeflateStream stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress))
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                sHTML = reader.ReadToEnd();
                            }
                        }
                    }
                    else
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                sHTML = reader.ReadToEnd();
                            }
                        }
                    }
                 
                }
                catch (WebException)
                {

                }
                catch (Exception ex)
                {
                    FileHelper.Appand系统日志Info(ex.Message, "Error");
                    throw (ex);
                }
                s.Stop();


                return sHTML;
            }

            /// <summary>
            /// 不建议使用，已改为HttpMethod枚举参数
            /// </summary>
            /// <param name="Api"></param>
            /// <param name="getData"></param>
            /// <param name="token"></param>
            /// <returns></returns>
            public string HttpDelete(string Api, string getData, string token)
            {
                System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
                s.Start();
                string strReturn = string.Empty;
                try
                {
                    GC.Collect();
                    ServicePointManager.DefaultConnectionLimit = 50;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + Api + (getData == "" ? "" : "?") + getData);
                    request.Method = "DELETE";
                    request.Headers.Add("token:" + token);
                    request.ContentType = "text/html;charset=UTF-8";
                    request.Timeout = 1000 * 10;

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream myResponseStream = response.GetResponseStream();
                    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                    strReturn = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                    myResponseStream.Close();
                }
                catch (WebException)
                {
                    strReturn = GetMsg(Api + "[" + getData + "]");
                }
                catch (Exception ex)
                {
                    FileHelper.Appand系统日志Info(ex.Message, "Error");
                    throw ex;
                }
                s.Stop();

                return strReturn;
            }
            /// <summary>
            /// 不建议使用，已改为HttpMethod枚举参数
            /// </summary>
            /// <param name="Api"></param>
            /// <param name="getData"></param>
            /// <param name="token"></param>
            /// <returns></returns>
            public string HttpPut(string Api, string getData, string token)
            {
                System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
                s.Start();
                string strReturn = string.Empty;
                try
                {
                    GC.Collect();
                    ServicePointManager.DefaultConnectionLimit = 50;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + Api);
                    request.Method = "PUT";
                    request.Headers.Add("token:" + token);
                    request.ContentType = "application/json";
                    //request.ContentLength = Encoding.UTF8.GetByteCount(postData);
                    //request.CookieContainer = cookie;
                    request.Timeout = 1000 * 10;

                    Stream myRequestStream = request.GetRequestStream();
                    StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("utf-8"));
                    myStreamWriter.Write(getData);
                    myStreamWriter.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    //response.StatusCode
                    //response.Cookies = cookie.GetCookies(response.ResponseUri);
                    Stream myResponseStream = response.GetResponseStream();
                    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                    strReturn = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                    myResponseStream.Close();
                }
                catch (WebException)
                {
                    strReturn = GetMsg(Api + "[" + getData + "]");
                }
                catch (Exception ex)
                {
                    FileHelper.Appand系统日志Info(ex.Message, "Error");
                    throw ex;
                }

                return strReturn;
            }

            /// <summary>
            /// 获取异常提示信息
            /// </summary>
            /// <returns></returns>
            private string GetMsg(string strLog)
            {
                string msg = "{\"code\":404,\"message\":\"当前网络不可用，请检查您的网络设置\"}";
                try
                {
                    if (new Ping().Send("www.baidu.com", 3000).Status == IPStatus.Success)
                    {
                        //msg = "{\"code\":404,\"message\":\"服务器异常，请稍后重试\"}";
                        msg = "{\"code\":404,\"message\":\"连接超时，请稍后重试\"}";
                    }
                }
                catch (Exception ex)
                {
                    FileHelper.Appand系统日志Info(ex.Message, "Error");
                }
                return msg;
            }
        }

        public enum HttpMethod
        {
            POST,
            GET,
            PUT,
            DELETE
        }

        //public Ac<string> AgreeUnBind(string userTaskId, string userId)
        //{
        //    try
        //    {///返回数据不正确，
        //        string postData = JsonConvert.SerializeObject(new { userTaskId = userTaskId, userId = userId });

        //        string strReturn = HttpRequest.GetSingleObj().HttpPost("/device/agreeUnbind", postData);
        //        return JsonConvert.DeserializeObject<RootModel<string>>(strReturn);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
