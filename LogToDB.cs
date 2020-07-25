using System;
using System.Collections.Generic;
using System.Text;
using DBconnect;

namespace Logging
{
    public class LogToDB
    {
        private DBconnection db = new DBconnection();
        private string Logging(string type, string username, string message)
        {
            var sql = $"INSERT INTO log VALUES ('{DateTime.Now}', '{type}', '{username}', '{message}')";
            return sql;
        }
        public void Log(string type, string username, string message)
        {
            if()
            {
                var query = new MySqlCommand { Connection = db, CommandText = Logging(type, username, message) };
                query.ExecuteNonQuery();
                db.Close();
            }
            else
            {
                var logToFile = new LogToFile();
                logToFile.Error("Не удалось подключиться к БД");
                logToFile.Error(Logging(type, username, message));
            }
        }
        public void Info(string message, string username)
        {
            db.Open();
            if (db.Ping())
            {
                var query = new MySqlCommand { Connection = db, CommandText = Logging("INFO", username, message) };
                query.ExecuteNonQuery();
                db.Close();
            }
            else
            {
                var logToFile = new LogToFile();
                logToFile.Error("Не удалось подключиться к БД");
                logToFile.Info(Logging("INFO", username, message));
            }
        }
        public void Error(string message, string username)
        {
            db.Open();
            if (db.Ping())
            {
                var query = new MySqlCommand { Connection = db, CommandText = Logging("ERROR", username, message) };
                query.ExecuteNonQuery();
                db.Close();
            }
            else
            {
                var logToFile = new LogToFile();
                logToFile.Error("Не удалось подключиться к БД");
                logToFile.Error(Logging("ERROR", username, message));
            }
        }
        public void Warning(string message, string username)
        {
            db.Open();
            if (db.Ping())
            {
                var query = new MySqlCommand { Connection = db, CommandText = Logging("WARNING", username, message) };
                query.ExecuteNonQuery();
                db.Close();
            }
            else
            {
                var logToFile = new LogToFile();
                logToFile.Error("Не удалось подключиться к БД");
                logToFile.Warning(Logging("WARNING", username, message));
            }
        }
        public void Fatal(string message, string username)
        {
            db.Open();
            if (db.Ping())
            {
                var query = new MySqlCommand { Connection = db, CommandText = Logging("FATAL", username, message) };
                query.ExecuteNonQuery();
                db.Close();
            }
            else
            {
                var logToFile = new LogToFile();
                logToFile.Error("Не удалось подключиться к БД");
                logToFile.Fatal(Logging("FATAL", username, message));
            }
        }
        public void Success(string message, string username)
        {
            db.Open();
            if (db.Ping())
            {
                var query = new MySqlCommand { Connection = db, CommandText = Logging("FATAL", username, message) };
                query.ExecuteNonQuery();
                db.Close();
            }
            else
            {
                var logToFile = new LogToFile();
                logToFile.Error("Не удалось подключиться к БД");
                logToFile.Success(Logging("SUCCESS", username, message));
            }
        }
    }
}
