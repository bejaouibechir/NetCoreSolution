using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazor.Models;

namespace WebRazor.Pages
{
    public class EditModel : PageModel
    {
        
        [BindProperty]
        public Customer Client { get; set; }

        public void OnGet(int id)
        {
            Client = getCustomer(id);
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {

            }
        }

        
        
        
        private Customer getCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
