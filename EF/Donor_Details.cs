//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Donation_Tracker.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Donor_Details
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public System.DateTime Date { get; set; }
        public int Donor_Id { get; set; }
        public Nullable<int> Emp_Id { get; set; }
    
        public virtual Donor Donor { get; set; }
        public virtual Employee Employee { get; set; }
    }
}