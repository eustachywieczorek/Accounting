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
using System.IO;
using SQLite;

namespace Accounting
{
    [Activity(Label = "Summary")]
    public class SummaryActivity : Activity
    {

        EditText txtName;
        EditText txtItem;
        EditText txtCost;
        EditText txtDate;
        ListView tblBooks;
        Button btnFinish;
        Button btnBack;
        string filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "InvoiceList.db3");

        private void PopulateListView()
        {

            var db = new SQLiteConnection(filePath);

            var invoiceList = db.Table<Invoice>();

            List<string> invoiceTitles = new List<string>();

            foreach (var invoice in invoiceList) { invoiceTitles.Add(invoice.InvoiceTitle); }


            tblBooks.Adapter = new ArrayAdapter<Invoice>(this, Android.Resource.Layout.SimpleListItem1, invoiceList.ToArray());

        }
        protected override void OnCreate(Bundle savedInstanceState)
        {



            base.OnCreate(savedInstanceState);
            try
            {
                // Create our connection, if the database and/or table doesn't exist create it
                var db = new SQLiteConnection(filePath);
                db.CreateTable<Invoice>();

            }
            catch (IOException ex)
            {
                var reason = string.Format("Failed to create Table - reason {0}", ex.Message);
                Toast.MakeText(this, reason, ToastLength.Long).Show();
            }
            SetContentView(Resource.Layout.Invoice);


            txtName = FindViewById<EditText>(Resource.Id.txtName);
            txtItem = FindViewById<EditText>(Resource.Id.txtItem);
            txtCost = FindViewById<EditText>(Resource.Id.txtCost);
            txtDate = FindViewById<EditText>(Resource.Id.txtDate);
            tblBooks = FindViewById<ListView>(Resource.Id.tblBooks);
            btnFinish = FindViewById<Button>(Resource.Id.btnFinish);
            btnFinish.Click += btnFinish_Click;
            btnBack = FindViewById<Button>(Resource.Id.btnBack);
            btnBack.Click += btnBack_Click;
            PopulateListView();

        }
        void btnFinish_Click(object sender, System.EventArgs e)
        {

            string alertTitle, alertMessage;

            if (!string.IsNullOrEmpty(txtName.Text))
            {
                var newInvoice = new Invoice { InvoiceTitle = txtName.Text, Item = txtItem.Text, Cost = txtCost.Text, Date = txtDate.Text };
                var db = new SQLiteConnection(filePath);
                db.Insert(newInvoice);

                alertTitle = "Success";
                alertMessage = string.Format("Invoice ID: {0} with Title: {1} has been succesfully added!", newInvoice.InvoiceId, newInvoice.InvoiceTitle);
                PopulateListView();
            }
            else

            {
                alertTitle = "Failed";
                alertMessage = "Enter a valid Customer Name";
            }
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle(alertTitle);
            alert.SetMessage(alertMessage);
            alert.SetPositiveButton("OK", (senderAlert, args) =>
            {
                Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();

            });
            alert.SetNegativeButton("Cancel", (senderAlert, args) =>
            {
                Toast.MakeText(this, "Cancelled", ToastLength.Short).Show();
            });
            Dialog dialog = alert.Create();
            dialog.Show();
        }
        void btnBack_Click(object sender, System.EventArgs e)
        {
            SetContentView(Resource.Layout.Home);

            var intent = new Intent(this, typeof(HomeActivity));
            StartActivity(intent);
        }

    }
}