using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itok.MediatR
{
    public class _00
    {
        public class ReqBasic : IRequest<RespBasic>
        {
            public string ReqPayload { get; set; }
        }

        public class StreamReq : IStreamRequest<RespBasic>
        {
            public string Payload { get; set; }
        }

        public class NotifyReq : INotification
        {
            public string Payload { get; set; }
        }

        public class BroadcastReq : INotification
        {
            public string Payload { get; set; }
        }

        public class RespBasic
        {
            public string RespPayload { get; set; }
        }

        public class BasicHandler : IRequestHandler<ReqBasic, RespBasic>
        {
            public Task<RespBasic> Handle(ReqBasic req, CancellationToken cancellationToken)
            {
                return Task.FromResult(new RespBasic()
                {

                    RespPayload = $"mediatR with req's payload {req.ReqPayload}"
                });
            }
        }

        public class StreamBasicHandler : IStreamRequestHandler<StreamReq, RespBasic>
        {
            public async IAsyncEnumerable<RespBasic> Handle(StreamReq request, CancellationToken cancellationToken)
            {
                foreach (var x in Enumerable.Range(0, 10))
                {
                    yield return await Task.FromResult(new RespBasic()
                    {
                        RespPayload = $"{request.Payload} + {x}"
                    });
                }
            }
        }

        public class NotifyBasicHandler : INotificationHandler<NotifyReq>
        {
            public Task Handle(NotifyReq notification, CancellationToken cancellationToken)
            {
                Console.WriteLine($"Notification: {notification.Payload}");
                return Task.CompletedTask;
            }
        }

        public class BroadcastHandler1 : INotificationHandler<BroadcastReq>
        {
            public Task Handle(BroadcastReq notification, CancellationToken cancellationToken)
            {
                Console.WriteLine($"{nameof(BroadcastHandler1)}: {notification.Payload}");
                return Task.CompletedTask;
            }
        }

        public class BroadcastHandler2 : INotificationHandler<BroadcastReq>
        {
            public Task Handle(BroadcastReq notification, CancellationToken cancellationToken)
            {
                Console.WriteLine($"{nameof(BroadcastHandler2)}: {notification.Payload}");
                return Task.CompletedTask;
            }
        }
        public class BroadcastHandler3 : INotificationHandler<BroadcastReq>
        {
            public Task Handle(BroadcastReq notification, CancellationToken cancellationToken)
            {
                Console.WriteLine($"{nameof(BroadcastHandler3)}: {notification.Payload}");
                return Task.CompletedTask;
            }
        }

        public class BroadcastHandler4 : INotificationHandler<BroadcastReq>
        {
            public Task Handle(BroadcastReq notification, CancellationToken cancellationToken)
            {
                Console.WriteLine($"{nameof(BroadcastHandler4)}: {notification.Payload}");
                return Task.CompletedTask;
            }
        }

    }
}
