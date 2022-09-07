using LoanWithUs.Common;
using MediatR.Pipeline;
using System.Diagnostics;

namespace LoanWithUs.MediatR.PreRequest
{
    public class LoggingHandlerDecorator<TRequest> : IRequestPreProcessor<TRequest>
    {
        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            //ToDo: Log All Command
            Debug.WriteLine("I'm generic aswell!");
        }
    }
}