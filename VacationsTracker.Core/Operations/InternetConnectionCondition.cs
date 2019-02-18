using System;
using System.Collections.Generic;
using System.Text;

namespace VacationsTracker.Core.Operations
{
    public class InternetConnectionCondition : OperationConditionBase
    {
        public override Task<bool> CheckAsync(OperationContext context, CancellationToken cancellationToken)
        {
            var connectivityService = context.DependencyProvider.NotNull().Get<IConnectivityService>();

            if (connectivityService.IsConnected())
            {
                return Task.FromResult(true);
            }

            throw new InternetConnectionException("No internet connection. TODO localize.");
        }
    }
}
