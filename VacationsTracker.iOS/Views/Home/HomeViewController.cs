using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.Core.Presentation.ViewModels.Login;
using VacationsTracker.iOS.Views.Login;

namespace VacationsTracker.iOS.Views.Home
{
    public class HomeViewController : FlxBindableViewController<HomeViewModel>
    {
        public new HomeView View
        {
            get => (HomeView)base.View.NotNull();
            set => base.View = value;
        }

        public override void LoadView()
        {
            View = new HomeView();
        }


        public override void Bind(BindingSet<HomeViewModel> bindingSet)
        {
            base.Bind(bindingSet);

        }
    }
}