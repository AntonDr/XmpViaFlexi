using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.iOS.Themes;
using VacationsTracker.iOS.Views.Home.VacationsTable;

namespace VacationsTracker.iOS.Views.Home
{
    internal class HomeView : LayoutView
    {
        public UITableView VacationsTableView { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = AppColors.White;

            VacationsTableView = new UITableView();

            VacationsTableView.RegisterClassForCellReuse(
                typeof(VacationItemViewCell),
                VacationItemViewCell.CellId);

            VacationsTableView.RegisterClassForHeaderFooterViewReuse(
                typeof(VacationTableFooterViewCell),
                VacationTableFooterViewCell.CellId);

            VacationsTableView.RegisterClassForHeaderFooterViewReuse(
                typeof(VacationTableHeaderViewCell),
                VacationTableHeaderViewCell.CellId);

            VacationsTableView.RefreshControl = new UIRefreshControl();

            VacationsTableView.AllowsSelection = true;

            VacationsTableView.AllowsSelectionDuringEditing = true;

            VacationsTableView.UserInteractionEnabled = true;
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