using NServiceBus;
using System;

namespace Demo.Messages
{
    public class CustomerApprovalFinished : IEvent
    {
        public Guid CustomerId { get; set; }
        public bool IsApproved { get; set; }
    }
}
