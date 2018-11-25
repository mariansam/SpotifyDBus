using System.Collections.Generic;
using System;

namespace SpotifyDBus
{
    public class Track
    {
        internal Track(IDictionary<string, object> dic)
        {
            TrackId = (string) dic["mpris:trackid"];
            Length = (ulong) dic["mpris:length"];
            ArtUrl = (string) dic["mpris:artUrl"];
            Album = (string) dic["xesam:album"];
            AlbumArtists = (string[]) dic["xesam:albumArtist"];
            Artists = (string[]) dic["xesam:artist"];
            AutoRating = (double) dic["xesam:autoRating"];
            DiscNumber = (int) dic["xesam:discNumber"];
            Title = (string) dic["xesam:title"];
            TrackNumber = (int) dic["xesam:trackNumber"];
            Url = (string) dic["xesam:url"];
        }

        public string TrackId { get; private set; }

        public ulong Length { get; private set; }

        public string ArtUrl { get; private set; }

        public string Album { get; private set; }

        public string[] AlbumArtists { get; private set; }

        public string[] Artists { get; private set; }

        public double AutoRating { get; private set; }

        public int DiscNumber { get; private set; }

        public string Title { get; private set; }

        public int TrackNumber { get; private set; }

        public string Url { get; private set; }

        public bool Equals(Track track) => (this.TrackId == track.TrackId);

        public override int GetHashCode() => TrackId.GetHashCode();

        public override string ToString() => $"{Artists[0]} - {Title}";
    }
}