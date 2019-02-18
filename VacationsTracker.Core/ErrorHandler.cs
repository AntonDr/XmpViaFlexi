using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlexiMvvm.Operations;

namespace VacationsTracker.Core
{
    public class ErrorHandler : IErrorHandler
    {
        public Task HandleAsync(OperationContext context, OperationError<Exception> error, CancellationToken cancellationToken)
        {
            Debug.WriteLine("");
            return Task.CompletedTask;
        }
    }
}
