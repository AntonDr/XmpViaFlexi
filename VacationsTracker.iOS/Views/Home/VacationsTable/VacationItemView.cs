using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.iOS.Themes;

namespace VacationsTracker.iOS.Views.Home.VacationsTable
{
    internal class VacationItemView : LayoutView
    {
        public UIImageView ImageView { get; private set; }
        public UILabel DurationVacationTextView { get; private set; }
        public UILabel TypeView { get; private set; }
        public UIView Separator { get; private set; }
        public UILabel StatusView { get; private set; }


        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            ImageView = new UIImageView();

            DurationVacationTextView = new UILabel().SetLabelStyle();

            DurationVacationTextView.TextColor = AppColors.LightBlueColor;
            DurationVacationTextView.Font = UIFont.SystemFontOfSize(AppDimens.Inset3X);

            TypeView = new UILabel().SetLabelStyle();

            TypeView.Font = UIFont.SystemFontOfSize(AppDimens.Inset2X);

            Separator = new UIView().SetSeparatorStyle();

            StatusView = new UILabel().SetLabelStyle();
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(ImageView)
                .AddLayoutSubview(DurationVacationTextView)
                .AddLayoutSubview(TypeView)
                .AddLayoutSubview(StatusView)
                .AddLayoutSubview(Separator);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                ImageView.AtLeftOf(this),
                ImageView.AtTopOf(this, AppDimens.Inset1X),
                ImageView.AtBottomOf(this, AppDimens.Inset1X),
                ImageView.WithSameCenterY(this),
                ImageView.Height().EqualTo(AppDimens.Inset7X),
                ImageView.Width().EqualTo(AppDimens.Inset7X));

            this.AddConstraints(
                DurationVacationTextView.ToRightOf(ImageView),
                DurationVacationTextView.WithSameTop(ImageView));

            this.AddConstraints(
                TypeView.ToRightOf(ImageView),
                TypeView.AtBottomOf(ImageView, AppDimens.Inset1X));

            this.AddConstraints(
                StatusView.AtRightOf(this, AppDimens.Inset1X),
                StatusView.WithSameCenterY(this));

            this.AddConstraints(
                Separator.WithSameLeft(DurationVacationTextView),
                Separator.WithSameRight(this),
                Separator.WithSameBottom(this),
                Separator.Height().EqualTo(1));
        }
    }
}