

using MediatR;
using Microsoft.Extensions.DependencyInjection;
using static itok.MediatR._00;
using static itok.MediatR._01;

var sc = new ServiceCollection();

sc.AddMediatR(typeof(Program));

#region Pipeline
sc.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
sc.AddScoped(typeof(IStreamPipelineBehavior<,>), typeof(StreamLoggingBehavior<,>));

#endregion

var sp = sc.BuildServiceProvider();
var mediator = sp.GetRequiredService<IMediator>();

#region Basic:Req_Resp

var req = new ReqBasic() { ReqPayload = "Payload" };

var resp = await mediator.Send(req);
Console.WriteLine(resp.RespPayload);

#endregion

Console.WriteLine("==============================");

#region Streams and AsyncEnumerables
var streamReq = new StreamReq { Payload = "streamPayload" };
await foreach (var item in mediator.CreateStream(streamReq))
{
    Console.WriteLine(item.RespPayload);
    await Task.Delay(1000);
}

#endregion

Console.WriteLine("==============================");

#region Notifications

var notifyReq = new NotifyReq { Payload = "event 1" };

await mediator.Publish(notifyReq);

#endregion

#region Notifications_Broadcast

var broadcast = new BroadcastReq { Payload = "event 1" };

await mediator.Publish(broadcast);

#endregion


