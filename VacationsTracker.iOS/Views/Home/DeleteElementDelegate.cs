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
    class DeleteElementDelegate : UITableViewDelegate
    {
        public override UITableViewRowAction[] EditActionsForRow(UITableView tableView, NSIndexPath indexPath)
        {
            var action = UITableViewRowAction.Create(
                UITableViewRowActionStyle.Default,
                Strings.DeleteNavigationButton_Text ,
                (rowAction, path) =>
                {
                    
                    var item = tableView.CellAt(indexPath);

                });

            return new UITableViewRowAction[] { action};
        }
    }
}