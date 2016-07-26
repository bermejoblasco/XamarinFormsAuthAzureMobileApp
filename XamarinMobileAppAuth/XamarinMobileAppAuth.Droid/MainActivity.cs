using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Threading.Tasks;

namespace XamarinMobileAppAuth.Droid
{

    [Activity(Label = "XamarinMobileAppAuth", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity, IAuthenticate
    {
        // Define a authenticated user.
        private MobileServiceUser user;

        public async Task<bool> Authenticate()
        {
            var success = false;
            var message = string.Empty;
            try
            {
                // Sign in with Azure AD login using a server-managed flow.

                user = await ServiceManager.DefaultManager.CurrentClient.LoginAsync(this, MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory);
                if (user != null)
                {
                    message = string.Format("you are now signed-in as {0}.", user.UserId);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            // Display the success or failure message.
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetMessage(message);
            builder.SetTitle("Sign-in result");
            builder.Create().Show();

            return success;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Xamarin.Forms.Forms.Init(this, bundle);
            App.Init((IAuthenticate)this);
            LoadApplication(new App());
        }
    }
}

