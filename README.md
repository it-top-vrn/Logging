# Logging

Logging.dll нужно для записи логов в файлы и базу данных. 
Класс LogToFail нужен для записи логов в файлы локально.
Класс является публичным, для его использования требуется создать экземпляр класса.
При создании экземпляра класса можно воспользоваться конструктором по умолчанию.
Пример:
```
privat LogToFile log = new LogToFile();  
```
При использовании конструктора по умолчанию используется конфиг LogConfig.cfg. В конфиге указаны пути, где будут храниться файлы с содержанием логов.
Пути по умолчанию:
```
ErrorPath=Logging//Error.log
InfoPath=Logging//Info.log
WarningPath=Logging//Warning.log
FatalPath=Logging//Fatal.log
SuccesPath=Logging//Success.log  
```
Так же при создании экземпляра класса можно воспользоваться конструктором, где можно самостоятельно прописать пути к файлам логов.
Пример:
```
privat LogToFile log = new LogToFile(errorPath, infoPath, warningPath, fatalPath, successPath);
```
Для записи в лог можно использовать готовые функции: Info, Error, Warning, Fatal и Success. Все функции идентичны, при вызове туда передаётся аргумент типа string.
Пример:
```
privat LogToFile log = new LogToFile();  
log.Info("Информация");
```
Таким образом в файле лога Info.log запись будет выглядеть следующим образом:
```
11:34:00 [INFO] : Информация
```
По мимо готовых можно использовать функцию Log, куда передаётся три аргумента типа string.
```
privat LogToFile log = new LogToFile(); 
privat string path = @"Logging\Other.log"; 
privat string type = "OTHER";
privat string message = "Текст сообщения";
log.Log(path, type, message);
```
При вызове в файле Other.log будет записано сообщение:
```
11:34:00 [OTHER] : Текст сообщения
```
