#define nolazyloading
using System.ComponentModel.DataAnnotations;

namespace WebRazorCF.Models
{
    public class Customer :User
    {
        public Customer()
        {
#if nolazyloading
            Products = new HashSet<Product>();
#endif
        }

        public string? City { get; set; }
        public string? Country { get; set; }

        public ICollection<Product> Products { get; set; }


    }
}
