using NServiceBus;
using System;

Console.Title = "Finance Department";

var config = new EndpointConfiguration("finance-department");

config.UseTransport<LearningTransport>().Routing();
config.UsePersistence<LearningPersistence>();
config.SendFailedMessagesTo("error");
config.AuditProcessedMessagesTo("audit");
config.EnableMetrics()
    .SendMetricDataToServiceControl("particular.monitoring", TimeSpan.FromSeconds(1));
config.SendHeartbeatTo("particular.servicecontrol");

await Endpoint.Start(config);

Console.Clear();
Console.ReadLine();