using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parse;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net;

namespace Accounting
{
    public class RegisterEventArgs : EventArgs
    {
        class dialog_Reg : DialogFragment
        {
            private Button btnRegister;
            private EditText txtName;
            private EditText txtEmail;
            private EditText txtPass;

            public event EventHandler<RegisterEventArgs> OnRegister;
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                base.OnCreateView(inflater, container, savedInstanceState);

                SetContentView(Resource.Layout.dialog_sign_up);

                var view = inflater.Inflate(Resource.Layout.dialog_sign_up, container, false);
                btnRegister = view.FindViewById<Button>(Resource.Id.btnRegister);
                txtName = view.FindViewById<EditText>(Resource.Id.txtName);
                txtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
                txtPass = view.FindViewById<EditText>(Resource.Id.txtPass);

                btnRegister.Click += btnRegister_Click;

                return view;



            }
            async void btnRegister_Click(object sender, EventArgs e)
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




                var user = new ParseUser()
                {
                    Username = txtEmail.Text,
                    Password = txtPass.Text,
                    Email = txtEmail.Text
                };

                // other fields can be set just like with ParseObject
                user["Name"] = txtName.Text;


                try
                {
                    await user.SignUpAsync();
                    // TODO: redirect to Login page via an intent
                    SetContentView(Resource.Layout.Main);



                    var intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);
                }
                catch (Exception ex)
                {
                    // TODO: registration failed, show an alert dialog                
                    // The login failed. Check the error to see why.


                    var error = ex.Message;

                    var dialog = new AlertDialog.Builder(this);
                    dialog.SetMessage("Registration Failed! Please try again later");
                    dialog.SetNeutralButton("OK", delegate { });
                    dialog.Show();
                }
            }


        }
    }
}
