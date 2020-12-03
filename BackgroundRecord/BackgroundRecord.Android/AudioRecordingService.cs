﻿using Android;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Java.IO;

[assembly: Xamarin.Forms.Dependency(typeof(BackgroundRecord.Droid.AudioRecordingService))]
[assembly: UsesPermission(Android.Manifest.Permission.RecordAudio)]
[assembly: UsesPermission(Android.Manifest.Permission.ReadExternalStorage)]
[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]
namespace BackgroundRecord.Droid
{
    public class AudioRecordingService : IAudioRecordingService
    {
        MediaRecorder _mediaRecorder;
        public void Record()
        {
            CheckForPermissions();
            try
            {
                _mediaRecorder = new MediaRecorder();
                _mediaRecorder.Reset();
                _mediaRecorder.SetAudioSource(AudioSource.Mic);
                _mediaRecorder.SetOutputFormat(OutputFormat.Mpeg2Ts);
                _mediaRecorder.SetOutputFile(GetFileName());
                _mediaRecorder.SetAudioEncoder(AudioEncoder.Aac);
                _mediaRecorder.Prepare();
                _mediaRecorder.Start();
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        public void Stop()
        {
            try
            {
                _mediaRecorder.Stop();
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }

        private string GetFileName()
        {
            var path = Environment.ExternalStorageDirectory.AbsolutePath + "/MyFamily/";
            var dir = new File(path);
            if (!dir.Exists())
                dir.Mkdirs();
            var myfile = path + "filename.3gp";
            return myfile;
        }
        private void CheckForPermissions()
        {
            if (!(MainActivity.Instance.CheckSelfPermission(Manifest.Permission.RecordAudio) == Android.Content.PM.Permission.Granted &&
                    MainActivity.Instance.CheckSelfPermission(Manifest.Permission.ReadExternalStorage) == Android.Content.PM.Permission.Granted &&
                    MainActivity.Instance.CheckSelfPermission(Manifest.Permission.WriteExternalStorage) == Android.Content.PM.Permission.Granted))
            {
                MainActivity.Instance.RequestPermissions(new string[] { Manifest.Permission.RecordAudio, Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage }, 1);
            }

        }
    }
}