using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using VacationsTracker.Core.Bootstrappers;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Droid.Navigation;

namespace VacationsTracker.Droid.Bootstrappers
{
    public class AndroidBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();

            SetupDependencies(simpleIoc);
        }

        private void SetupDependencies(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register<INavigationService>(() => new NavigationService());
        }
    }
}