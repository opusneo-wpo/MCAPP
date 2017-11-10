using FormsPinView.PCL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WorkplaceON.Modules.Login.ViewModels
{
    class ConfirmPinAuthViewModel
    {        
        public PinViewModel PinViewModel { get; private set; } = new PinViewModel
        {

            TargetPinLength = 4,
            ValidatorFunc = (arg) =>
            {
                string pin = Application.Current.Properties["CreatePIN"] as string;
                char[] s_pin = pin.ToCharArray();
                Debug.WriteLine(@"Pin::" + pin);
                Debug.WriteLine(@"PinStatus::" + arg.SequenceEqual(s_pin));
                return arg.SequenceEqual(s_pin);
            }
        };
    }
}
