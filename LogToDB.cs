using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBconnect;

namespace Logging
{
    public delegate void Message(string message);
    public class LogToDB
    {
        public event Message mess;
        private string Logging(string type, string message, string username = "")
        {
            var sql = $"INSERT INTO log VALUES ('{DateTime.Now}', '{type}', '{username}', '{message}')";
            return sql;
        }
        public void Log(string type, string username, string message)
        {
            DBconnection db = new DBconnection();
            db.ConnectDB();
            if (db.InsertQuery(Logging(type, message, username)) != -1)
            {
                db.Close();
            }
            else
            {
                mess?.Invoke("Не удалось подключиться к БД");
            }
        }
        public void Info(string message, string username)
        {
            DBconnection db = new DBconnection();
            db.ConnectDB();
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
            db.ConnectDB();
            if (db.InsertQuery(Logging("ERROR", message, username)) != -1)
            {
                db.Close();
            }
            else
            {
                mess?.Invoke("Не удалось подключиться к БД");
            }
        }
        public void Warning(string message, string username)
        {
            DBconnection db = new DBconnection();
            db.ConnectDB();
            if (db.InsertQuery(Logging("WARNING", message, username)) != -1)
            {
                db.Close();
            }
            else
            {
                mess?.Invoke("Не удалось подключиться к БД");
            }
        }
        public void Fatal(string message, string username)
        {
            DBconnection db = new DBconnection();
            db.ConnectDB();
            if (db.InsertQuery(Logging("FATAL", message, username)) != -1)
            {
                db.Close();
            }
            else
            {
                mess?.Invoke("Не удалось подключиться к БД");
            }
        }
        public void Success(string message, string username)
        {
            DBconnection db = new DBconnection();
            db.ConnectDB();
            if (db.InsertQuery(Logging("SUCCESS",message,username)) != -1)
            {
                db.Close();
            }
            else
            {
                mess?.Invoke("Не удалось подключиться к БД");
            }
        }

        //Async methods
        async public Task LogAsync(string type, string username, string message)
        {
            DBconnection db = new DBconnection();
            db.ConnectDBAsync();
            if (await db.InsertQueryAsync(Logging(type, message, username)) != -1)
            {
                db.CloseAsync();
            }
            else
            {
                mess?.Invoke("Не удалось подключиться к БД");
            }
        }
        async public Task InfoAsync(string message, string username)
        {
            DBconnection db = new DBconnection();
            db.ConnectDBAsync();
            if (await db.InsertQueryAsync(Logging("INFO", message, username)) != -1)
            {
                db.Close();
            }
            else
            {
                var logToFile = new LogToFile();
                logToFile.Error("Не удалось подключиться к БД");
            }
        }
        async public Task ErrorAsync(string message, string username)
        {
            DBconnection db = new DBconnection();
            db.ConnectDBAsync();
            if (await db.InsertQueryAsync(Logging("ERROR", message, username)) != -1)
            {
                db.Close();
            }
            else
            {
                mess?.Invoke("Не удалось подключиться к БД");
            }
        }
        async public Task WarningAsync(string message, string username)
        {
            DBconnection db = new DBconnection();
            db.ConnectDBAsync();
            if (await db.InsertQueryAsync(Logging("WARNING", message, username)) != -1)
            {
                db.Close();
            }
            else
            {
                mess?.Invoke("Не удалось подключиться к БД");
            }
        }
        async public Task FatalAsync(string message, string username)
        {
            DBconnection db = new DBconnection();
            db.ConnectDBAsync();
            if (await db.InsertQueryAsync(Logging("FATAL", message, username)) != -1)
            {
                db.Close();
            }
            else
            {
                mess?.Invoke("Не удалось подключиться к БД");
            }
        }
        async public Task SuccessAsync(string message, string username)
        {
            DBconnection db = new DBconnection();
            db.ConnectDBAsync();
            if (await db.InsertQueryAsync(Logging("SUCCESS", message, username)) != -1)
            {
                db.Close();
            }
            else
            {
                mess?.Invoke("Не удалось подключиться к БД");
            }
        }
    }
}
