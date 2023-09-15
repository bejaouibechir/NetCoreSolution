using System.Net.NetworkInformation;

namespace WebRazorCF.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Availability Available {get; set; }
        
        //Clé étrangère
        public int? CustomerId { get; set; } 
        
        //Propriété de navigation
        public Customer Customer { get; set; }

    }
}
