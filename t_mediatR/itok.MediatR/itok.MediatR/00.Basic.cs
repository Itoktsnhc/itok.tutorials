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

    }
}
