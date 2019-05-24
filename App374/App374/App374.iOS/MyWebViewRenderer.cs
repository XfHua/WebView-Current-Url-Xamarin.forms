using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App374;
using App374.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyWebView), typeof(MyWebViewRenderer))]

namespace App374.iOS
{
    public class MyWebViewRenderer : WebViewRenderer,IUIWebViewDelegate
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {   // perform initial setup
                UIWebView myWebView = (UIWebView)this.NativeView;

                Delegate = new CustomWebViewDelegate(e.NewElement as WebView);
            }
        }
    }

    public class CustomWebViewDelegate : UIWebViewDelegate
    {
        Xamarin.Forms.WebView formsWebView;

        public CustomWebViewDelegate(WebView webView)
        {
            formsWebView = webView;
        }

        public override void LoadingFinished(UIWebView webView)
        {
            var url = webView.Request.Url.AbsoluteUrl.ToString();

            MainPage.CurrentUrl = webView.Request.Url.AbsoluteString;

            MainPage.checkToShowButton();
        }

    }
}