using Demo.Messages;
using NServiceBus;
using System;

Console.Title = "CustomerApprovalService";

var config = new EndpointConfiguration("customer-approval");

var routing = config.UseTransport<LearningTransport>().Routing();
routing.RouteToEndpoint(typeof(StartCustomerBackgroundCheck), "legal-department");
routing.RouteToEndpoint(typeof(StartCustomerCreditCheck), "finance-department");
routing.RouteToEndpoint(typeof(EscalateCustomerApproval), "account-management");

config.UsePersistence<LearningPersistence>();
config.SendFailedMessagesTo("error");
config.AuditProcessedMessagesTo("audit");
config.EnableMetrics()
    .SendMetricDataToServiceControl("particular.monitoring", TimeSpan.FromSeconds(1));
config.AuditSagaStateChanges("audit");
config.SendHeartbeatTo("particular.servicecontrol");

await Endpoint.Start(config);

Console.Clear();
Console.ReadLine();