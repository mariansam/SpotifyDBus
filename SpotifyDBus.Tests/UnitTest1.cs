using NUnit.Framework;
using SpotifyDBus;
using System.Threading.Tasks;

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

        [Test]
        public async Task PauseTest()
        {
            await s.PauseAsync();
            Assert.Pass();
        }
    }
}