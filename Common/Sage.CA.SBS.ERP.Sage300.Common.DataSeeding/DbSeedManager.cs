/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System.Collections.Generic;
using System.Linq;
using Sage.CA.SBS.ERP.Sage300.Common.DataSeeding.Interfaces;
using Sage.CA.SBS.ERP.Sage300.Common.DataSeeding.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.GL.Interfaces.Services;
using Sage.CA.SBS.ERP.Sage300.GL.Models;

namespace Sage.CA.SBS.ERP.Sage300.Common.DataSeeding
{
    /// <summary>
    /// Performs database seeding tasks
    /// </summary>
    public class DbSeedManager
    {
        #region Private members
        /// <summary>
        /// Account Segment Service reference
        /// </summary>
        private readonly IAccountSegmentService<AccountSegments> _accountSegmentService;

        /// <summary>
        /// Options Service reference
        /// </summary>
        private readonly IOptionsService<Options> _optionsService;

        /// <summary>
        /// List of seeder objects
        /// </summary>
        private readonly List<IEntityDataSeeder> _seeders = new List<IEntityDataSeeder>();
        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accountSegmentService">AccountSegmentService reference</param>
        /// <param name="optionsService">OptionsService reference</param>
        public DbSeedManager(IAccountSegmentService<AccountSegments> accountSegmentService, IOptionsService<Options> optionsService)
        {
            _accountSegmentService = accountSegmentService;
            _optionsService = optionsService;
        }

        #endregion

        /// <summary>
        /// Registers a seeder object
        /// </summary>
        /// <param name="seeder">Seeder object</param>
        public void RegisterSeeder(IEntityDataSeeder seeder)
        {
            _seeders.Add(seeder);
        }

        /// <summary>
        /// Performs data seeding on the database
        /// </summary>
        /// <param name="currencyCode">Currency Code</param>
        /// <returns></returns>
        public DbSeedResult SeedAll(string currencyCode)
        {
            var defAcctSegment = new AccountSegments
            {
                SerialNumber = 1, //Internal identifier of the Account Segment
                SegmentNumber = CommonUtil.Pad("1", 6, true), //Formatted Segment Number
                SegmentLength = 4, //Length of the Account Segment. 4 is the most common value.
                SegmentDescription = DataSeedingResx.DefaultAccountDescription, // Account Segment description
                SegmentType = GL.Models.Enums.SegmentType.AccountNumber //Identifies Account Number segment
            };

            //Add the default Segment
            _accountSegmentService.Add(defAcctSegment);

            //Update Main Account segemnt ID
            var options = _optionsService.Get().Items.FirstOrDefault();
            if (options != null)
            {
                options.MainAcctSegmentId = defAcctSegment.SegmentNumber;
                _optionsService.Save(options);
            }

            //Perform database seeding
            return new DbSeedResult(_seeders.Select(seeder => seeder.Seed(currencyCode)).ToList());
        }
    }
}
