﻿using NServiceBus;
using System;

namespace Demo.Messages
{
    public class StartCustomerApproval : ICommand
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
    }
}
