using System;
using System.Collections.Generic;
using System.Text;
using FlexiMvvm.Ioc;
using VacationsTracker.Core.Application.Connectivity;

namespace VacationsTracker.Core.Operations
{
    internal class DependencyProvider : IDependencyProvider
    {
        private readonly IConnectivityService _connectivityService;
        //private readonly IDialogService _dialogService;

        public DependencyProvider(IConnectivityService connectivityService /*IDialogService dialogService*/)
        {
            _connectivityService = connectivityService;
            //_dialogService = dialogService;
        }

        public T Get<T>() where T : class
        {
            if (typeof(T) == typeof(IConnectivityService))
                return (T)_connectivityService;

            //if (typeof(T) == typeof(IDialogService))
            //    return (T)_dialogService;

            throw new NotSupportedException($"Type \"{typeof(T)}\" is not registered.");
        }
    }
}
