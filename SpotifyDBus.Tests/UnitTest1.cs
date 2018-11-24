using NUnit.Framework;
using SpotifyDBus;
using System.Threading.Tasks;
using System;

namespace SpotifyDBus.Tests
{
    public class Tests
    {
        Spotify s;

        [SetUp]
        public void Setup()
        {
            s = new Spotify();
        }
    }
}