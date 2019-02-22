using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Resources;

namespace VacationsTracker.iOS.Views.Home
{
    public class DeleteElementDelegate : UITableViewDelegate
    {
        public event EventHandler<NSIndexPath> CellDelete = delegate { };

        public override UITableViewRowAction[] EditActionsForRow(UITableView tableView, NSIndexPath indexPath)
        {
            var action = UITableViewRowAction.Create(
                UITableViewRowActionStyle.Default,
                Strings.DeleteNavigationButton_Text ,
                (rowAction, path) =>
                {
                    CellDelete(this,path);
                });

            return new UITableViewRowAction[] { action};
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            
        }
    }

}