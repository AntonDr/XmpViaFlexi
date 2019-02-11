using System;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.Details;
using VacationsTracker.iOS.Views.ValueConverters;

namespace VacationsTracker.iOS.Views.Details.VacationsPager
{
    internal class VacationTypePagerViewController
        : FlxBindableViewController<VacationTypePagerViewModel, VacationTypePagerParameters>
    {
        public VacationTypePagerViewController(VacationTypePagerParameters parameters) : base(parameters)
        {
        }

        public new VacationTypePagerView View
        {
            get => (VacationTypePagerView)base.View.NotNull();
            set => base.View = value;
        }

        public override void LoadView()
        {
            View = new VacationTypePagerView();


        }


        public override void Bind(BindingSet<VacationTypePagerViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(View.VacationImageView)
                .For(v => v.Image)
                .To(vm => vm.VacationType)
                .WithConvertion<ImageValueConverter>();

            bindingSet.Bind(View.VacationTypeLabel)
                .For(v => v.Text)
                .To(vm => vm.VacationType)
                .WithConvertion<VacationTypeValueConverter>();

        }
    }
}