using System;
using System.Collections.Generic;
using System.Text;
using DBconnect;

namespace Logging
{
    public class LogToDB
    {
        private string Logging(string type, string message, string username = "")
        {
            var sql = $"INSERT INTO log VALUES ('{DateTime.Now}', '{type}', '{username}', '{message}')";
            return sql;
        }
        public void Log(string type, string username, string message)
        {
            DBconnection db = new DBconnection();
            if (db.InsertQuery(Logging(type, message, username)) != -1)
            {
                db.Close();
            }
            else
            {
                var logToFile = new LogToFile();
                logToFile.Error("Не удалось подключиться к БД");
            }
        }
        public void Info(string message, string username)
        {
            DBconnection db = new DBconnection();
            if (db.InsertQuery(Logging("INFO", message, username)) != -1)
            {
                db.Close();
            }
            else
            {
                var logToFile = new LogToFile();
                logToFile.Error("Не удалось подключиться к БД");
            }
        }
        public void Error(string message, string username)
        {
            DBconnection db = new DBconnection();
            if (db.InsertQuery(Logging("ERROR", message, username)) != -1)
            {
                db.Close();
            }
            else
            {
                var logToFile = new LogToFile();
                logToFile.Error("Не удалось подключиться к БД");
            }
        }
        public void Warning(string message, string username)
        {
            DBconnection db = new DBconnection();
            if (db.InsertQuery(Logging("WARNING", message, username)) != -1)
            {
                db.Close();
            }
            else
            {
                var logToFile = new LogToFile();
                logToFile.Error("Не удалось подключиться к БД");
            }
        }
        public void Fatal(string message, string username)
        {
            DBconnection db = new DBconnection();
            if (db.InsertQuery(Logging("FATAL", message, username)) != -1)
            {
                db.Close();
            }
            else
            {
                var logToFile = new LogToFile();
                logToFile.Fatal(Logging("FATAL", username, message));
            }
        }
        public void Success(string message, string username)
        {
            DBconnection db = new DBconnection();
            if (db.InsertQuery(Logging("SUCCESS",message,username)) != -1)
            {
                db.Close();
            }
            else
            {
                var logToFile = new LogToFile();
                logToFile.Error("Не удалось подключиться к БД");
            }
        }
    }
}
