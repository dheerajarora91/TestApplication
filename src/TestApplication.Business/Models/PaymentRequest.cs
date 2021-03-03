using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TestApplication.Business.Helpers;

namespace TestApplication.Business.Models
{
    public class PaymentRequest
    {
        [Required]
        [StringLength(16, MinimumLength = 16)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Credit card number must be numeric")]
        public string CreditCardNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string CardHolder { get; set; }

        [Required]
        [DateValidator(ErrorMessage = "Expiration date can't be of past")]
        public DateTime ExpirationDate { get; set; }

        [StringLength(3, MinimumLength = 3)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Security code must be numeric")]
        public string SecurityCode { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public double Amount { get; set; }

        public string PaymentState { get; set; }
    }
}
