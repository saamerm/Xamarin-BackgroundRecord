using System;
using System.ComponentModel;
using Android;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using BackgroundRecord;
using BackgroundRecord.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ARelativeLayout = Android.Widget.RelativeLayout;

[assembly: ExportRenderer(typeof(VideoPlayerView), typeof(VideoPlayerViewRenderer))]
[assembly: UsesPermission(Manifest.Permission.Internet)]
namespace BackgroundRecord.Droid
{
    public class VideoPlayerViewRenderer : ViewRenderer<VideoPlayerView, ARelativeLayout>
    {
        VideoView _videoView;
        MediaController _mediaController;
        public VideoPlayerViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<VideoPlayerView> args)
        {
            base.OnElementChanged(args);

            if (args.NewElement != null && Control == null)
            {
                _videoView = new VideoView(Context);

                ARelativeLayout relativeLayout = new ARelativeLayout(Context);
                relativeLayout.AddView(_videoView);

                ARelativeLayout.LayoutParams layoutParams =
                    new ARelativeLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
                layoutParams.AddRule(LayoutRules.CenterInParent);
                _videoView.LayoutParameters = layoutParams;

                _mediaController = new MediaController(Context);
                _mediaController.SetMediaPlayer(_videoView);
                _videoView.SetMediaController(_mediaController);

                SetNativeControl(relativeLayout);
                _videoView.Prepared += OnVideoViewPrepared;

            }
            if (args.NewElement == null)
            {
                _videoView.Prepared -= OnVideoViewPrepared;
            }
            SetTransportControls();
            SetSource(Element.Source);
        }

        private void SetTransportControls()
        {
            _mediaController = new MediaController(Context);
            _mediaController.SetMediaPlayer(_videoView);
            _videoView.SetMediaController(_mediaController);
        }


        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);

            if (args.PropertyName == VideoPlayerView.SourceProperty.PropertyName)
            {
                SetSource(Element.Source);
            }
        }

        private void SetSource(String source)
        {
            string uri = source;

            if (!String.IsNullOrWhiteSpace(uri))
                _videoView.SetVideoURI(Android.Net.Uri.Parse(uri));
        }


        protected override void Dispose(bool disposing)
        {
            if (Control != null && _videoView != null)
            {
                _videoView.Prepared -= OnVideoViewPrepared;
            }
            base.Dispose(disposing);
        }

        private void OnVideoViewPrepared(object sender, EventArgs args)
        {
            _videoView.Start();
        }
    }
}
