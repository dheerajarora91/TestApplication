using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TestApplication.API.Controllers;
using TestApplication.Business.Abstractions;
using TestApplication.Business.Implementations;
using TestApplication.Business.Models;
using TestApplication.Data.Entities;

namespace TestApplication.API.Tests
{
    public class PaymentsControllerTests
    {
        private readonly Mock<ICheapPaymentGateway> _cheapPaymentGateway;
        private readonly Mock<IExpensivePaymentGateway> _expensivePaymentGateway;
        private readonly IPaymentService _paymentService;
        private readonly Mock<IPremiumPaymentGateway> _premiumPaymentGateway;
        private readonly Mock<IMapper> _mapper;

        public PaymentsControllerTests()
        {
            _cheapPaymentGateway = new Mock<ICheapPaymentGateway>();
            _expensivePaymentGateway = new Mock<IExpensivePaymentGateway>();
            _premiumPaymentGateway = new Mock<IPremiumPaymentGateway>();
            _mapper = new Mock<IMapper>();
            _paymentService = new PaymentService
                (
                _cheapPaymentGateway.Object,
                _expensivePaymentGateway.Object,
                _premiumPaymentGateway.Object,
                _mapper.Object
                );
        }

        [Test]
        public async Task ProcessPaymentTest_CheapPaymentGateway()
        {
            // Arrange
            var controller = new PaymentsController(_paymentService);

            var request = new PaymentRequest()
            {
                CreditCardNumber = "1234567890123456",
                CardHolder = "Dheeraj",
                ExpirationDate = DateTime.UtcNow,
                Amount = 3
            };

            // Act
            await controller.ProcessPayment(request);

            // Assert
            _cheapPaymentGateway.Verify(payment => payment.ProcessPayment(It.IsAny<Payment>()), Times.Once);
        }

        [Test]
        public async Task ProcessPaymentTest_ExpensivePaymentGateway()
        {
            // Arrange
            var controller = new PaymentsController(_paymentService);

            var request = new PaymentRequest()
            {
                CreditCardNumber = "1234567890123456",
                CardHolder = "Dheeraj",
                ExpirationDate = DateTime.UtcNow,
                Amount = 75
            };

            // Act
             await controller.ProcessPayment(request);

            // Assert
            _cheapPaymentGateway.Verify(payment => payment.ProcessPayment(It.IsAny<Payment>()), Times.Once);
        }

        [Test]
        public async Task ProcessPaymentTest_PremiumPaymentGateway()
        {
            // Arrange
            var controller = new PaymentsController(_paymentService);

            var request = new PaymentRequest()
            {
                CreditCardNumber = "1234567890123456",
                CardHolder = "Dheeraj",
                ExpirationDate = DateTime.UtcNow,
                Amount = 600
            };

            // Act
            await controller.ProcessPayment(request);

            // Assert
            _cheapPaymentGateway.Verify(payment => payment.ProcessPayment(It.IsAny<Payment>()), Times.Once);
        }
    }
}