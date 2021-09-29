using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ejercicio04
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Item1.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new TextToSpeechDemo());
            };

            Item2.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new BatteryDemo());
            };   
        }

        private async void btnScannerQR_Clicked(object sender, EventArgs e)
        {
            try
            {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                scanner.TopText = "Anthony Quito Scan ...";
                scanner.BottomText = "Laboratorio 07";
                var result = await scanner.Scan();
                if (result != null)
                {
                    txtResultado.Text = result.Text;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "OK");
            }
        }
    }
}
