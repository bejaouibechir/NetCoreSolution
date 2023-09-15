namespace WebMVCore.Services
{
    public interface ICar
    {
        string Model { get; set; }
        string VI { get; set; }

        void Run();

        void Stop();
    }
}
