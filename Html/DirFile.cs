using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
namespace Html
{
    public class DirFile
    {
       

        public static void CreateDir(string dir)
        {
            if (dir.Length == 0) return;
            if (!Directory.Exists(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir))
                Directory.CreateDirectory(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir);
        }
        public static void CreateFile(string dir, string pagestr)
        {
            dir = dir.Replace("/", "\\");
            if (dir.IndexOf("\\") > -1)
                CreateDir(dir.Substring(0, dir.LastIndexOf("\\")));
            System.IO.StreamWriter sw = new System.IO.StreamWriter(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir, false, System.Text.Encoding.GetEncoding("GB2312"));
            sw.Write(pagestr);
            sw.Close();
        }

        public static string ReadFile(string tempDir)
        {
            string str2=System.Web.HttpContext.Current.Request.PhysicalApplicationPath + tempDir;
            if (File.Exists(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + tempDir))
            {
                StreamReader sr = new StreamReader(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + tempDir, System.Text.Encoding.Default);
                string str = sr.ReadToEnd();
                sr.Close();
                return str;
            }
            return "未找到文件：" + tempDir;
        }
    }
}
