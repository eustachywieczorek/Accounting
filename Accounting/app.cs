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
    [Application]
    public class App : Application
    {
        public App(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

        public override void OnCreate()
        {
            base.OnCreate();

            ParseClient.Initialize("I360Jj31zx8nKq6QflKBqkrlyfEEGF1KVHYiKE9N", "t460rs9VcKNhGf7yDmjmurWaOly1WWI1GJLxZRlu");
        }
    }
}