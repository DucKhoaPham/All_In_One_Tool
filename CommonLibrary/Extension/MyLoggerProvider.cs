using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace QI.Core.Extension
{
    public class MyLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new MyLogger();
        }

        public void Dispose()
        { }

        private class MyLogger : ILogger
        {
            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@"logs\log-dbcontext-{DateTime.Now.ToString("ddMMyy-HH")}.txt");
                File.AppendAllText(filePath, formatter(state, exception));
                Console.WriteLine(formatter(state, exception));
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }
        }
    }
}
