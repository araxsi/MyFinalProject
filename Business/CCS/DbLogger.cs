using Business.CCS;
using System;

public class DbLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine("Veri Tabanına Loglandı.");
    }
}
