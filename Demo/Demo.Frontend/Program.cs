using Demo.Messages;
using NServiceBus;
using System;

var config = new EndpointConfiguration("frontend");

config.SendOnly();
config.UseTransport<LearningTransport>().Routing()
    .RouteToEndpoint(typeof(StartCustomerApproval), "customer-approval");

var endpoint = await Endpoint.Start(config);

Console.Clear();
Console.WriteLine("press enter to start customer approval process");
Console.ReadLine();

await endpoint.Send(new StartCustomerApproval
{
    CustomerId = Guid.NewGuid(),
    Name = "DemoCustomer"
});