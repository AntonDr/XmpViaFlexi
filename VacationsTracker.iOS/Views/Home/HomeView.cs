using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.iOS.Views.Home.VacationsTable;

namespace VacationsTracker.iOS.Views.Home
{
    internal class HomeView : LayoutView
    {
        public UITableView VacationsTableView { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            //TODO create class AppColors
            BackgroundColor = UIColor.White;

            VacationsTableView = new UITableView();
            VacationsTableView.RegisterClassForCellReuse(
                typeof(VacationItemViewCell),
                VacationItemViewCell.CellId);
            VacationsTableView.AllowsSelection = true;
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(VacationsTableView);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(VacationsTableView.FullSizeOf(this));
        }
    }
}