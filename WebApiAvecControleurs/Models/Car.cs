namespace WebApiAvecControleurs.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Vi { get; set; }
    }

    #region Service d'accès aux données

    public interface ICarContext
    {
        void AddCar(Car car);
        void DeleteCar(int id);
        Car GetCar(int id);
        List<Car> GetCars();
        bool UpdateCar(int id, Car newCar);
    }

    public class CarContext : ICarContext
    {
        List<Car> _cars;

        public CarContext()
        {
            _cars = new List<Car>()
            {
                new Car { Id = 0,Name="Honda", Model="FIT", Vi="123"},
                new Car { Id = 1,Name="Honda", Model="CIVIC", Vi="456"},
                new Car { Id = 2,Name="Nissan", Model="Atlas", Vi="799"},
                new Car { Id = 3,Name="Audi", Model="A5", Vi="325"},
                new Car { Id = 4,Name="BMW", Model="M3", Vi="589"}
            };
        }


        public List<Car> GetCars() => _cars;

        public Car GetCar(int id) => _cars[id];

        public void AddCar(Car car) => _cars.Add(car);

        public bool UpdateCar(int id, Car newCar)
        {
            var current = GetCar(id);
            if (current == null) return false;
            else
            {
                current = newCar;
                return true;
            }
        }

        public void DeleteCar(int id)
        {
            _cars.RemoveAt(id);
        }


    }

    #endregion

}
