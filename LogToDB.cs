using System;
using System.Collections.Generic;
using System.Text;
using DBconnect;
using System.Threading.Tasks;

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

        public async Task<string> AsyncLog(string type, string username, string message)
        {
            return await Task.Run(() =>
            {
                Log(type, username, message);
                return "Success";
            });
        }

        public async Task<string> AsyncInfo(string message, string username)
        {
            return await Task.Run(() =>
            {
                Info(message, username);
                return "Success";
            });
        }

        public async Task<string> AsyncError(string message, string username)
        {
            return await Task.Run(() =>
            {
                Error(message, username);
                return "Success";
            });
        }

        public async Task<string> AsyncWarning(string message, string username)
        {
            return await Task.Run(() =>
            {
                Warning(message, username);
                return "Success";
            });
        }

        public async Task<string> AsyncFatal(string message, string username)
        {
            return await Task.Run(() =>
            {
                Fatal(message, username);
                return "Success";
            });
        }

        public async Task<string> AsyncSucces(string message, string username)
        {
            return await Task.Run(() =>
            {
                Success(message, username);
                return "Success";
            });
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
                mess?.Invoke("Не удалось подключиться к БД");
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
                mess?.Invoke("Не удалось подключиться к БД");
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
                mess?.Invoke("Не удалось подключиться к БД");
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
                mess?.Invoke("Не удалось подключиться к БД");
            }
        }
        public void Success(string message, string username)
        {
            DBconnection db = new DBconnection();
            if (db.InsertQuery(Logging("SUCCESS", message, username)) != -1)
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
