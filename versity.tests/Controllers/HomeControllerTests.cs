using System;
using System.Web.Mvc;
using FluentAssertions;
using NUnit.Framework;
using versity.Controllers;

namespace versity.tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [SetUp]
        public void SetUp()
        {
            _homeController = new HomeController();
        }

        [Test]
        public void ShouldReturnView()
        {
            whenIndexIsCalled();
            _thenResult.Should().BeOfType<ViewResult>();
        }

        private void whenIndexIsCalled()
        {
            _thenResult = _homeController.Index();
        }

        private HomeController _homeController;
        private ActionResult _thenResult;
    }
}
