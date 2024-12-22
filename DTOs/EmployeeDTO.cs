using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Donation_Tracker.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        //[RegularExpression("/^([+880]{4}[1]{1}[0-9]{3}[-][0-9]{6})$/", ErrorMessage = "The phone number must be in the format +880xxxx-xxxxxx.")]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        
        
    }
}