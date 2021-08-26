using NServiceBus;
using System;

Console.Title = "Account Management Department";

var config = new EndpointConfiguration("account-management");

config.UseTransport<LearningTransport>().Routing();
config.UsePersistence<LearningPersistence>();
config.SendFailedMessagesTo("error");
config.AuditProcessedMessagesTo("audit");
config.EnableMetrics()
    .SendMetricDataToServiceControl("particular.monitoring", TimeSpan.FromSeconds(1));

await Endpoint.Start(config);

Console.Clear();
Console.ReadLine();