using AutoMapper;
using FlexiMvvm;
using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using FlexiMvvm.Operations;
using VacationsTracker.Core.Application.Connectivity;
using VacationsTracker.Core.DataAccess;
using VacationsTracker.Core.DataAccess.Interfaces;
using VacationsTracker.Core.Infrastructure.Connectivity;
using VacationsTracker.Core.Mapping;
using VacationsTracker.Core.Operations;
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
            //simpleIoc.Register<IVacationsRepository>(() => new VacationRepository());
            simpleIoc.Register<ISecureStorage>(() => new VacationSimulatorSecureStorage());
            simpleIoc.Register<IMapper>(() => new MapperConfiguration(cfg => cfg.AddProfile<VacationCellViewModelMappingProfile>()).CreateMapper(), Reuse.Singleton);
            simpleIoc.Register<IContext>(() => new ServerContext(simpleIoc.Get<ISecureStorage>()));
            simpleIoc.Register<IVacationApi>(() => new VacationApi(simpleIoc.Get<IContext>()));
            simpleIoc.Register<IVacationsRepository>(() => new ServerRepository(simpleIoc.Get<IVacationApi>(),simpleIoc.Get<IMapper>()));
            simpleIoc.Register<IUserRepository>(() => new UserRepository(simpleIoc.Get<ISecureStorage>()));
            simpleIoc.Register<IErrorHandler>((() => new ErrorHandler()));
            simpleIoc.Register<IDependencyProvider>(() => new DependencyProvider(simpleIoc.Get<IConnectivityService>()));
            simpleIoc.Register<IOperationFactory>(() => new OperationFactory(simpleIoc.Get<IDependencyProvider>(),simpleIoc.Get<IErrorHandler>()));
            //simpleIoc.Register(() => new VacationCellViewModelMappingProfile());
        }

        private void SetupViewModelLocator(IDependencyProvider dependencyProvider)
        {
            ViewModelLocator.SetLocator(new VacationsTrackerViewModelLocator(dependencyProvider));
        }
    }
}
