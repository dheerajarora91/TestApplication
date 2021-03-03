using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestApplication.Data.Entities
{
    public class Payment
    {
        [Key]
        public Guid PaymentId { get; set; }
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public double Amount { get; set; }
        [ForeignKey("PaymentStateId")]
        public Guid PaymentStateId { get; set; }
        public PaymentState PaymentState { get; set; }

        public Payment()
        {
            PaymentId = Guid.NewGuid();
        }
    }
}
