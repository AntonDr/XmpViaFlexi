using System.Drawing;
using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
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

            //this.AddConstraints(VacationsTableView.TableFooterView.Below(VacationsTableView),
            //    VacationsTableView.TableFooterView.Height().EqualTo(2));

                    

            //this.AddConstraints(Separator.Height().EqualTo(1));

            //this.AddConstraints(
            //    Separator.Below(VacationsTableView),
            //    Separator.Height().EqualTo(1),
            //    Separator.AtLeftOf(this),
            //    Separator.AtRightOf(this));
        }
    }
}