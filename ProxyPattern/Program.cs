// Proxy Design Pattern - Structural Pattern
// Mimarimizi proxy pattern'e göre yapılandırırız. Proxy pattern'e göre bir yapı kuruyoruz.

//Ef ile Repository pattern kullandığımızda repository'mizde Get methodu kullandığımızı varsayalım.
//Ama Repository'de bulunan DbContext Add,Delete,Update gibi diğer methodları da barındırıyor.
//Proxy pattern'i burada dahil ederek Repository'i kullanan kişinin sadece Get Methodunu kullanmasını sağlayabiliriz.



ILogger logger = new FileLogger();
logger.Log("Log message");


class BufferedFileLoggerProxy : ILogger
{
    private readonly int bufferSize;
    private readonly FileLogger fileLogger;
    private readonly List<string> buffer;

    public BufferedFileLoggerProxy(int bufferSize)
    {
        this.bufferSize = bufferSize;
        this.buffer = new List<string>(capacity: bufferSize);
        this.fileLogger = new();
    }
    public void Log(string message)
    {
        buffer.Add(message);
        if (buffer.Count >= bufferSize)
        {
            // foreach (var log in buffer)
            // {
            //     fileLogger.Log(message);
            // }
            fileLogger.Log(buffer);
            buffer.Clear();
        }
    }

    public void Log(IEnumerable<string> messages)
    {
        //throw new NotImplementedException(); //FileLogger'i kullanan birisi toplu loglama yapabilirken buffered'da yapılamaz hale getirdik.
        fileLogger.Log(messages);
    }
}

class FileLogger : ILogger
{
    public void Log(string message)
    {
        message = $"[{DateTime.Now:dd.MM.yyyy}] - {message}";
        File.AppendAllText("log.txt", message);
    }
    public void Log(IEnumerable<string> messages)
    {
        File.AppendAllText("message.log", string.Join(Environment.NewLine, messages));
    }

}

interface ILogger
{
    void Log(string message);
    void Log(IEnumerable<string> messages);
}