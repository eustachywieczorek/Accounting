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

namespace Accounting
{
    [Activity(Label = "HomeActivity")]
    public class HomeActivity : Activity
    {
        Button btnShow;
        Button btnInvoice;
        Button btnLogout;


        protected override void OnCreate(Bundle savedInstanceState)
        {


            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Home);

            btnShow = FindViewById<Button>(Resource.Id.btnShow);
            btnShow.Click += btnShow_Click;
            btnInvoice = FindViewById<Button>(Resource.Id.btnInvoice);
            btnInvoice.Click += btnInvoice_Click;
            btnLogout = FindViewById<Button>(Resource.Id.btnLogout);
            btnLogout.Click += btnLogout_Click;

        }
        void btnShow_Click(object sender, System.EventArgs e)
        {
            SetContentView(Resource.Layout.Summary);

            var intent = new Intent(this, typeof(SummaryActivity));
            StartActivity(intent);

        }

        void btnInvoice_Click(object sender, System.EventArgs e)
        {



            // Login was successful.

            // TODO: Redirect to the landing page
            SetContentView(Resource.Layout.Invoice);

            var intent = new Intent(this, typeof(InvoiceActivity));
            StartActivity(intent);


        }
        void btnLogout_Click(object sender, System.EventArgs e)
        {



            // Login was successful.

            // TODO: Redirect to the landing page
            SetContentView(Resource.Layout.Main);

            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}