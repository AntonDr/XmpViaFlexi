using FlexiMvvm;
using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using VacationsTracker.Core.Application.Connectivity;
using VacationsTracker.Core.DataAccess;
using VacationsTracker.Core.Infrastructure.Connectivity;
using VacationsTracker.Core.Presentation;
using Connectivity = VacationsTracker.Core.Infrastructure.Connectivity.Connectivity;

namespace VacationsTracker.Core.Bootstrappers
{
    public class CoreBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();

            SetupDependencies(simpleIoc);
            SetupViewModelLocator(simpleIoc);
        }

        private void SetupDependencies(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register<IConnectivity>(() => Connectivity.Instance);
            simpleIoc.Register<IConnectivityService>(() => new ConnectivityService(simpleIoc.Get<IConnectivity>()), Reuse.Singleton);
            simpleIoc.Register<IVacationsRepository>(() => new VacationRepository());
        }

        private void SetupViewModelLocator(IDependencyProvider dependencyProvider)
        {
            ViewModelLocator.SetLocator(new VacationsTrackerViewModelLocator(dependencyProvider));
        }
    }
}
