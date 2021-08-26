using NServiceBus;
using System;

namespace Demo.Messages
{
    public class CustomerBackgroundCheckResult : IMessage
    {
        public Guid CustomerId { get; set; }
        public bool IsApproved { get; set; }
    }
}
