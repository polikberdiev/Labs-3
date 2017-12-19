using System;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models.FormModels.Home
{
    public class AddFundsFormModel
    {
        public Guid AccountId { get; set; }

        [Required]
        [Range(0, 1000)]
        public double? Value { get; set; }

        public bool IsSubtracting { get; set; }
    }
}