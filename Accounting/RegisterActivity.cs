using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Parse;

namespace Accounting
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        EditText txtName;
       
        EditText txtEmail;
        EditText txtPassword;
        EditText txtConfirmPassword;
        Button btnRegister;
        Button btnBack;
        ProgressBar progressBarRegister;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.Register);

            txtName = FindViewById<EditText>(Resource.Id.txtName);
            txtConfirmPassword = FindViewById<EditText>(Resource.Id.txtConfirmPassword);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            progressBarRegister = FindViewById<ProgressBar>(Resource.Id.progressBarRegister);


            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnRegister.Click += Register_Click;

            btnBack = FindViewById<Button>(Resource.Id.btnBack);
            btnBack.Click += Back_Click;

            progressBarRegister.Visibility = ViewStates.Invisible;
            btnRegister.Visibility = ViewStates.Visible;
        }
        async void Back_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Main);
        }

            async void Register_Click(object sender, EventArgs e)
        {

            SetContentView(Resource.Layout.Main);
            if (!txtEmail.Text.Contains(".") || !txtEmail.Text.Contains("@"))
            {

                // TODO: show an alert dialog or toast
                Toast.MakeText(this, "Enter a valid Email address", ToastLength.Long).Show();
                return;
            }

            // TODO: perform input validation for length of various EditText controls
            // TODO: perform password to confirm password validation
            // TODO: show progress bar and hide button control
            // TODO: call parse to register the user
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                // TODO: show an alert
                Toast.MakeText(this, "Password and Confirm Password must match", ToastLength.Long).Show();
                return;
            }

            progressBarRegister.Visibility = ViewStates.Visible;
            btnRegister.Visibility = ViewStates.Invisible;

            var user = new ParseUser()
            {
                Username = txtEmail.Text,
                Password = txtPassword.Text,
                Email = txtEmail.Text,
               
               
            };

            // other fields can be set just like with ParseObject
            user["Name"] = txtName.Text;
          

            try
            {
                await user.SignUpAsync();
                // TODO: redirect to Login page via an intent
                SetContentView(Resource.Layout.Main);



                var intent = new Intent(this, typeof(RegisterActivity));
                StartActivity(intent);
            }
            catch (Exception ex)
            {
                // TODO: registration failed, show an alert dialog                
                // The login failed. Check the error to see why.
                progressBarRegister.Visibility = ViewStates.Invisible;
                btnRegister.Visibility = ViewStates.Visible;

                var error = ex.Message;

                var dialog = new AlertDialog.Builder(this);
                dialog.SetMessage("Registration Failed! Please try again later");
                dialog.SetNeutralButton("OK", delegate { });
                dialog.Show();
            }

        }
    }
}

