using System;
using System.IO;
using System.Text;

namespace Logging
{
    public class LogToFile
    {
        private readonly string ErrorPath;
        private readonly string InfoPath;
        private readonly string WarningPath;
        private readonly string FatalPath;
        private readonly string SuccessPath;

        public LogToFile()
        {
            using (var file = new StreamReader("LogConfig.cfg"))
            {
                string tempLine;
                while((tempLine = file.ReadLine()) != null)
                {
                    tempLine = tempLine.Trim();
                    var index = tempLine.IndexOf('=');
                    if(index < 0)
                    {
                        continue;
                    }
                    var tempSymbols = tempLine.Substring(index + 1);
                    var tempVar = tempLine.Substring(0, index);
                    tempSymbols = tempSymbols.Trim();
                    tempVar = tempVar.Trim();

                    switch (tempVar)
                    {
                        case "ErrorPath":
                            ErrorPath = tempSymbols;
                            break;
                        case "InfoPath":
                            InfoPath = tempSymbols;
                            break;
                        case "WarningPath":
                            WarningPath = tempSymbols;
                            break;
                        case "FatalPath":
                            FatalPath = tempSymbols;
                            break;
                        case "SuccessPath":
                            SuccessPath = tempSymbols;
                            break;
                    }
                }
            }
        }

        public LogToFile(string errorPath, string infoPath, string warningPath, string fatalPath, string successPath)
        {
            ErrorPath = errorPath;
            InfoPath = infoPath;
            WarningPath = warningPath;
            FatalPath = fatalPath;
            SuccessPath = successPath;
        }
       

        public void Log(string path, string type, string message)
        {
            var msg = $"{DateTime.Now} [{type}] : {message}";
            using var file = new StreamWriter(path, true, Encoding.UTF8);
            file.WriteLine(msg);
        }

        public void Info(string message)
        {
            Log(InfoPath,"INFO ", $"{message}");
        }
        public void Error(string message)
        {
            Log(ErrorPath,"ERROR", $"{message}");
        }
        public void Warning(string message)
        {
            Log(WarningPath, "WARNING", $"{message}");
        }
        public void Fatal(string message)
        {
            Log(FatalPath, "FATAL", $"{message}");
        }
        public void Success(string message)
        {
            Log(InfoPath, "SUCCESS", $"{message}");
        }
    }
}