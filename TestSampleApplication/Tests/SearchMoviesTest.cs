using Core.Factory;
using Core.UIItems;
using Core.UIItems.TableItems;
using Core.UIItems.WindowItems;
using NUnit.Framework;

namespace TestSampleApplication.Tests
{
    [TestFixture]
    public class SearchMoviesTest : VideoLibraryTest
    {
        [Test]
        public void SearchByName()
        {
            Window searchWindow = LaunchSearchMovies();
            searchWindow.Get<TextBox>("nameTextbox").Text = "Taare";
            searchWindow.Get<Button>("search").Click();
            Assert.AreEqual(1, searchWindow.Get<Table>("foundMovies").Rows.Count);
        }

        [Test]
        public void SearchByDirector()
        {
            Window searchWindow = LaunchSearchMovies();
            searchWindow.Get<TextBox>("directorTextbox").Text = "Aamir";
            searchWindow.Get<Button>("search").Click();
            Assert.AreEqual(1, searchWindow.Get<Table>("foundMovies").Rows.Count);
        }

        [Test]
        public void SearchUsingFactory()
        {
            Window searchWindow = LaunchSearchMovies();
            searchWindow.Get<TextBox>("directorTextbox").Text = "Aamir";
            searchWindow.Get<Button>("search").Click();
            Assert.AreEqual(1, searchWindow.Get<Table>("foundMovies").Rows.Count);
        }

        private Window LaunchSearchMovies()
        {
            Hyperlink searchMoviesLink = window.Get<Hyperlink>("searchMovies");
            searchMoviesLink.Click();
            return window.ModalWindow("Search Movies", InitializeOption.NoCache);
        }
    }
}