using System.Drawing;
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

        public UIView Separator { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = AppColors.White;

            VacationsTableView = new UITableView();

            VacationsTableView.RegisterClassForCellReuse(
                typeof(VacationItemViewCell),
                VacationItemViewCell.CellId);

            VacationsTableView.AllowsSelection = true;

            Separator = new UIView().SetSeparatorStyle();

            Separator.Hidden = false;

            //var footerView = new UIView(new RectangleF(0, 0, 375, 66));

            VacationsTableView.TableFooterView = Separator;
        }

       
        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(VacationsTableView)
                .AddLayoutSubview(Separator);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(VacationsTableView.FullSizeOf(this));

            this.AddConstraints(Separator.Height().EqualTo(1));

            //this.AddConstraints(
            //    Separator.Below(VacationsTableView),
            //    Separator.Height().EqualTo(1),
            //    S

            //    );
        }
    }
}