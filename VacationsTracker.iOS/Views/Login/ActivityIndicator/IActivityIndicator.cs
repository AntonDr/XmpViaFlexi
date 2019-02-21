using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;

namespace VacationsTracker.iOS.Views.Login.ActivityIndicator
{
    public interface IActivityIndicator
    {
        void SetupAnimationInLayer(CALayer layer, CGSize size, UIColor tintColor);
    }
}