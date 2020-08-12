using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSampleProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            var myMusic = new Muzik("Justin Biber");
            var myVideo = new Video("Funny videos");

            var mediaPlayer = new MediaPlayer();
            mediaPlayer.Play(myMusic);
            mediaPlayer.Play(myVideo);

            mediaPlayer.Stop(myMusic);
            mediaPlayer.Stop(myVideo);

            StorageProvider<IMedia> provider = new StorageProvider<IMedia>();
            provider.AddMedia(myMusic);
            provider.AddMedia(myVideo);
           (int videoCount, int muzikCount) = provider.SummarizeMedia();

            Console.WriteLine($"Muzik count {muzikCount}, Video count {videoCount}");


            Console.ReadKey();
        }
    }

    internal abstract class BaseMedia<T> where T : IMedia
    {
        public void Play()
        {
            Console.WriteLine($"{ typeof(T).Name} is playing");
        }

        public void Stop()
        {
            Console.WriteLine($"{ typeof(T).Name} is stopping");
        }
    }

    public interface IMedia
    {
       string Name { get; set; }
    }

    internal class Muzik :  IMedia
    {
        public string Name { get ; set; }
        public Muzik(string musicName)
        {
            Name = musicName;
        }

   
    }

    internal class Video : IMedia
    {
        public string Name { get; set; }
        public Video(string videoName)
        {
            Name = videoName;
        }

    }

    internal abstract class BaseMediaPlayer
    {

        internal void Play(IMedia media) => Console.WriteLine($"{media.Name} is playing");
        internal void Stop(IMedia media) => Console.WriteLine($"{media.Name} is stopping");

    }

    internal class MediaPlayer:BaseMediaPlayer
    {

    }

    internal class StorageProvider<T> where T: IMedia
    {
        List<T> mediaBag;

        public StorageProvider()
        {
            mediaBag = new List<T>();
        }

        internal void AddMedia(T media)
        {
            mediaBag.Add(media);
        }

        internal (int videoCount, int musicCount) SummarizeMedia()
        {
            var videoCount = mediaBag.Where(t => t.GetType() == typeof(Video)).Count();
            var musicCount = mediaBag.Where(t => t.GetType() == typeof(Muzik)).Count();
            return (videoCount, musicCount);
        }
    }
}
