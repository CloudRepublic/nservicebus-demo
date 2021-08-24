using NServiceBus;

var config = new EndpointConfiguration("customer-approval");

config.UseTransport<LearningTransport>();
config.UsePersistence<LearningPersistence>();

config.SendFailedMessagesTo("error");
config.AuditProcessedMessagesTo("audit");

await Endpoint.Start(config);