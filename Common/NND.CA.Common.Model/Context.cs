using System;
using Microsoft.Practices.Unity;
//using NND.CA.Common.Utilities;


namespace NND.CA.Common.Model
{
    public class Context
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public Context()
        {
            // Default(s)
            //SessionDate = DateUtil.GetNowDate();
        }

        #endregion

        /// <summary>
        /// Product User Id
        /// </summary>
        /// <value>The user identifier.</value>
        public Guid ProductUserId { get; set; }

        /// <summary>
        /// Application User Id
        /// </summary>
        /// <value>The Sage 300 user identifier</value>
        public string ApplicationUserId { get; set; }

        /// <summary>
        /// Tenant Id
        /// </summary>
        /// <value>The tenant identifier.</value>
        public Guid TenantId { get; set; }

        /// <summary>
        /// Tenant Alias
        /// </summary>
        public string TenantAlias { get; set; }

        /// <summary>
        /// Company name
        /// </summary>
        /// <value>The company.</value>
        public string Company { get; set; }

        /// <summary>
        /// Session id
        /// </summary>
        /// <value>The session identifier.</value>
        public string SessionId { get; set; }

        /// <summary>
        /// Context token
        /// </summary>
        /// <value>The context token.</value>
        public Guid ContextToken { get; set; }

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>The container.</value>
        [IgnoreDataMember]
        public IUnityContainer Container { get; set; }

        /// <summary>
        /// Screen context
        /// </summary>
        /// <value>The screen context.</value>
        public ScreenContext ScreenContext { get; set; }

        /// <summary>
        /// Screen name
        /// </summary>
        /// <value>The name of the screen.</value>
        public string ScreenName { get; set; }

        /// <summary>
        /// Application Type - Defines Which application is invoking the components
        /// </summary>
        /// <value>The name of the application.</value>
        public ApplicationType ApplicationType { get; set; }

        /// <summary>
        /// Language of the user
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Session Date
        /// </summary>
        public DateTime SessionDate { get; set; }

        /// <summary>
        /// web site path
        /// </summary>
        public string WebSitePath { get; set; }
    }
}
