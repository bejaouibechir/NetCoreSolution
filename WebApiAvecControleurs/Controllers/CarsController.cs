//#define sansinjection
#define avecinjection

using Microsoft.AspNetCore.Mvc;
using WebApiAvecControleurs.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiAvecControleurs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {


#if sansinjection
        CarContext _carcontext;
        public CarsController()
        {
            _carcontext = new CarContext();
        }
#endif
#if avecinjection
        ICarContext _carcontext;
        ILogger<CarsController> _logger;
        public CarsController(ICarContext carcontext, ILogger<CarsController> logger)
        {
            _carcontext = carcontext;
            _logger = logger;
        }
#endif


        // GET: api/<CarsController>
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            _logger.Log(LogLevel.Information, $"La methode Get est visitée à {DateTime.Now}");
            return _carcontext.GetCars();
        }
        

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public Car Get(int id)=>_carcontext.GetCar(id);

        // POST api/<CarsController>
        [HttpPost]
        public void Post([FromBody] Car car)
        => _carcontext.AddCar(car);


        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Car newcar)
        => _carcontext.UpdateCar(id, newcar);

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        => _carcontext.DeleteCar(id);
    }
}
