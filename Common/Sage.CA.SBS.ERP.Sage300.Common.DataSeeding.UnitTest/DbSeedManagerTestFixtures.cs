using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.GL.Interfaces.Services;
using Sage.CA.SBS.ERP.Sage300.GL.Models;
using Sage.CA.SBS.ERP.Sage300.GL.Models.Enums;

namespace Sage.CA.SBS.ERP.Sage300.Common.DataSeeding.UnitTest
{
    [TestClass]
    public class DbSeedManagerTestFixtures
    {
        [TestMethod]
        public void SeedAll_AddsCorrectDefaultAccountSegment_And_UpdatesMainAcctSegmentId()
        {
            //Arrange
            AccountSegments accountSegmentBeingAdded = null;
            var accountSegmentsService = new Mock<IAccountSegmentService<AccountSegments>>();
            accountSegmentsService.Setup(x => x.Add(It.IsAny<AccountSegments>()))
                .Callback<AccountSegments>(a => accountSegmentBeingAdded = a)
                .Returns(It.IsAny<AccountSegments>);

            Options optionsBeingSaved = null;
            var optionsService = new Mock<IOptionsService<Options>>();
            optionsService
                .Setup(x => x.Get(It.IsAny<Expression<Func<Options, bool>>>(), It.IsAny<OrderBy>()))
                .Returns(new EnumerableResponse<Options>{Items = new List<Options>{new Options()}});
            optionsService.Setup(x => x.Save(It.IsAny<Options>()))
                .Callback<Options>(o => optionsBeingSaved = o)
                .Returns(It.IsAny<Options>);
            var seedManager = new DbSeedManager(accountSegmentsService.Object, optionsService.Object);

            //Act
            seedManager.SeedAll("CAD");

            //Assert
            //Verify the Account Segment has been added and it is correct
            accountSegmentsService.Verify(c => c.Add(It.IsAny<AccountSegments>()), Times.Once());
            Assert.IsTrue(accountSegmentBeingAdded.SerialNumber == 1);
            Assert.IsTrue(accountSegmentBeingAdded.SegmentNumber == "000001");
            Assert.IsTrue(accountSegmentBeingAdded.SegmentLength == 4);
            Assert.IsTrue(accountSegmentBeingAdded.SegmentDescription == DataSeedingResx.DefaultAccountDescription);
            Assert.IsTrue(accountSegmentBeingAdded.SegmentType == SegmentType.AccountNumber);
            //Verify Main Account ID in GL Options has been updated with correct value
            Assert.IsTrue(optionsBeingSaved.MainAcctSegmentId == accountSegmentBeingAdded.SegmentNumber);
        }
    }
}
