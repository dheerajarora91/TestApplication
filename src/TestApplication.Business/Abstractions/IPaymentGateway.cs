using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Business.Models;
using TestApplication.Data.Entities;

namespace TestApplication.Business.Abstractions
{
    public interface IPaymentGateway
    {
        public bool IsPaymentSuccessful { get; set; }
        Task<bool> ProcessPayment(Payment entity);
    }
}
