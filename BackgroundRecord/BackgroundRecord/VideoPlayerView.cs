using System;
using Xamarin.Forms;

namespace BackgroundRecord
{
    public class VideoPlayerView : View
    {
        public object Surface { get; set; }
        public string FileName { get; set; }
        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create(nameof(Source), typeof(string), typeof(VideoPlayerView), null);

        public string Source
        {
            set { SetValue(SourceProperty, value); }
            get { return (string)GetValue(SourceProperty); }
        }
    }
}
