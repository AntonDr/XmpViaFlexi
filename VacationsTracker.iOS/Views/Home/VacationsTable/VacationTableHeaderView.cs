using Cirrious.FluentLayouts.Touch;
using FlexiMvvm;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.iOS.Themes;

namespace VacationsTracker.iOS.Views.Home.VacationsTable
{
    internal class VacationTableHeaderView : LayoutView
    {
        public UILabel RefreshTimeLabel { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = AppColors.White;

            RefreshTimeLabel = new UILabel();
        }
        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(RefreshTimeLabel);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                this.Height().NotNull().EqualTo(56));

            this.AddConstraints(
                RefreshTimeLabel.FullSizeOf(this));
        }
    }
}