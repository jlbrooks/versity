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
    public class ItemStoreTests : DatabaseTest
    {
        [SetUp]
        protected override void setup()
        {
            base.setup();
            _ItemStore = new ItemStore(TestDbContext);
            SetupData();
            ThenItem = null;
        }

        [TearDown]
        protected override void teardown()
        {
            base.teardown();
        }

        [Test]
        public void ShouldAddAndUpdateItem()
        {
            var Item = new Item { Name = "bar", Cost = 6.50M, MenuID = ParentMenu.ID };
            WhenAdd(Item);
            WhenGet(Item.ID);
            ThenItem.Name.Should().Be("bar");
            Item.Name = "other";
            WhenUpdate(Item);
            WhenGet(Item.ID);
            ThenItem.Name.Should().Be("other");
        }

        [Test]
        public void ShouldFindByItemID()
        {
            GivenItemInContext(SomeItem);
            WhenGet(SomeItem.ID);
            ThenItem.Name.Should().Be("foo");
        }

        [Test]
        public void ShouldReturnNullForNotFoundItem()
        {
            GivenItemInContext(SomeItem);
            WhenGet(5);
            ThenItem.Should().BeNull();
        }

        [Test]
        public void ShouldRemoveItem()
        {
            GivenItemInContext(SomeItem);
            WhenRemove(SomeItem.ID);
            WhenGet(SomeItem.ID);
            ThenItem.Should().BeNull();
        }

        [Test]
        public void ShouldGetItemsUnderBudget()
        {
            GivenItemInContext(SomeItem);
            GivenItemInContext(AnotherItem);
            WhenGetWithBudget(7.00M);
            ThenItems.Should().Contain(SomeItem);
            ThenItems.Should().NotContain(AnotherItem);
        }

        private void SetupData()
        {
            TestDbContext.Restaurants.Add(ParentRestaurant);
            SaveAndValidate();
            ParentMenu.RestaurantID = ParentRestaurant.ID;
            TestDbContext.Menus.Add(ParentMenu);
            SaveAndValidate();

            SomeItem = new Item
            {
                MenuID = ParentMenu.ID,
                Name = "foo",
                Cost = 6.50M,
                Category = Category.Entrees
            };

            AnotherItem = new Item
            {
                MenuID = ParentMenu.ID,
                Name = "bar",
                Cost = 8.50M,
                Category = Category.Entrees
            };
        }

        private void GivenItemInContext(Item Item)
        {
            TestDbContext.Items.Add(Item);
            SaveAndValidate();
        }

        private void WhenGetWithBudget(decimal budget)
        {
            ThenItems = _ItemStore.GetUnderPrice(budget);
        }

        private void WhenRemove(int id)
        {
            _ItemStore.Remove(id);
        }

        private void WhenAdd(Item Item)
        {
            _ItemStore.Add(Item);
        }

        private void WhenGet(int id)
        {
            ThenItem = _ItemStore.GetByItemID(id);
        }

        private void WhenUpdate(Item Item)
        {
            _ItemStore.Update(Item);
        }


        private Item ThenItem { get; set; }
        private List<Item> ThenItems { get; set; }
        private IItemStore _ItemStore;
        private Item SomeItem;
        private Item AnotherItem;

        private static readonly Restaurant ParentRestaurant = new Restaurant { Name = "foo" };
        private Menu ParentMenu = new Menu { Name = "bar" };
    }
}
