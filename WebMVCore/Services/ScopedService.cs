using System.Diagnostics;

namespace WebMVCore.Services
{
    public class ScopedService : IScopedService
    {
        Guid _guid;
        public ScopedService()
        {
            _guid = Guid.NewGuid();
        }
        public void Trace()
        {
            Debug.Write($"ScopedService {_guid}\n");
        }
    }
}
