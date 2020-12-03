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
        IAudioRecordingService _mediaService;

        void Record_Button_Clicked(Object sender, EventArgs e)
        {
            _mediaService = DependencyService.Get<IAudioRecordingService>();
            _mediaService.Record();
        }

        void Stop_Button_Clicked(Object sender, EventArgs e)
        {
            _mediaService = DependencyService.Get<IAudioRecordingService>();
            _mediaService.Stop();
        }

        void Play_Button_Clicked(Object sender, EventArgs e)
        {
            _mediaService = DependencyService.Get<IAudioRecordingService>();
            _mediaService.Play();
        }
    }
}
