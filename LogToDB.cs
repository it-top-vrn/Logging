using System;
using System.Collections.Generic;
using System.Text;

namespace Logging
{
    class LogToDB
    {
        public string Log(string type, string idUser, string message)
        {
            var sql = $"INSERT INTO log VALUES ('{DateTime.Now}', '{type}', '{idUser}', '{message}')";
            return sql;
        }
        public string Info(string message, string idUser)
        {
            return Log("INFO", idUser, message);
        }
        public string Error(string message, string idUser)
        {
            return Log("ERROR", idUser, message);
        }
        public string Warning(string message, string idUser)
        {
            return Log("WARNING", idUser, message);
        }
        public string Fatal(string message, string idUser)
        {
            return Log("FATAL", idUser, message);
        }
        public string Success(string message, string idUser)
        {
            return Log("SUCCES", idUser, message);
        }
    }
}
