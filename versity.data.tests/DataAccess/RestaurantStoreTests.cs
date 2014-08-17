using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using versity.data.DataAccess;
using versity.data.DataAccess.EntityFramework;
using versity.data.Models;
using NUnit.Framework;
using NSubstitute;
using FluentAssertions;

namespace versity.data.tests.DataAccess
{
    [TestFixture]
    public class RestaurantStoreTests : DatabaseTest
    {
        [SetUp]
        protected override void setup()
        {
            base.setup();
            _restaurantStore = new RestaurantStore(TestDbContext);
            ThenRestaurant = null;
        }

        [Test]
        public void ShouldAddAndUpdateRestaurant()
        {
            var restaurant = new Restaurant { Name = "bar", ID = 2 };
            WhenAdd(restaurant);
            WhenGet(restaurant.ID);
            ThenRestaurant.Name.Should().Be("bar");
            restaurant.Name = "other";
            WhenUpdate(restaurant);
            WhenGet(restaurant.ID);
            ThenRestaurant.Name.Should().Be("other");
        }

        [Test]
        public void ShouldFindByRestaurantID()
        {
            GivenRestaurantInContext(SomeRestaurant);
            WhenGet(SomeRestaurant.ID);
            ThenRestaurant.Name.Should().Be("foo");
        }

        [Test]
        public void ShouldReturnNullForNotFoundRestaurant()
        {
            GivenRestaurantInContext(SomeRestaurant);
            WhenGet(5);
            ThenRestaurant.Should().BeNull();
        }

        [Test]
        public void ShouldRemoveRestaurant()
        {
            GivenRestaurantInContext(SomeRestaurant);
            WhenRemove(SomeRestaurant.ID);
            WhenGet(SomeRestaurant.ID);
            ThenRestaurant.Should().BeNull();
        }

        private void GivenRestaurantInContext(Restaurant restaurant)
        {
            TestDbContext.Restaurants.Add(restaurant);
            SaveAndValidate();
        }

        private void WhenRemove(int id)
        {
            _restaurantStore.Remove(id);
        }

        private void WhenAdd(Restaurant restaurant)
        {
            _restaurantStore.Add(restaurant);
        }

        private void WhenGet(int id)
        {
            ThenRestaurant = _restaurantStore.GetByRestaurantID(id);
        }

        private void WhenUpdate(Restaurant restaurant)
        {
            _restaurantStore.Update(restaurant);
        }


        private Restaurant ThenRestaurant { get; set; }
        private IRestaurantStore _restaurantStore;
        private static readonly Restaurant SomeRestaurant = new Restaurant
        {
            ID = 1,
            Name = "foo",
            PhoneNumber = "123",
            Address = "111 bar st"
        };
    }
}
