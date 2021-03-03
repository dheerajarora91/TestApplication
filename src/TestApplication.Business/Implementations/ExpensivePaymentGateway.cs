using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Business.Abstractions;
using TestApplication.Business.Models;
using TestApplication.Data.Abstractions;
using TestApplication.Data.Entities;

namespace TestApplication.Business.Implementations
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        private readonly IBaseRepository<Payment> _paymentRepository;
        private readonly ICheapPaymentGateway _cheapPaymentGateway;

        public ExpensivePaymentGateway(IBaseRepository<Payment> paymentRepository, ICheapPaymentGateway cheapPaymentGateway)
        {
            _paymentRepository = paymentRepository;
            _cheapPaymentGateway = cheapPaymentGateway;
        }

        public bool IsPaymentSuccessful { get; set; } = true;

        public async Task<bool> ProcessPayment(Payment entity)
        {
            try
            {
                entity.PaymentState = new PaymentState();

                if (IsPaymentSuccessful)
                {
                    entity.PaymentState.State = PaymentStateEnum.Processed;
                    _paymentRepository.Add(entity);
                    await _paymentRepository.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return await _cheapPaymentGateway.ProcessPayment(entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
