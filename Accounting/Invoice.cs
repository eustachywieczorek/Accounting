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
using SQLite;
namespace Accounting
{
    class Invoice
    {
        [PrimaryKey, AutoIncrement]
        public int InvoiceId { get; set; }
        public string InvoiceTitle { get; set; }
        public string Date { get; set; }
        public string Cost { get; set; }
        public string Item { get; set; }

        public override string ToString()
        {
            return InvoiceTitle + ", "  + Date + " " + Item + ", $" + Cost;
           // +Item + ", $" + Cost + ", "
        }

    }
}