using NServiceBus;
using System;

namespace Demo.CustomerApprovalService
{
    internal class CustomerApprovalSagaData : ContainSagaData
    {
        public Guid CustomerId { get; set; }
        public bool? BackgroundCheckResult { get; set; }
        public bool? CreditCheckResult { get; set; }
    }
}