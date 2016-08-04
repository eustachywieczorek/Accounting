using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Parse;
using System.Collections.Generic;


namespace Accounting
{
    [Activity(Label = "Accounting", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btnLogin;
        Button btnRegister;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            // Get our button from the layout resource,
            // and attach an event to it
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.Click += Login_Click;

            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnRegister.Click += Register_Click;
        }
        void Login_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(LoginActivity));
            StartActivity(intent);
        }
        void Register_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RegisterActivity));
            StartActivity(intent);
        }

    }
}