using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 多项启动
{
    internal class Program
    {
        readonly static string startPath="./启动.txt";
        static void Main(string[] args)
        {
            string[] paths = File.ReadAllLines(startPath);

            foreach (string path in paths)
            {
                OpenApp(path);
            }
            
        }

        public static void OpenApp(string path)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = path,
                Verb = "runas" // 使用管理员权限运行
            };

            try
            {
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                // 处理启动应用程序的异常
                Console.WriteLine("无法启动应用程序： " + ex.Message);
            }
        }


    }
}
