public interface IMultimediaDevice
{
    public void Play();
    public void Stop();
    public void Pause();
    public void Next();
    public void IncreaseVolume();
    public void DecreaseVolume();

}

public class MP3Player : IMultimediaDevice
{
    public MP3Player(List <string> Songs)
    {
        SongIndex = 0;
        songs = Songs;
        Volume = 50;
        Song = songs[SongIndex];
    }
    public string Song { get; set; }
    public int Volume { get; set; }
    public List<string> songs;
    public int SongIndex;
    public void DecreaseVolume()
    {
        Volume--;
    }

    public void IncreaseVolume()
    {
        Volume++;
    }

    public void Next()
    {
        SongIndex++;
        SongIndex %= songs.Count;
        Song = songs[SongIndex];
    }

    public void Pause()
    {
        Console.WriteLine("Pause");
    }

    public void Play()
    {
        Console.WriteLine($"Играет песня {Song}");
    }

    public void Stop()
    {
        Console.WriteLine("Stop");
    }
}

public class DVDPlayer : IMultimediaDevice
{
    public DVDPlayer(List<string> Videos)
    {
        VideoIndex = 0;
        videos = Videos;
        Volume = 50;
        Video = videos[VideoIndex];
    }
    public string Video { get; set; }
    public int Volume { get; set; }
    public List<string> videos;
    public int VideoIndex;
    public void DecreaseVolume()
    {
        Volume--;
    }

    public void IncreaseVolume()
    {
        Volume++;
    }

    public void Next()
    {
        VideoIndex++;
        VideoIndex %= videos.Count;
        Video = videos[VideoIndex];
    }

    public void Pause()
    {
        Console.WriteLine("Pause");
    }

    public void Play()
    {
        Console.WriteLine($"Играет видео {Video}");
    }

    public void Stop()
    {
        Console.WriteLine("Stop");
    }
}

public class Radio : IMultimediaDevice
{
    public Radio()
    {
        Frequency = 88.0;
        Volume = 50;
    }
    public double Frequency { get; set; }
    public int Volume { get; set; }

    public void DecreaseVolume()
    {
        Volume--;
    }

    public void IncreaseVolume()
    {
        Volume++;
    }

    public void Next()
    {
        Frequency += 0.2;
        if (Frequency > 107.0)
        {
            Frequency = 88.0;
        }
    }

    public void Pause()
    {
        Console.WriteLine("Pause");
    }

    public void Play()
    {
        Console.WriteLine($"Играет частота {Frequency}");
    }

    public void Stop()
    {
        Console.WriteLine("Stop");
    }
}

public class Program
{
    public static void MediaService(IMultimediaDevice device)
    {
        device.Play();
        device.Stop();
        device.Pause();
        device.Next();
        device.IncreaseVolume();
        device.DecreaseVolume();
    }
    public static void Main()
    {
        List<IMultimediaDevice> devices = new List<IMultimediaDevice>();
        List<string> songs = new List<string>() { "song1", "song2", "song3"};
        List<string> videos = new List<string>() { "video1", "video2", "video3"};
        devices.Add(new Radio());
        devices.Add(new DVDPlayer(videos));
        devices.Add(new MP3Player(songs));

        int choice = 0;
        do
        {
            Console.WriteLine("Выберите устройство ");
            Console.WriteLine("1 - radio");
            Console.WriteLine("2 - DVD");
            Console.WriteLine("3 - MP3");
            Console.WriteLine("0 - exit");
            choice = int.Parse(Console.ReadLine());
            MediaService(devices[choice - 1]);
        } while (choice != 0);
        

    }
}
