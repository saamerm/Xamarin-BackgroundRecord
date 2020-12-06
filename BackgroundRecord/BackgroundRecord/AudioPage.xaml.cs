using System;
using Xamarin.Forms;

namespace BackgroundRecord
{
    public partial class AudioPage : ContentPage
    {
        public AudioPage()
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
