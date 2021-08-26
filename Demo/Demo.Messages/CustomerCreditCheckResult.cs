using NServiceBus;
using System;

namespace Demo.Messages
{
    public class CustomerCreditCheckResult : IMessage
    {
        public Guid CustomerId { get; set; }
        public bool IsApproved { get; set; }
    }
}
