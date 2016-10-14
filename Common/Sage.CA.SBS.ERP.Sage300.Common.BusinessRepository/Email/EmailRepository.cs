/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region

using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Email;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Email;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Process;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Resources.Utilities;
using System;
using System.Globalization;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Email
{
    /// <summary>
    /// Class for Email Repository
    /// </summary>
    /// <typeparam name="T">Where type of T is EmailOption</typeparam>
    public abstract class EmailRepository<T> : BaseRepository, IEmailRepository<T> where T : EmailOption, new()
    {

        #region Protected Region

        /// <summary>
        /// Compose business entities
        /// </summary>
        /// <returns>Business Entity Session opened</returns>
        protected abstract IBusinessEntity CreateBusinessEntities();
        #endregion

        #region Constructor

        /// <summary>
        /// EmailRepository Constructor
        /// </summary>
        /// <param name="context">Current business entity context</param>
        protected EmailRepository(Context context)
            : base(context)
        {

        }

        /// <summary>
        /// EmailRepository Constructor Sets Context and Session 
        /// </summary>
        /// <param name="context">Current business entity context</param>
        /// <param name="session">Current business entity Session</param>
        protected EmailRepository(Context context, IBusinessEntitySession session)
            : base(context, session)
        {
        }

        /// <summary>
        /// EmailRepository Constructor
        /// </summary>
        /// <param name="context">Current business entity context</param>
        /// <param name="dbLinkType">DB Link Type System/Company</param>
        protected EmailRepository(Context context, DBLinkType dbLinkType)
            : base(context, dbLinkType)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="EmailRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="dbLinkType">Type of the database link.</param>
        /// <param name="businessEntitySessionParams">The business entity session parameters.</param>
        protected EmailRepository(Context context, DBLinkType dbLinkType, BusinessEntitySessionParams businessEntitySessionParams)
            : base(context, dbLinkType, ObjectPoolType.Default, businessEntitySessionParams)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="EmailRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="businessEntitySessionParams">The business entity session parameters.</param>
        protected EmailRepository(Context context, BusinessEntitySessionParams businessEntitySessionParams)
            : base(context, ObjectPoolType.Default, businessEntitySessionParams)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Send email without using accpac report
        /// </summary>
        /// <param name="model">Object contain email details</param>
        /// <returns> Email sent successfully or failed message</returns>
        public virtual EmailResponse SendEmail(T model)
        {
            // TODO: Send mail without using accpac report
            return new EmailResponse();
        }

        /// <summary>
        /// Send email using accpac report
        /// </summary>
        /// <param name="report">Report Object</param>
        /// <returns>Email sent successfully or failed message</returns>
        public virtual EmailResponse SendEmail(Models.Reports.Report report)
        {
            var response = new EmailResponse();
            if (report != null)
            {
                try
                {
                    var accpacReport = Session.SelectReport(report.Name, report.ProgramId, report.MenuId);

                    foreach (var parameter in report.Parameters)
                    {
                        accpacReport.SetParam(parameter.Id, GetValue(parameter));
                    }
                    accpacReport.Format = PrintFormat.PDF;
                    accpacReport.Destination = PrintDestination.Email;
                    accpacReport.Print();
                    response.Status = ProcessStatus.Completed;
                }
                catch (BusinessException exception)
                {
                    response.Status = ProcessStatus.Error;
                    response.Results = exception.Errors;
                }
            }
            return response;

        }

       
        #endregion

        #region Private methods

        /// <summary>
        /// Get Value based on true
        /// </summary>
        /// <param name="parameter">Report parameter object</param>
        /// <returns>string value</returns>
        private static string GetValue(Parameter parameter)
        {
            if (parameter == null || parameter.Value == null)
            {
                return string.Empty;
            }

            switch (parameter.DataType)
            {
                case DataType.Boolean:
                    return Convert.ToBoolean(parameter.Value) ? OperatorsResx.Yes : OperatorsResx.No;
                case DataType.Date:
                    return DateUtil.GetMonthDayYearDate(parameter.Value, string.Empty);
                default:
                    return parameter.Value.ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <returns></returns>
        public UserAccess GetAccessRights()
        {
            throw new NotImplementedException();
        }

        #endregion

     
    }
}
