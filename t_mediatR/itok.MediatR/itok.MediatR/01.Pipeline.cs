using MediatR;

namespace itok.MediatR
{
    public class _01
    {
        public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
        {

            public LoggingBehavior()
            {
            }

            public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
            {
                Console.WriteLine($"Pre {typeof(TRequest).Name}");
                var response = await next();
                Console.WriteLine($"Post {typeof(TResponse).Name}");

                return response;
            }
        }

        public class StreamLoggingBehavior<TRequest, TResponse> : IStreamPipelineBehavior<TRequest, TResponse>
             where TRequest : IStreamRequest<TResponse>
        {
            public IAsyncEnumerable<TResponse> Handle(TRequest request, CancellationToken cancellationToken, StreamHandlerDelegate<TResponse> next)
            {
                Console.WriteLine($"Pre Stream {typeof(TRequest).Name}");
                var response = next();
                Console.WriteLine($"Post Stream {typeof(TResponse).Name}");

                return response;
            }
        }
    }
}
