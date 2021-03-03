using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Business.Models;

namespace TestApplication.Business.Abstractions
{
    public interface IPaymentService
    {
        public Task<bool> ProcessPayment(PaymentRequest request);
    }
}
