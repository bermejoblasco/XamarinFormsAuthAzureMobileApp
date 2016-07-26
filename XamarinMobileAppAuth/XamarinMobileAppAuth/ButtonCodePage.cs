
namespace XamarinMobileAppAuth
{
    using System;
    using Xamarin.Forms;

    class ButtonCodePage : ContentPage
    {
        public ButtonCodePage()
        {
            Button button = new Button
            {
                Text = String.Format("Login Azure ADd"),
                
            };
            button.Clicked += async (sender, args) =>
            {
                if (App.Authenticator != null)
                {
                    var auth = await App.Authenticator.Authenticate();
                }
            };

            this.Content = button;
        }
    }
}
