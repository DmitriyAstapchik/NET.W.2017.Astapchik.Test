using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Task3.Solution;

namespace Task3.Tests
{
    [TestFixture]
    public class StockTest
    {
        [Test]
        public void MarketTest()
        {
            var infoMock = new Mock<StockInfo>();
            var argsMock = new Mock<NewMarketEventArgs>(infoMock.Object);
            argsMock.SetupGet(args => args.Info).Returns(infoMock.Object);
            var stockMock = new Mock<Stock>();
            var bank = new Bank("bank", stockMock.Object);
            var broker = new Broker("broker", stockMock.Object);
            stockMock.Raise(st => st.NewMarket += null, argsMock.Object);
            argsMock.VerifyGet(e => e.Info);
            infoMock.VerifyGet(inf => inf.Euro);
            infoMock.VerifyGet(inf => inf.USD);
            argsMock.ResetCalls();
            infoMock.ResetCalls();
            broker.StopTrade();
            stockMock.Raise(st => st.NewMarket += null, argsMock.Object);
            argsMock.VerifyGet(e => e.Info);
            infoMock.VerifyGet(inf => inf.Euro);
        }
    }
}
