using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BackgroundRecord
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void Record_Button_Clicked(Object sender, EventArgs e)
        {
            var appReviewer = DependencyService.Get<IAudioRecordingService>();
            appReviewer.Record();
        }

        void Stop_Button_Clicked(Object sender, EventArgs e)
        {
            var appReviewer = DependencyService.Get<IAudioRecordingService>();
            appReviewer.Stop();
        }
    }
}
