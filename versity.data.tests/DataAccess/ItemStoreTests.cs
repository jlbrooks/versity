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
            ThenItem = null;
        }

        [Test]
        public void ShouldAddAndUpdateItem()
        {
            var Item = new Item { Name = "bar", Cost = 6.50M, ID = 2, MenuID = 1 };
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

        private void GivenItemInContext(Item Item)
        {
            TestDbContext.Items.Add(Item);
            SaveAndValidate();
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
        private IItemStore _ItemStore;
        private static readonly Item SomeItem = new Item
        {
            ID = 6,
            MenuID = 1,
            Name = "foo",
            Cost = 6.50M,
            Category = Category.Entrees
        };
    }
}
