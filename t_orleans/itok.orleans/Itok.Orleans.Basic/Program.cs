using Itok.Orleans.Basic;
using Orleans;
using Orleans.Hosting;

using var host = new HostBuilder()
    .UseOrleans(x => { x.UseLocalhostClustering(); }).Build();

await host.StartAsync();

var grainFactory = host.Services.GetRequiredService<IGrainFactory>();

var tom = grainFactory.GetGrain<IHelloGrain>("Tom");
var resp = await tom.SayHelloAsync("Jerry");
Console.WriteLine(resp);