using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.iOS.Themes;

namespace VacationsTracker.iOS.Views.Details.VacationsPager
{
    internal class VacationTypePagerView : LayoutView
    {
        public UIImageView VacationImageView { get; private set; }

        public UILabel VacationTypeLabel { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            VacationImageView = new UIImageView();
            VacationTypeLabel = new UILabel().SetLabelStyle();
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(VacationImageView)
                .AddLayoutSubview(VacationTypeLabel);

        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                VacationImageView.Width().EqualTo(AppDimens.DetailsPictureSize),
                VacationImageView.Height().EqualTo(AppDimens.DetailsPictureSize),
                VacationImageView.WithSameCenterY(this),
                VacationImageView.WithSameCenterX(this)
                );

            this.AddConstraints(
                VacationTypeLabel.Below(VacationImageView, AppDimens.Inset1X),
                VacationTypeLabel.WithSameCenterX(this)
                );
        }

    }
}