using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using WorkplaceON.Droid.Renderers;

[assembly: ExportRenderer(typeof(Entry), typeof(MyEntryRenderer))]
namespace WorkplaceON.Droid.Renderers
{
    public class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundResource(Resource.Drawable.EntryBorder);
            }
        }
    }
}