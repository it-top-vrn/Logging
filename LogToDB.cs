using System;
using System.Collections.Generic;
using System.Text;

namespace Logging
{
    class LogToDB
    {
        public string Log(string type, string username, string message)
        {
            var sql = $"INSERT INTO log VALUES ('{DateTime.Now}', '{type}', '{username}', '{message}')";
            return sql;
        }
        public string Info(string message, string idUser)
        {
            return Log("INFO", username, message);
        }
        public string Error(string message, string idUser)
        {
            return Log("ERROR", username, message);
        }
        public string Warning(string message, string idUser)
        {
            return Log("WARNING", username, message);
        }
        public string Fatal(string message, string idUser)
        {
            return Log("FATAL", username, message);
        }
        public string Success(string message, string idUser)
        {
            return Log("SUCCES", username, message);
        }
    }
}
