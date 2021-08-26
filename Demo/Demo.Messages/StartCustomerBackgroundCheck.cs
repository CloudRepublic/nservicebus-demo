using NServiceBus;
using System;

namespace Demo.Messages
{
    public class StartCustomerBackgroundCheck : ICommand
    {
        public Guid CustomerId { get; set; }
    }
}
