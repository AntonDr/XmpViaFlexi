using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;

namespace VacationsTracker.iOS.Views.Login.ActivityIndicator
{
    public sealed class ActivityIndicatorView : UIView
    {
        private readonly nfloat _defaultSize = 50.0f;
        private readonly UIColor _defaultColor = UIColor.FromRGB(153, 153, 153);
        private bool _animating;
        private nfloat _size;
        private UIColor _tintColor = UIColor.White;

        public ActivityIndicatorView(nfloat size, float speed)
        {
            Size = size;
            TintColor = _defaultColor;
            Layer.Speed = speed;
        }

        public ActivityIndicatorView(nfloat size, float speed, UIColor color)
        {
            Size = size;
            TintColor = color;
            Layer.Speed = speed;
        }

        public ActivityIndicatorView(IntPtr handle) : base(handle)
        {
            Size = _defaultSize;
            TintColor = _defaultColor;
        }

        public nfloat Size
        {
            get => _size;
            set
            {
                _size = value;
                SetupAnimation();
            }
        }

        public override UIColor TintColor
        {
            get => _tintColor;
            set
            {
                if (_tintColor.Equals(value) == false)
                {
                    _tintColor = value;
                    if (Layer?.Sublayers != null)
                    {
                        foreach (var sublayer in Layer.Sublayers)
                        {
                            sublayer.BackgroundColor = TintColor.CGColor;
                        }
                    }
                }
            }
        }

        public bool Loading
        {
            get => !Hidden;
            set
            {
                Hidden = !value;

                Animating = value;
            }
        }

        private bool Animating
        {
            set
            {
                _animating = value;
                if (_animating)
                {
                    StartAnimating();
                }
                else
                {
                    StopAnimating();
                }
            }
        }

        private void SetupAnimation()
        {
            Layer.Sublayers = null;

            IActivityIndicator activityIndicator = new ActivityIndicatorBallScaleAnimation();
            activityIndicator.SetupAnimationInLayer(Layer, new CGSize(Size, Size), TintColor);
        }

        private void StartAnimating()
        {
            if (Layer.Sublayers.Any())
            {
                SetupAnimation();
            }

            Hidden = false;
        }

        private void StopAnimating()
        {
            Hidden = true;
        }
    }
}