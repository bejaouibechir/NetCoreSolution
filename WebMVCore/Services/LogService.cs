#define windows

using System.Diagnostics;

namespace WebMVCore.Services
{
    public class LogService : IService
    {
        public void Log(string message)
        {
#if windows
#pragma warning disable CA1416    
            EventLog.WriteEntry("Application", message,
                EventLogEntryType.Information);
#pragma warning restore  
#endif
        }
    }
}
