

using MediatR;
using Microsoft.Extensions.DependencyInjection;
using static itok.MediatR._00;

var sc = new ServiceCollection();

sc.AddMediatR(typeof(Program));

var sp = sc.BuildServiceProvider();

#region Basic_Req_Resp

var mediator = sp.GetRequiredService<IMediator>();
var req = new ReqBasic() { ReqPayload = "PayLoad" };

var resp = await mediator.Send(req);
Console.WriteLine(resp.RespPayload);

#endregion
