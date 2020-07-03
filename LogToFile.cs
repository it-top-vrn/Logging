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

        public static void RegInfo(string login)
        {
            Log(@"Logging\Reg\Log.log", "Info", $"{login} отправил заявку на регистрацию.");
        }

        public static void RegError(string login)
        {
            Log(@"Logging\Reg\Log.log", "Error!", $"{login} попытка регистрации не удалась!");
        }

        public static void AutorizationInfo(string login)
        {
            Log(@"Logging\Autorization\Log.log", "Info", $"Пользователь {login} авторизовался.");
        }

        public static void AutorizationError(string login)
        {
            Log(@"Logging\Autorization\Log.log", "Error!", $"Попытка авторизации пользователя {login} не удалась");
        }
    }
}