using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexiMvvm.Bindings;
using FlexiMvvm.Bindings.Custom;
using Foundation;
using UIKit;
using VacationsTracker.iOS.Views.Home;

namespace VacationsTracker.iOS.Views
{
    public static class CustomBindings
    {
        public static TargetItemBinding<IUITableViewDelegate, int> SwipeButtonBinding(
            this IItemReference<IUITableViewDelegate> selectedItemReference)
        {
            return new TargetItemOneWayToSourceCustomBinding<IUITableViewDelegate, int, NSIndexPath>(
                selectedItemReference,
                (view, handler) => ((DeleteElementDelegate) view).CellDelete += handler,
                (view, handler) => ((DeleteElementDelegate)view).CellDelete -= handler,
                (view, trackCanExecute) => { },
                (view, args) => args.Row,
                () => "SwipeButton");
        }

        public static TargetItemBinding<IUITableViewDelegate, int> RowSelecteItemBinding(
            this IItemReference<IUITableViewDelegate> selectedItemReference)
        {
            return new TargetItemOneWayToSourceCustomBinding<IUITableViewDelegate, int, NSIndexPath>(
                selectedItemReference,
                (view, handler) => ((DeleteElementDelegate)view).CellDelete += handler,
                (view, handler) => ((DeleteElementDelegate)view).CellDelete -= handler,
                (view, trackCanExecute) => { },
                (view, args) => args.Row,
                () => "SwipeButton");
        }
    }
}