using Itok.Orleans.HelloWorld;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Hosting;

var host = new HostBuilder()
    .UseOrleans(x => { x.UseLocalhostClustering(); })
    .Build();

await host.StartAsync();

var grainFactory = host.Services.GetRequiredService<IGrainFactory>();

var tom = grainFactory.GetGrain<IFriendGrain>("Tom");

var resp = await tom.SayHiAsync("Jerry");

Console.WriteLine(resp);
Console.ReadLine();