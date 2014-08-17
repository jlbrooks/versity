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
            _controller = new RestaurantsController(_restaurantStore);
        }

        [Test]
        public void ShouldReturnViewOnIndex()
        {
            whenIndexIsCalled();
            _thenResult.Should().BeOfType<ViewResult>();
        }

        [Test]
        public void ShouldPassRestaurantListToIndexView()
        {
            givenRestaurantList(_someData);
            whenIndexIsCalled();
            var foo = _thenResult.As<ViewResult>().ViewData.Model.Should().Equals(_someData);
        }

        [Test]
        public void ShouldReturnViewOnNew()
        {
            whenGetNew();
            _thenResult.Should().BeOfType<ViewResult>();
        }

        [Test]
        public void ShouldReturnViewOnEdit()
        {
            givenRestaurant(_someRestaurant);
            whenGetEdit(-1);
            _thenResult.Should().BeOfType<ViewResult>();
        }

        [Test]
        public void ShouldRedirectOnBadIdToEdit()
        {
            whenGetEdit(-5);
            _thenResult.Should().BeOfType<RedirectToRouteResult>();
        }

        [Test]
        public void ShouldPassRestaurantToEditToView()
        {
            givenRestaurant(_someRestaurant);
            whenGetEdit(-1);
            _thenResult.As<ViewResult>().ViewData.Model.Should().Equals(_someRestaurant);
        }

        [Test]
        public void DeleteShouldRedirect()
        {
            givenRestaurant(_someRestaurant);
            whenPostDelete(-1);
            _thenResult.Should().BeOfType<RedirectToRouteResult>();
        }

        private void givenRestaurant(Restaurant restaurant)
        {
            _restaurantStore.GetByRestaurantID(restaurant.ID).Returns(restaurant);
        } 

        private void givenRestaurantList(List<Restaurant> data)
        {
            _restaurantStore.All().Returns(_someData);
        }
        private void whenGetEdit(int id)
        {
            _thenResult = _controller.Edit(id);
        }

        private void whenPostDelete(int id)
        {
            _thenResult = _controller.Delete(id);
        }

        private void whenGetNew()
        {
            _thenResult = _controller.New();
        }

        private void whenIndexIsCalled()
        {
            _thenResult = _controller.Index();
        }

        private static readonly List<Restaurant> _someData = new List<Restaurant> {_someRestaurant };
        private static readonly Restaurant _someRestaurant = new Restaurant{ ID = -1, Name = "foo", PhoneNumber = "123" };

        private RestaurantsController _controller;
        private ActionResult _thenResult;
        private IRestaurantStore _restaurantStore;
    }
}