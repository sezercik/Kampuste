using Android.App;
using Android.Content.PM;
using Android.Content;


namespace Kampuste.Maui.Platforms.Android;
//Name = "Kampuste.Maui.Platforms.Android.WebAuthenticaionCallbackActivity",
[Activity( NoHistory = true, LaunchMode = LaunchMode.SingleTop, Exported = true)]
[IntentFilter(new[] { Intent.ActionView },
              Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
              DataScheme = "kampuste")]
public class WebAuthenticationCallbackActivity : Microsoft.Maui.Authentication.WebAuthenticatorCallbackActivity
{
    //const string CALLBACK_SCHEME = App.CallbackUri;

}