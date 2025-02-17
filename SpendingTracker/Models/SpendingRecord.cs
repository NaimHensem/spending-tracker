using System;
using System.ComponentModel.DataAnnotations;

namespace SpendingTracker.Models
{
    public class SpendingRecord
    {
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}
