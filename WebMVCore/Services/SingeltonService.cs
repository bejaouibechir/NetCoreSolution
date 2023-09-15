using System.Diagnostics;

namespace WebMVCore.Services
{
    public class SingletonService : ISingletonService
    {
        Guid _guid;
        public SingletonService()
        {
            _guid = Guid.NewGuid();
        }
        public void Trace()
        {
            Debug.Write($"SingletonService {_guid}\n");
        }
    }
}
