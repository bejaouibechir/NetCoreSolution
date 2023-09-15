namespace WebMVCore.Services
{
    public class BMW : ICar
    {
        public string Model { get; set; } = "BMV 320";
        public string VI { get; set; } = "1234";

        public void Run()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Model: {Model} VI: {VI}";
        }
        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
