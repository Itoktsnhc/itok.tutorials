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
    }
}
