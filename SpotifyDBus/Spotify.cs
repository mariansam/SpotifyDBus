using System;
using spotify.DBus;
using Tmds.DBus;
using System.Threading.Tasks;

namespace SpotifyDBus
{
    public class Spotify
    {
        IPlayer proxy;

        public Spotify() : this("org.mpris.MediaPlayer2.spotify")
        { }

        public Spotify(string service)
        {
            proxy = Connection.Session.CreateProxy<IPlayer>(service, "/org/mpris/MediaPlayer2");
        }

        public async Task PauseAsync() => await proxy.PauseAsync();

        public async Task PlayAsync() => await proxy.PlayAsync();

        public async Task PlayPauseAsync() => await proxy.PlayPauseAsync();

        public async Task PreviousAsync() => await proxy.PreviousAsync();

        public async Task NextAsync() => await proxy.NextAsync();

        public async Task SeekAsync(long offset) => await proxy.SeekAsync(offset);

        public double Volume
        {
            get => proxy.GetVolumeAsync().Result;

            set => proxy.SetVolumeAsync(value);
        }

        public bool Shuffle
        {
            get => proxy.GetShuffleAsync().Result;

            set => proxy.SetShuffleAsync(value);
        }

        public PlaybackStatus PlaybackStatus
        {
            get
            {
                string status = proxy.GetPlaybackStatusAsync().Result;

                if (status == "Playing")
                    return PlaybackStatus.Playing;
                else if (status == "Paused")
                    return PlaybackStatus.Paused;
                else
                    return PlaybackStatus.Stopped;
            }
        }

        public LoopStatus LoopStatus
        {
            get
            {
                string status = proxy.GetLoopStatusAsync().Result;

                if (status == "None")
                    return LoopStatus.None;
                else if (status == "Track")
                    return LoopStatus.Track;
                else
                    return LoopStatus.Playlist;
            }

            set => proxy.SetLoopStatusAsync(value.ToString());
        }

        public Track Track
        {
            get => new Track(proxy.GetMetadataAsync().Result);
        }
    }
}
