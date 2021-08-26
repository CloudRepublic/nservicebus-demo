using Demo.Messages;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Demo.FinancialDepartment
{
    internal class CustomerApprovalFinishedHandler : IHandleMessages<CustomerApprovalFinished>
    {
        public async Task Handle(CustomerApprovalFinished message, IMessageHandlerContext context)
        {
            Console.WriteLine($"Handling {(message.IsApproved ? "approval" : "rejection")} of customer {message.CustomerId}");

            //handle customer approval or rejection
            await Task.CompletedTask;
        }
    }
}
