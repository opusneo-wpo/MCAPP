using System.Linq;
using FormsPinView.PCL;
using System.Diagnostics;
using Xamarin.Forms;

namespace WorkplaceON.Modules.Login.ViewModels
{
    class PinAuthViewModel
    {
        //private static readonly char[] s_pin = new[] { '1', '2', '3', '4' };


        public PinViewModel PinViewModel { get; private set; } = new PinViewModel
        {

            TargetPinLength = 4,
            ValidatorFunc = (arg) =>
            {
                string combindedString = string.Join("", arg.ToArray());
                Application.Current.Properties["CreatePIN"] = combindedString;
                Debug.WriteLine(@"arg:::" + combindedString);
                return true;
            }
        };
    }
}
