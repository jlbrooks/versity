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
    public class MenuStoreTests : DatabaseTest
    {
        [SetUp]
        protected override void setup()
        {
            base.setup();
            _MenuStore = new MenuStore(TestDbContext);
            ThenMenu = null;
        }

        [Test]
        public void ShouldAddAndUpdateMenu()
        {
            var Menu = new Menu { Name = "bar", ID = 2, RestaurantID = 1 };
            WhenAdd(Menu);
            WhenGet(Menu.ID);
            ThenMenu.Name.Should().Be("bar");
            Menu.Name = "other";
            WhenUpdate(Menu);
            WhenGet(Menu.ID);
            ThenMenu.Name.Should().Be("other");
        }

        [Test]
        public void ShouldFindByMenuID()
        {
            GivenMenuInContext(SomeMenu);
            WhenGet(SomeMenu.ID);
            ThenMenu.Name.Should().Be("foo");
        }

        [Test]
        public void ShouldReturnNullForNotFoundMenu()
        {
            GivenMenuInContext(SomeMenu);
            WhenGet(5);
            ThenMenu.Should().BeNull();
        }

        [Test]
        public void ShouldRemoveMenu()
        {
            GivenMenuInContext(SomeMenu);
            WhenRemove(SomeMenu.ID);
            WhenGet(SomeMenu.ID);
            ThenMenu.Should().BeNull();
        }

        private void GivenMenuInContext(Menu Menu)
        {
            TestDbContext.Menus.Add(Menu);
            SaveAndValidate();
        }

        private void WhenRemove(int id)
        {
            _MenuStore.Remove(id);
        }

        private void WhenAdd(Menu Menu)
        {
            _MenuStore.Add(Menu);
        }

        private void WhenGet(int id)
        {
            ThenMenu = _MenuStore.GetByMenuID(id);
        }

        private void WhenUpdate(Menu Menu)
        {
            _MenuStore.Update(Menu);
        }


        private Menu ThenMenu { get; set; }
        private IMenuStore _MenuStore;
        private static readonly Menu SomeMenu = new Menu
        {
            ID = 1,
            Name = "foo",
            Active = true,
            RestaurantID = 1
        };
    }
}
