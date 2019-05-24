using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using App374;
using App374.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer (typeof (MyWebView), typeof (MyWebViewRenderer))]

namespace App374.Droid
{
    public class MyWebViewRenderer : WebViewRenderer
    {
        public MyWebViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                // lets get a reference to the native control
                var webView = (global::Android.Webkit.WebView)Control;
                webView.SetWebViewClient(new MyWebViewClient());
                webView.SetInitialScale(0);
                webView.Settings.JavaScriptEnabled = true;
            }
        }
    }

    public class MyWebViewClient : WebViewClient
    {
        public override void OnPageFinished(Android.Webkit.WebView view, string url)
        {
            base.OnPageFinished(view, url);

            MainPage.CurrentUrl = url;

            MainPage.checkToShowButton();
        }



        //public override WebResourceResponse ShouldInterceptRequest(Android.Webkit.WebView view, IWebResourceRequest request)
        //{

        //    MainPage.CurrentUrl = request.Url.Path;

        //    MainPage.checkToShowButton();

        //    return base.ShouldInterceptRequest(view, request);

        //}

        //public override bool ShouldOverrideUrlLoading(Android.Webkit.WebView view, string url)
        //{
        //    base.ShouldOverrideUrlLoading(view, url);

        //    Console.WriteLine("Current Url: {0}", url);
        //    MainPage.CurrentUrl = url;
        //    MainPage.checkToShowButton();

        //    return false;
        //}
    }

    public class JavaScriptResult : Java.Lang.Object, IValueCallback
    {
        public void OnReceiveValue(Java.Lang.Object val)
        {
            Console.WriteLine("Returned value: {0}", val);
        }
    }
}