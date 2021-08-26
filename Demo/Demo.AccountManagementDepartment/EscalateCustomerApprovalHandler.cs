using Demo.Messages;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Demo.FinanceDepartment
{
    internal class EscalateCustomerApprovalHandler : IHandleMessages<EscalateCustomerApproval>
    {
        public async Task Handle(EscalateCustomerApproval message, IMessageHandlerContext context)
        {
            Console.WriteLine($"Handling escalation of approval request for customer {message.CustomerId}");

            //notify people that a customer approval process is taking too long
            await Task.CompletedTask;
        }
    }
}
