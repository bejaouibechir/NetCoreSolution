using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityImpl.Models
{
    public class RegisterViewModel
    {
        [HiddenInput]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [HiddenInput]
        public Roles Role { get; set; }

    }
}