﻿/*******************************************************************************
 * Copyright © 2018 Tesla 版权所有
 * Author: Tony Stack


*********************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
namespace Tesla.Utils
{
    /// <summary>
    /// 网站帮助类
    /// </summary>
    public class WebHelper
    {
        #region ResolveUrl(解析相对Url)

        /// <summary>
        /// 解析相对Url
        /// </summary>
        /// <param name="relativeUrl">相对Url</param>
        public static string ResolveUrl(string relativeUrl)
        {
            if (string.IsNullOrWhiteSpace(relativeUrl))
            {
                return string.Empty;
            }

            relativeUrl = relativeUrl.Replace("\\", "/");

            if (relativeUrl.StartsWith("/"))
            {
                return relativeUrl;
            }

            if (relativeUrl.Contains("://"))
            {
                return relativeUrl;
            }

            return VirtualPathUtility.ToAbsolute(relativeUrl);
        }

        #endregion

        #region HtmlEncode(对html字符串进行编码)

        /// <summary>
        /// 对html字符串进行编码
        /// </summary>
        /// <param name="html">html字符串</param>
        public static string HtmlEncode(string html)
        {
            return HttpUtility.HtmlEncode(html);
        }
        /// <summary>
        /// 对html字符串进行解码
        /// </summary>
        /// <param name="html">html字符串</param>
        public static string HtmlDecode(string html)
        {
            return HttpUtility.HtmlDecode(html);
        }

        #endregion

        #region UrlEncode(对Url进行编码)

        /// <summary>
        /// 对Url进行编码
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="isUpper">编码字符是否转成大写,范例,"http://"转成"http%3A%2F%2F"</param>
        public static string UrlEncode(string url, bool isUpper = false)
        {
            return UrlEncode(url, Encoding.UTF8, isUpper);
        }

        /// <summary>
        /// 对Url进行编码
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="isUpper">编码字符是否转成大写,范例,"http://"转成"http%3A%2F%2F"</param>
        public static string UrlEncode(string url, Encoding encoding, bool isUpper = false)
        {
            var result = HttpUtility.UrlEncode(url, encoding);
            if (!isUpper)
            {
                return result;
            }

            return GetUpperEncode(result);
        }

        /// <summary>
        /// 获取大写编码字符串
        /// </summary>
        private static string GetUpperEncode(string encode)
        {
            var result = new StringBuilder();
            int index = int.MinValue;
            for (int i = 0; i < encode.Length; i++)
            {
                string character = encode[i].ToString();
                if (character == "%")
                {
                    index = i;
                }

                if (i - index == 1 || i - index == 2)
                {
                    character = character.ToUpper();
                }
                result.Append(character);
            }
            return result.ToString();
        }

        #endregion

        #region UrlDecode(对Url进行解码)

        /// <summary>
        /// 对Url进行解码,对于javascript的encodeURIComponent函数编码参数,应使用utf-8字符编码来解码
        /// </summary>
        /// <param name="url">url</param>
        public static string UrlDecode(string url)
        {
            return HttpUtility.UrlDecode(url);
        }

        /// <summary>
        /// 对Url进行解码,对于javascript的encodeURIComponent函数编码参数,应使用utf-8字符编码来解码
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="encoding">字符编码,对于javascript的encodeURIComponent函数编码参数,应使用utf-8字符编码来解码</param>
        public static string UrlDecode(string url, Encoding encoding)
        {
            return HttpUtility.UrlDecode(url, encoding);
        }

        #endregion

        #region Session操作

        /// <summary>
        /// 写Session
        /// </summary>
        /// <typeparam name="T">Session键值的类型</typeparam>
        /// <param name="key">Session的键名</param>
        /// <param name="value">Session的键值</param>
        public static void WriteSession<T>(string key, T value)
        {
            if (key.IsEmpty())
            {
                return;
            }

            HttpContext.Current.Session[key] = value;
        }

        /// <summary>
        /// 写Session
        /// </summary>
        /// <param name="key">Session的键名</param>
        /// <param name="value">Session的键值</param>
        public static void WriteSession(string key, string value)
        {
            WriteSession<string>(key, value);
        }

        /// <summary>
        /// 读取Session的值
        /// </summary>
        /// <param name="key">Session的键名</param>        
        public static string GetSession(string key)
        {
            if (key.IsEmpty())
            {
                return string.Empty;
            }

            return HttpContext.Current.Session[key] as string;
        }

        /// <summary>
        /// 删除指定Session
        /// </summary>
        /// <param name="key">Session的键名</param>
        public static void RemoveSession(string key)
        {
            if (key.IsEmpty())
                return;
            HttpContext.Current.Session.Contents.Remove(key);
        }

        #endregion

        #region Cookie操作

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="key">名称</param>
        /// <param name="value">值</param>
        public static void WriteCookie(string key, string value)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[key];
            if (cookie == null)
            {
                cookie = new HttpCookie(key);
            }

            cookie.Value = value;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="key">名称</param>
        /// <param name="value">值</param>
        /// <param name="expires">过期时间(分钟)</param>
        public static void WriteCookie(string key, string value, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[key];
            if (cookie == null)
            {
                cookie = new HttpCookie(key);
            }

            cookie.Value = value;
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="key">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string key)
        {
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                return HttpContext.Current.Request.Cookies[key].Value;
            }
            return "";
        }

        /// <summary>
        /// 删除Cookie对象
        /// </summary>
        /// <param name="cookiesName">Cookie对象名称</param>
        public static void RemoveCookie(string cookiesName)
        {
            HttpCookie objCookie = new HttpCookie(cookiesName.Trim());
            objCookie.Expires = DateTime.Now.AddYears(-5);
            HttpContext.Current.Response.Cookies.Add(objCookie);
        }

        #endregion

        #region GetFileControls(获取客户端文件控件集合)

        /// <summary>
        /// 获取有效客户端文件控件集合,文件控件必须上传了内容，为空将被忽略,
        /// 注意:Form标记必须加入属性 enctype="multipart/form-data", 服务器端才能获取客户端file控件.
        /// </summary>
        public static List<HttpPostedFile> GetFileControls()
        {
            var result = new List<HttpPostedFile>();
            var files = HttpContext.Current.Request.Files;
            if (files.Count == 0)
                return result;
            for (int i = 0; i < files.Count; i++)
            {
                var file = files[i];
                if (file.ContentLength == 0)
                    continue;
                result.Add(files[i]);
            }
            return result;
        }

        #endregion

        #region GetFileControl(获取第一个有效客户端文件控件)

        /// <summary>
        /// 获取第一个有效客户端文件控件,文件控件必须上传了内容，为空将被忽略,
        /// 注意:Form标记必须加入属性 enctype="multipart/form-data",服务器端才能获取客户端file控件.
        /// </summary>
        public static HttpPostedFile GetFileControl()
        {
            var files = GetFileControls();
            if (files == null || files.Count == 0)
            {
                return null;
            }
            return files[0];
        }

        #endregion

        #region HttpWebRequest(请求网络资源)

        /// <summary>
        /// 请求网络资源,返回响应的文本
        /// </summary>
        /// <param name="url">网络资源地址</param>
        public static string HttpWebRequest(string url)
        {
            return HttpWebRequest(url, string.Empty, Encoding.GetEncoding("utf-8"));
        }

        /// <summary>
        /// 请求网络资源,返回响应的文本
        /// </summary>
        /// <param name="url">网络资源Url地址</param>
        /// <param name="parameters">提交的参数,格式：参数1=参数值1&amp;参数2=参数值2</param>
        public static string HttpWebRequest(string url, string parameters)
        {
            return HttpWebRequest(url, parameters, Encoding.GetEncoding("utf-8"), true);
        }

        /// <summary>
        /// 请求网络资源,返回响应的文本
        /// </summary>
        /// <param name="url">网络资源地址</param>
        /// <param name="parameters">提交的参数,格式：参数1=参数值1&amp;参数2=参数值2</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="isPost">是否Post提交</param>
        /// <param name="contentType">内容类型</param>
        /// <param name="cookie">Cookie容器</param>
        /// <param name="timeout">超时时间</param>
        public static string HttpWebRequest(string url, string parameters, Encoding encoding, bool isPost = false,
             string contentType = "application/x-www-form-urlencoded", CookieContainer cookie = null, int timeout = 120000)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = timeout;
            request.CookieContainer = cookie;
            if (isPost)
            {
                byte[] postData = encoding.GetBytes(parameters);
                request.Method = "POST";
                request.ContentType = contentType;
                request.ContentLength = postData.Length;
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(postData, 0, postData.Length);
                }
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string result;
            using (Stream stream = response.GetResponseStream())
            {
                if (stream == null)
                    return string.Empty;
                using (var reader = new StreamReader(stream, encoding))
                {
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }

        #endregion

        #region 去除HTML标记

        /// <summary>
        /// 去除HTML标记
        /// </summary>
        /// <param name="htmlstring">包括HTML的源码 </param>
        /// <returns>已经去除后的文字</returns>
        public static string NoHtml(string htmlstring)
        {
            //删除脚本
            htmlstring = Regex.Replace(htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            htmlstring = Regex.Replace(htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&hellip;", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&mdash;", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&ldquo;", "", RegexOptions.IgnoreCase);
            htmlstring = htmlstring.Replace("<", "");
            htmlstring = Regex.Replace(htmlstring, @"&rdquo;", "", RegexOptions.IgnoreCase);
            htmlstring = htmlstring.Replace(">", "");
            htmlstring = htmlstring.Replace("\r\n", "");
            htmlstring = HttpContext.Current.Server.HtmlEncode(htmlstring).Trim();
            return htmlstring;
        }

        #endregion

        #region 格式化文本（防止SQL注入）

        /// <summary>
        /// 格式化文本（防止SQL注入）
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string Formatstr(string html)
        {
            Regex regex1 = new Regex(@"<script[\s\S]+</script *>", RegexOptions.IgnoreCase);
            Regex regex2 = new Regex(@" href *= *[\s\S]*script *:", RegexOptions.IgnoreCase);
            Regex regex3 = new Regex(@" on[\s\S]*=", RegexOptions.IgnoreCase);
            Regex regex4 = new Regex(@"<iframe[\s\S]+</iframe *>", RegexOptions.IgnoreCase);
            Regex regex5 = new Regex(@"<frameset[\s\S]+</frameset *>", RegexOptions.IgnoreCase);
            Regex regex10 = new Regex(@"select", RegexOptions.IgnoreCase);
            Regex regex11 = new Regex(@"update", RegexOptions.IgnoreCase);
            Regex regex12 = new Regex(@"delete", RegexOptions.IgnoreCase);

            html = regex1.Replace(html, ""); //过滤<script></script>标记
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件
            html = regex4.Replace(html, ""); //过滤iframe
            html = regex10.Replace(html, "s_elect");
            html = regex11.Replace(html, "u_pudate");
            html = regex12.Replace(html, "d_elete");
            html = html.Replace("'", "’");
            html = html.Replace("&nbsp;", " ");
            return html;
        }

        #endregion
    }
}
