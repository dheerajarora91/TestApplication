using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Business.Abstractions;
using TestApplication.Business.Models;
using TestApplication.Data.Abstractions;
using TestApplication.Data.Entities;

namespace TestApplication.Business.Implementations
{
    public class PremiumPaymentGateway : IPremiumPaymentGateway
    {
        private readonly IBaseRepository<Payment> _paymentRepository;

        public PremiumPaymentGateway(IBaseRepository<Payment> paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public bool IsPaymentSuccessful { get; set; } = true;

        public async Task<bool> ProcessPayment(Payment entity)
        {
            try
            {
                entity.PaymentState = new PaymentState();
                int counter = 1;
                
                do
                {
                    if (IsPaymentSuccessful)
                    {
                        entity.PaymentState.State = PaymentStateEnum.Processed;
                        _paymentRepository.Add(entity);
                        await _paymentRepository.SaveChangesAsync();

                        return true;
                    }
                    counter++;
                } while (counter == 3);

                entity.PaymentState.State = PaymentStateEnum.Failed;
                _paymentRepository.Add(entity);
                await _paymentRepository.SaveChangesAsync();

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
