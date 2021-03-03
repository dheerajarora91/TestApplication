using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Business.Abstractions;
using TestApplication.Business.Models;
using TestApplication.Data;
using TestApplication.Data.Entities;

namespace TestApplication.Business.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly ICheapPaymentGateway _cheapPaymentGateway;
        private readonly IExpensivePaymentGateway _expensivePaymentGateway;
        private readonly IPremiumPaymentGateway _premiumPaymentGateway;
        private readonly IMapper _mapper;

        public PaymentService(
            ICheapPaymentGateway cheapPaymentGateway, 
            IExpensivePaymentGateway expensivePaymentGateway, 
            IPremiumPaymentGateway premiumPaymentGateway,
            IMapper mapper)
        {
            _cheapPaymentGateway = cheapPaymentGateway;
            _expensivePaymentGateway = expensivePaymentGateway;
            _premiumPaymentGateway = premiumPaymentGateway;
            _mapper = mapper;
        }

        public async Task<bool> ProcessPayment(PaymentRequest request)
        {
            var paymentEntity = _mapper.Map<Payment>(request);

            if (request.Amount < 20)
                 return await _cheapPaymentGateway.ProcessPayment(paymentEntity);

            else if (request.Amount > 500)
                return await _premiumPaymentGateway.ProcessPayment(paymentEntity);

            else
                return await _expensivePaymentGateway.ProcessPayment(paymentEntity);
        }
    }
}
