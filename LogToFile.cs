using System;
using System.IO;
using System.Text;

namespace Logging
{
    public static class LogToFile
    {
        public static void Log(string path, string type, string message)
        {
            var msg = $"{DateTime.Now} [{type}] : {message}";
            using var file = new StreamWriter(path, true, Encoding.UTF8);
            file.WriteLine(msg);
        }
    }
}