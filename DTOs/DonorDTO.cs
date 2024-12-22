using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Donation_Tracker.DTOs
{
    public class DonorDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        //[RegularExpression(@"^\+880 \d{4}-\d{6}$", ErrorMessage = "The phone number must be in the format +880xxxx-xxxxxx.")]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
    }
}