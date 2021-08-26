using Demo.Messages;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Demo.FinanceDepartment
{
    internal class StartCustomerCreditCheckHandler : IHandleMessages<StartCustomerCreditCheck>
    {
        public async Task Handle(StartCustomerCreditCheck message, IMessageHandlerContext context)
        {
            Console.WriteLine($"Starting credit check for customer {message.CustomerId}");

            await Task.Delay(TimeSpan.FromSeconds(5));

            await context.Reply(new CustomerCreditCheckResult
            {
                CustomerId = message.CustomerId,
                IsApproved = true
            });
        }
    }
}
