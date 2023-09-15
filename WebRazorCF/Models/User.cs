using System.ComponentModel.DataAnnotations;

namespace WebRazorCF
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        //Ce champs permet de disntinguer entre un consommateur et un employee
        public string Descriminator { get; set; }
    }
}