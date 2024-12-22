using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Donation_Tracker.DTOs
{
    public class Donor_DetailsDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int Donor_Id { get; set; }
    }
}