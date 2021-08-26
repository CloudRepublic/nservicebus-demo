using NServiceBus;
using System;

Console.Title = "Legal Department";

var config = new EndpointConfiguration("legal-department");

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