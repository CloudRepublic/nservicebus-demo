using NServiceBus;
using System;

namespace Demo.Messages
{
    public class StartCustomerCreditCheck : ICommand
    {
        public Guid CustomerId { get; set; }
    }
}
