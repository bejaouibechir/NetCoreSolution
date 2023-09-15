namespace WebMVCore.Services
{
    public class Audi : ICar
    {
        public string Model { get; set; } = "A4";
        public string VI { get; set; } = "9875";

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
