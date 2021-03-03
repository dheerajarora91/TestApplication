using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestApplication.Data.Entities
{
    public class PaymentState
    {
        [Key]
        public Guid PaymentStateId { get; set; }
        public PaymentStateEnum State { get; set; }
        public Payment Payment { get; set; }

        public PaymentState()
        {
            PaymentStateId = Guid.NewGuid();
        }
    }
}
