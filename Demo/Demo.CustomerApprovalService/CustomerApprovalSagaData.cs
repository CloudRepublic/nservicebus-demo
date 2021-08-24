using NServiceBus;
using System;

namespace Demo.CustomerApprovalService
{
    internal class CustomerApprovalSagaData : ContainSagaData
    {
        public Guid CustomerId { get; set; }
    }
}