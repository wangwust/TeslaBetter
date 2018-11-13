﻿using System;
using System.IO;
using System.Threading;
using System.Web;

namespace Tesla.Utils
{
    /// <summary>
    /// 文件下载帮助类
    /// </summary>
    public class FileDownHelper
    {
        public FileDownHelper()
        {

        }

        /// <summary>
        /// 获取文件扩展名
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFileExtension(string fileName)
        {
            return Path.GetExtension(MapPathFile(fileName));
        }

        /// <summary>
        /// 获取文件路径
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string MapPathFile(string fileName)
        {
            return HttpContext.Current.Server.MapPath(fileName);
        }

        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsFileExists(string fileName)
        {
            return File.Exists(fileName);
        }

        /// <summary>
        /// 下载文件 HttpContext的方式
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="name"></param>
        public static void DownLoadOld(string fileName, string name)
        {
            string destFileName = fileName;
            if (File.Exists(destFileName))
            {
                FileInfo fi = new FileInfo(destFileName);
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ClearHeaders();
                HttpContext.Current.Response.Buffer = false;
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(name, System.Text.Encoding.UTF8));
                HttpContext.Current.Response.AppendHeader("Content-Length", fi.Length.ToString());
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.WriteFile(destFileName);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
        }

        /// <summary>
        /// 下载文件 文件流的方式
        /// </summary>
        /// <param name="fileName"></param>
        public static void DownLoad(string fileName)
        {
            string filePath = MapPathFile(fileName);
            long chunkSize = 204800;             //指定块大小 
            byte[] buffer = new byte[chunkSize]; //建立一个200K的缓冲区 
            long dataToRead = 0;                 //已读的字节数   
            FileStream stream = null;
            try
            {
                //打开文件   
                stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                dataToRead = stream.Length;

                //添加Http头   
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachement;filename=" + HttpUtility.UrlEncode(Path.GetFileName(filePath)));
                HttpContext.Current.Response.AddHeader("Content-Length", dataToRead.ToString());

                while (dataToRead > 0)
                {
                    if (HttpContext.Current.Response.IsClientConnected)
                    {
                        int length = stream.Read(buffer, 0, Convert.ToInt32(chunkSize));
                        HttpContext.Current.Response.OutputStream.Write(buffer, 0, length);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.Clear();
                        dataToRead -= length;
                    }
                    else
                    {
                        dataToRead = -1; //防止client失去连接 
                    }
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("Error:" + ex.Message);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
                HttpContext.Current.Response.Close();
            }
        }

        /// <summary>
        /// 暂时不动是干啥的
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <param name="fileName"></param>
        /// <param name="fullPath"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        public static bool ResponseFile(HttpRequest request, HttpResponse response, string fileName, string fullPath, long speed)
        {
            try
            {
                FileStream fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                BinaryReader reader = new BinaryReader(fileStream);
                try
                {
                    response.AddHeader("Accept-Ranges", "bytes");
                    response.Buffer = false;

                    long fileLength = fileStream.Length;
                    long startBytes = 0;
                    int pack = 10240;  //10K bytes
                    int sleep = (int)Math.Floor((double)(1000 * pack / speed)) + 1;

                    if (request.Headers["Range"] != null)
                    {
                        response.StatusCode = 206;
                        string[] range = request.Headers["Range"].Split(new char[] { '=', '-' });
                        startBytes = Convert.ToInt64(range[1]);
                    }

                    response.AddHeader("Content-Length", (fileLength - startBytes).ToString());

                    if (startBytes != 0)
                    {
                        response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, fileLength - 1, fileLength));
                    }

                    response.AddHeader("Connection", "Keep-Alive");
                    response.ContentType = "application/octet-stream";
                    response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));

                    reader.BaseStream.Seek(startBytes, SeekOrigin.Begin);
                    int maxCount = (int)Math.Floor((double)((fileLength - startBytes) / pack)) + 1;

                    for (int i = 0; i < maxCount; i++)
                    {
                        if (response.IsClientConnected)
                        {
                            response.BinaryWrite(reader.ReadBytes(pack));
                            Thread.Sleep(sleep);
                        }
                        else
                        {
                            i = maxCount;
                        }
                    }
                }
                catch
                {
                    return false;
                }
                finally
                {
                    reader.Close();
                    fileStream.Close();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
