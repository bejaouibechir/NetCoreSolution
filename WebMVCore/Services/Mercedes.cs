namespace WebMVCore.Services
{
    public class Mercedes : ICar
    {
        public string Model { get; set; } = "Mercedes Benz";
        public string VI { get; set; } = "1452";

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
