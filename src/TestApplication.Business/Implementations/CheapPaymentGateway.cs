using System;
using System.Threading.Tasks;
using TestApplication.Business.Abstractions;
using TestApplication.Data.Abstractions;
using TestApplication.Data.Entities;

namespace TestApplication.Business.Implementations
{
    public class CheapPaymentGateway : ICheapPaymentGateway
    {
        private readonly IBaseRepository<Payment> _paymentRepository;

        public CheapPaymentGateway(IBaseRepository<Payment> paymentRepository)
        {
            _paymentRepository = paymentRepository;
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
                    entity.PaymentState.State = PaymentStateEnum.Failed;
                    _paymentRepository.Add(entity);
                    await _paymentRepository.SaveChangesAsync();

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
