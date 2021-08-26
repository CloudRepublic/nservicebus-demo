using NServiceBus;
using System;

namespace Demo.Messages
{
    public class EscalateCustomerApproval : ICommand
    {
        public Guid CustomerId { get; set; }
    }
}
