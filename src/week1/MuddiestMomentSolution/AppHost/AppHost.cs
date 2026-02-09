var builder = DistributedApplication.CreateBuilder(args);

var mmApi = builder.AddProject<Projects.MuddiestMoment_Api>("mm-api");

var gateway = builder.AddProject<Projects.Gateway_API>("gateway")
    .WithReference(mmApi)
    .WaitFor(mmApi);

builder.Build().Run();
