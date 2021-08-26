using Demo.Messages;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Demo.CustomerApprovalService
{
    internal class CustomerApprovalSaga :
        Saga<CustomerApprovalSagaData>,
        IAmStartedByMessages<StartCustomerApproval>,
        IHandleMessages<CustomerBackgroundCheckResult>,
        IHandleMessages<CustomerCreditCheckResult>,
        IHandleTimeouts<CustomerApprovalEscalationTimeout>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<CustomerApprovalSagaData> mapper)
        {
            mapper.MapSaga(data => data.CustomerId)
                .ToMessage<StartCustomerApproval>(message => message.CustomerId)
                .ToMessage<CustomerBackgroundCheckResult>(message => message.CustomerId)
                .ToMessage<CustomerCreditCheckResult>(message => message.CustomerId);
        }

        public async Task Handle(StartCustomerApproval message, IMessageHandlerContext context)
        {
            //start credit check at the finance department
            await context.Send(new StartCustomerCreditCheck
            {
                CustomerId = Data.CustomerId
            });

            //start background check at the legal department
            await context.Send(new StartCustomerBackgroundCheck
            {
                CustomerId = Data.CustomerId
            });

            //start timeout for escalating the approval request
            await RequestTimeout<CustomerApprovalEscalationTimeout>(context, TimeSpan.FromSeconds(30));
        }

        public async Task Handle(CustomerBackgroundCheckResult message, IMessageHandlerContext context)
        {
            Data.BackgroundCheckResult = message.IsApproved;

            await NotifySalesIfAllChecksPerformed(context);
        }

        public async Task Handle(CustomerCreditCheckResult message, IMessageHandlerContext context)
        {
            Data.CreditCheckResult = message.IsApproved;

            await NotifySalesIfAllChecksPerformed(context);
        }

        private async Task NotifySalesIfAllChecksPerformed(IMessageHandlerContext context)
        {
            var areAllChecksPerformed = Data.CreditCheckResult.HasValue && Data.BackgroundCheckResult.HasValue;
            if (areAllChecksPerformed)
            {
                var isCustomerApproved = Data.BackgroundCheckResult.Value && Data.CreditCheckResult.Value;
                await context.Publish(new CustomerApprovalFinished
                {
                    CustomerId = Data.CustomerId,
                    IsApproved = isCustomerApproved
                });

                MarkAsComplete();
            }
        }

        public async Task Timeout(CustomerApprovalEscalationTimeout state, IMessageHandlerContext context)
        {
            //timeout has elapsed, escalate the approval request
            await context.Send(new EscalateCustomerApproval
            {
                CustomerId = Data.CustomerId
            });
        }
    }
}
