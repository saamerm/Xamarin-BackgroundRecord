using System;
using AVFoundation;
using AVKit;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


using System.ComponentModel;
using System.IO;
using CoreMedia;
using Foundation;
using BackgroundRecord;

[assembly: ExportRenderer(typeof(VideoPlayerView), typeof(BackgroundRecord.iOS.VideoPlayerRenderer))]
namespace BackgroundRecord.iOS
{

    public class VideoPlayerRenderer : ViewRenderer<VideoPlayerView, UIView>
    {
        AVPlayer _player;
        AVPlayerItem _playerItem;
        AVPlayerViewController _playerViewController;
        VideoPlayerView _videoPlayer;

        public override UIViewController ViewController => _playerViewController;

        public VideoPlayerRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<VideoPlayerView> e)
        {

            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    // Create AVPlayerViewController
                    _playerViewController = new AVPlayerViewController
                    {
                        //ExitsFullScreenWhenPlaybackEnds = true
                    };
                    // Set Player property to AVPlayer
                    _player = new AVPlayer(new NSUrl(Element.Source));
                    _playerViewController.Player = _player;

                    // Use the View from the controller as the native control
                    SetNativeControl(_playerViewController.View);
                }

                _videoPlayer = e.NewElement;
            }

            if (e.OldElement != null)
            {

            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (_player != null)
            {
                _player.ReplaceCurrentItemWithPlayerItem(null);
            }
        }

    }
}