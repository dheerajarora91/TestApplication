using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestApplication.Data.Entities;

namespace TestApplication.Data.Implementations
{
    public class PaymentRepository : BaseRepository<Payment>
    {
        public PaymentRepository(TestApplicationDbContext context) : base(context)
        {

        }
    }
}
