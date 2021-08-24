using Demo.Messages;
using NServiceBus;
using System.Threading.Tasks;

namespace Demo.CustomerApprovalService
{
    internal class CustomerApprovalSaga :
        Saga<CustomerApprovalSagaData>,
        IAmStartedByMessages<StartCustomerApproval>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<CustomerApprovalSagaData> mapper)
        {
            mapper.MapSaga(data => data.CustomerId)
                .ToMessage<StartCustomerApproval>(message => message.CustomerId);
        }

        public async Task Handle(StartCustomerApproval message, IMessageHandlerContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
