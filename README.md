# Logging

**Logging.dll** нужно для записи логов в файлы и базу данных. 
Класс *LogToFile* нужен для записи логов в файлы локально.
Класс является публичным, для его использования требуется создать экземпляр класса.
При создании экземпляра класса можно воспользоваться конструктором по умолчанию.

Пример: `private LogToFile log = new LogToFile();`
___
При использовании конструктора по умолчанию используется конфигурационный файл `LogConfig.cfg`. В конфиге указаны пути, где будут храниться файлы с содержанием логов.
___
Пути по умолчанию:
```config
ErrorPath=Logging//Error.log
InfoPath=Logging//Info.log
WarningPath=Logging//Warning.log
FatalPath=Logging//Fatal.log
SuccesPath=Logging//Success.log  
```
___
Так же при создании экземпляра класса можно воспользоваться конструктором, где можно самостоятельно прописать пути к файлам логов. Пример: `private LogToFile log = new LogToFile(errorPath, infoPath, warningPath, fatalPath, successPath);`
___
Для записи в лог можно использовать готовые методы класса: *Info*, *Error*, *Warning*, *Fatal* и *Success*. Все методы имеют один аргумент - сообщение (тип переменной `string`).
___
Пример:
```csharp
private LogToFile log = new LogToFile();  
log.Info("Информация");
```
___
Таким образом в файле лога Info.log запись будет выглядеть следующим образом:
```
11:34:00 [INFO] : Информация
```
___
Помимо готовых можно использовать функцию *Log*, куда передаётся три аргумента типа string.
___
Пример:
```csharp
private LogToFile log = new LogToFile(); 
private string path = @"Logging\Other.log"; 
private string type = "OTHER";
private string message = "Текст сообщения";
log.Log(path, type, message);
```
___
При вызове в файле *Other.log* будет записано сообщение:
```
11:34:00 [OTHER] : Текст сообщения
```
___
