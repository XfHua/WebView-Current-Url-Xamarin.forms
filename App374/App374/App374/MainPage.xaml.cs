using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App374
{
    public partial class MainPage : ContentPage
    {
        public static string CurrentUrl { get; set; }

        public static MyWebView _webView;

        public static Grid grid;

        public static Button BackButton;


        public MainPage()
        {

            InitializeComponent();

            string CurrentUrl = "https://www.baidu.com/";

            _webView = new MyWebView()
            {
                Source = CurrentUrl,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };


            BackButton = new Button
            {
                Text = "Go Back",
                BackgroundColor = Color.FromHex("990000"),
                TextColor = Color.White
            };

            grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(15, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(15, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(36, GridUnitType.Absolute) }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(50, GridUnitType.Absolute) },
                    new ColumnDefinition { Width = new GridLength(50, GridUnitType.Absolute) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = GridLength.Auto }
                }
            };

            grid.Children.Add(_webView, 0, 6, 0, 7);


            Content = grid;

            checkToShowButton();

            //Button click
            BackButton.Clicked += OnBackButtonClicked;
            void OnBackButtonClicked(object sender, EventArgs e)
            {
                _webView.GoBack();        

                checkToShowButton();

                if (_webView.CanGoBack == false)
                {
                    grid.Children.Remove(BackButton);
                }
            }
        }

        //Check whther to show goBack button
        public static void checkToShowButton()
        {

            if ("https://www.baidu.com/".Equals(MainPage.CurrentUrl) || CurrentUrl == null || CurrentUrl == "")
            {
                grid.Children.Remove(BackButton);
            }
            else
            {

                if (grid != null)
                {
                    grid.Children.Add(BackButton, 2, 4, 4, 6);
                }

            }
        }

    }


    public class MyWebView : WebView {

    }
}
