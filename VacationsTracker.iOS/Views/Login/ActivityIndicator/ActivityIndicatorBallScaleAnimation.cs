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
    public class ActivityIndicatorBallScaleAnimation : IActivityIndicator
    {
        public void SetupAnimationInLayer(CALayer layer, CGSize size, UIColor tintColor)
        {
            nfloat duration = 1.0f;

            var scaleAnimation = CABasicAnimation.FromKeyPath("transform.scale");
            scaleAnimation.Duration = duration;
            scaleAnimation.From = NSNumber.FromFloat(0.0f);
            scaleAnimation.To = NSNumber.FromFloat(1.0f);

            var opacityAnimation = CABasicAnimation.FromKeyPath("opacity");
            opacityAnimation.Duration = duration;
            opacityAnimation.From = NSNumber.FromFloat(1.0f);
            opacityAnimation.To = NSNumber.FromFloat(0.0f);

            var animation = new CAAnimationGroup
            {
                Animations = new CAAnimation[]
                {
                    scaleAnimation, opacityAnimation
                },
                Duration = duration,
                TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut),
                RepeatCount = float.PositiveInfinity,
                RemovedOnCompletion = false
            };

            var circle = new CAShapeLayer();
            var circlePath = UIBezierPath.FromRoundedRect(new CGRect(0, 0, size.Width, size.Height), UIRectCorner.AllCorners, new CGSize(size.Width / 2, size.Width / 2));
            circle.FillColor = tintColor.CGColor;
            circle.Path = circlePath.CGPath;
            circle.AddAnimation(animation, "animation");
            circle.Frame = new CGRect((layer.Bounds.Size.Width - size.Width) / 2, (layer.Bounds.Size.Height - size.Height) / 2, size.Width, size.Height);
            layer.AddSublayer(circle);
        }
    }
}