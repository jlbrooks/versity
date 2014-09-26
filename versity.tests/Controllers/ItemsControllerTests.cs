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
    public class ItemControllerTests
    {
        [SetUp]
        public void setup()
        {
            _ItemStore = Substitute.For<IItemStore>();
            _controller = new ItemsController(_ItemStore);
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
            givenItem(_someItem);
            whenGetEdit(-1);
            _thenResult.Should().BeOfType<ViewResult>();
        }

        [Test]
        public void ShouldPassItemToEditToView()
        {
            givenItem(_someItem);
            whenGetEdit(-1);
            _thenResult.As<ViewResult>().ViewData.Model.Should().Equals(_someItem);
        }

        [Test]
        public void DeleteShouldRedirect()
        {
            givenItem(_someItem);
            whenPostDelete(-1);
            _thenResult.Should().BeOfType<RedirectToRouteResult>();
        }

        [Test]
        public void DetailsShouldReturnView()
        {
            givenItem(_someItem);
            whenGetEdit(-1);
            _thenResult.Should().BeOfType<ViewResult>();
            _thenResult.As<ViewResult>().ViewData.Model.Should().Equals(_someItem);
        }

        [Test]
        public void BudgetShouldReturnJSON()
        {
            givenItems(_someData);
            whenGetBudget(5.0M);
            _thenResult.Should().BeOfType<JsonResult>();
        }

        private void givenItems(List<Item> items)
        {
            _ItemStore.GetUnderPrice(5.0M).ReturnsForAnyArgs(items);
        }

        private void givenItem(Item Item)
        {
            _ItemStore.GetByItemID(Item.ID).Returns(Item);
        }

        private void whenGetBudget(decimal b)
        {
            _thenResult = _controller.SearchBudget(b);
        }

        private void whenGetEdit(int id)
        {
            _thenResult = _controller.Edit(id);
        }

        private void whenPostDelete(int id)
        {
            _thenResult = _controller.DeleteConfirmed(id);
        }

        private void whenGetNew()
        {
            _thenResult = _controller.Create(_someMenu.ID);
        }

        private void whenGetDetails(int id)
        {
            _thenResult = _controller.Details(id);
        }

        private static readonly Menu _someMenu = new Menu { ID = 1, Name = "menu", Active = true };
        private static readonly Item _someItem = new Item { ID = -1, Name = "Item", Cost = 6.50M, MenuID = 1, Menu = _someMenu };
        private static readonly List<Item> _someData = new List<Item> { _someItem };

        private ItemsController _controller;
        private ActionResult _thenResult;
        private IItemStore _ItemStore;
    }
}