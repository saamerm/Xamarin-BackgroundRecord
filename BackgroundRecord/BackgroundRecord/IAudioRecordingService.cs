using System;
namespace BackgroundRecord
{
    public interface IAudioRecordingService
    {
        void Record();
        void Stop();
        void Play();
    }
}
