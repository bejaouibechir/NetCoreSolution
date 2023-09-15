using System.Diagnostics;

namespace WebAppCoreTrace.TraceListeners
{
    public class TraceLoggerProvider : ILoggerProvider
    {
        private readonly TraceSource _traceSource;

        public TraceLoggerProvider(TraceSource traceSource)
        {
            if (traceSource != null)
                _traceSource = traceSource;
            else
                throw new ArgumentNullException();
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new TextLogger(categoryName,_traceSource);
        }

        //Utilisée pour liberer les ressources externes exemple 
        // 1. base de données qui stocke les journeaux
        // 2. fichier/flux 
        // 3. service 
        public void Dispose()
        {
           
            throw new NotImplementedException();
        }
    }
    public class TextLogger : ILogger
    {
        TraceSource _traceSource;
        public TextLogger(string categoryName,TraceSource traceSource)
        {
            if(traceSource == null || string.IsNullOrEmpty(categoryName))
                throw new ArgumentNullException();  
            _traceSource = traceSource;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        //Implémenter la logique de traçage
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            var message = formatter(state, exception);

            // Map ASP.NET Core log levels to TraceSource log levels
            switch (logLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Debug:
                    _traceSource.TraceEvent(TraceEventType.Verbose, 0, message);
                    break;
                case LogLevel.Information:
                    _traceSource.TraceEvent(TraceEventType.Information, 0, message);
                    break;
                case LogLevel.Warning:
                    _traceSource.TraceEvent(TraceEventType.Warning, 0, message);
                    break;
                case LogLevel.Error:
                    _traceSource.TraceEvent(TraceEventType.Error, 0, message);
                    break;
                case LogLevel.Critical:
                    _traceSource.TraceEvent(TraceEventType.Critical, 0, message);
                    break;
                default:
                    _traceSource.TraceEvent(TraceEventType.Verbose, 0, message);
                    break;
            }
        }

    }
}




