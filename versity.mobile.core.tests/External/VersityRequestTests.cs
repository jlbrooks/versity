using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using versity.mobile.core.External;
using versity.data.Models;

namespace versity.mobile.core.tests.External
{
    [TestFixture]
    public class VersityRequestTests
    {
        [SetUp]
        public void setup()
        {

        }

        [Test]
        public void ShouldReturnJSON()
        {
            var req = new VersityRequest();
            var result = req.GetItems(6.0M);
        }
    }
}
