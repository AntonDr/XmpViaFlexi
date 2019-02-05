using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;

namespace VacationsTracker.iOS.Views.Home
{
    public class HomeView : LayoutView
    {
        protected override void SetupLayout()
        {
            base.SetupLayout();
        }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
        }
    }
}