using Demo.Messages;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Demo.LegalDepartment
{
    internal class StartCustomerBackgroundCheckHandler : IHandleMessages<StartCustomerBackgroundCheck>
    {
        public async Task Handle(StartCustomerBackgroundCheck message, IMessageHandlerContext context)
        {
            Console.WriteLine($"Starting background check for customer {message.CustomerId}");

            await Task.Delay(TimeSpan.FromSeconds(40));

            await context.Reply(new CustomerBackgroundCheckResult
            {
                CustomerId = message.CustomerId,
                IsApproved = true
            });
        }
    }
}
