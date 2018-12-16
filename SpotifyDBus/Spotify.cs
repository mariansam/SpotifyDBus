using System;
using spotify.DBus;
using Tmds.DBus;
using System.Threading.Tasks;

namespace SpotifyDBus
{
    public class Spotify
    {
        IPlayer proxy;

        /// <summary>
        /// Creates a new instance of Spotify.
        /// </summary>
        public Spotify() : this("org.mpris.MediaPlayer2.spotify")
        { }

        /// <summary>
        /// Creates a new instance of a mpris-compatible player.
        /// </summary>
        /// <param name="service">Service name. eg. org.mpris.MediaPlayer2.spotify</param>
        public Spotify(string service)
        {
            proxy = Connection.Session.CreateProxy<IPlayer>(service, "/org/mpris/MediaPlayer2");
        }

        /// <summary>
        /// Pauses playback.
        /// </summary>
        public async Task PauseAsync() => await proxy.PauseAsync();

        /// <summary>
        /// Starts or resumes playback.
        /// </summary>
        public async Task PlayAsync() => await proxy.PlayAsync();

        /// <summary>
        /// Toggles between pause and play.
        /// </summary>
        public async Task PlayPauseAsync() => await proxy.PlayPauseAsync();

        /// <summary>
        /// Skips to the previous track in the tracklist.
        /// </summary>
        public async Task PreviousAsync() => await proxy.PreviousAsync();

        /// <summary>
        /// Skips to the next track in the tracklist.
        /// </summary>
        public async Task NextAsync() => await proxy.NextAsync();

        /// <summary>
        /// Seeks forward in the current track by the specified number of microseconds.
        /// </summary>
        /// <param name="offset">The number of microseconds to seek forward. A negative value seeks back.</param>
        public async Task SeekAsync(long offset) => await proxy.SeekAsync(offset);

        // TODO: inline docs
        public double Volume
        {
            get => proxy.GetVolumeAsync().Result;

            set => proxy.SetVolumeAsync(value);
        }

        /// <summary>
        /// Indicates that the playback is shuffling.
        /// </summary>
        public bool Shuffle
        {
            get => proxy.GetShuffleAsync().Result;

            set => proxy.SetShuffleAsync(value);
        }

        /// <summary>
        /// The current <see cref="PlaybackStatus" />
        /// </summary>
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

        /// <summary>
        /// The current <see cref="LoopStatus" />
        /// </summary>
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

        /// <summary>
        /// The currently playing <see cref="Track" />
        /// </summary>
        /// <value></value>
        public Track Track
        {
            get => new Track(proxy.GetMetadataAsync().Result);
        }
    }
}
