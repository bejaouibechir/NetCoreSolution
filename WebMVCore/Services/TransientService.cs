using System.Diagnostics;

namespace WebMVCore.Services
{
    public class TransientService :ITransientService
    {
        Guid _guid;
        public TransientService()
        {
            _guid = Guid.NewGuid();
        }
        public void Trace()
        {
            Debug.Write($"TransientService {_guid}\n");
        }
    }
}
