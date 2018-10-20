using System;
using spotify.DBus;
using Tmds.DBus;
using System.Threading.Tasks;

namespace SpotifyDBus
{
    public class Spotify
    {
        IPlayer proxy;

        public Spotify()
        {
            proxy = Connection.Session.CreateProxy<IPlayer>("org.mpris.MediaPlayer2.spotify", "/org/mpris/MediaPlayer2");
        }

        public async Task PauseAsync()
        {
            await proxy.PauseAsync();
        }
    }
}
