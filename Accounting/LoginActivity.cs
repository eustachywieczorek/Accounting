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
    [Activity(Label = "MyGroceries", MainLauncher = false, Icon = "@drawable/icon")]
    public class LoginActivity : Activity
    {
        Button btnLogin;
        Button btnSignup;
        EditText txtEmail;
        EditText txtPassword;
        ProgressBar progressBarLogin;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login);
            // Get our button from the layout resource,
            // and attach an event to it

            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            progressBarLogin = FindViewById<ProgressBar>(Resource.Id.progressBarLogin);

            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.Click += Login_Click;

            btnSignup = FindViewById<Button>(Resource.Id.btnSignup);
            btnSignup.Click += Signup_Click;

            progressBarLogin.Visibility = ViewStates.Invisible;
            btnLogin.Visibility = ViewStates.Visible;
        }

        async void Login_Click(object sender, System.EventArgs e)
        {
            var username = txtEmail.Text;
            var password = txtPassword.Text;

            progressBarLogin.Visibility = ViewStates.Visible;
            btnLogin.Visibility = ViewStates.Invisible;

            try
            {
                await ParseUser.LogInAsync(txtEmail.Text, txtPassword.Text);
                // Login was successful.

                // TODO: Redirect to the landing page
                SetContentView(Resource.Layout.Home);

                var intent = new Intent(this, typeof(HomeActivity));
                StartActivity(intent);

            }
            catch (Exception ex)
            {
                // The login failed. Check the error to see why.
                progressBarLogin.Visibility = Android.Views.ViewStates.Invisible;
                btnLogin.Visibility = Android.Views.ViewStates.Visible;

                var error = ex.Message;

                var dialog = new AlertDialog.Builder(this);
                dialog.SetMessage("Login Failed! Please try again using valid credentials");
                dialog.SetNeutralButton("OK", delegate { });
                dialog.Show();
            }
        }

        void Signup_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RegisterActivity));
            StartActivity(intent);
        }
    }
}
