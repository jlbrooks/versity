using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using versity.Controllers;
using NSubstitute;
using versity.data.DataAccess;
using versity.data.Models;

namespace versity.tests.Controllers
{
    [TestFixture]
    public class RestaurantControllerTests
    {
        [SetUp]
        public void setup()
        {
            _restaurantStore = Substitute.For<IRestaurantStore>();
            _controller = new RestaurantController(_restaurantStore);
        }

        [Test]
        public void ShouldReturnViewOnIndex()
        {
            whenIndexIsCalled();
            _thenResult.Should().BeOfType<ViewResult>();
        }

        [Test]
        public void ShouldPassRestaurantListToView()
        {
            givenRestaurantData(_someData);
            whenIndexIsCalled();
            var foo = _thenResult.As<ViewResult>().ViewData.Model.Should().Equals(_someData);
        }

        private void givenRestaurantData(List<Restaurant> data)
        {
            _restaurantStore.All().Returns(_someData);
        }

        private void whenIndexIsCalled()
        {
            _thenResult = _controller.Index();
        }

        private static readonly List<Restaurant> _someData = new List<Restaurant> {new Restaurant{Name = "foo", PhoneNumber = "123" } };

        private RestaurantController _controller;
        private ActionResult _thenResult;
        private IRestaurantStore _restaurantStore;
    }
}