using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Define Page Options
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageOptions<T> where T : ModelBase
    {
        /// <summary>
        /// constructor
        /// </summary>
        public PageOptions()
        {
            ModifiedData = new List<T>();
        }

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        /// <value>
        /// The page number.
        /// </value>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the modified data. (can be inserted updated, deleted).
        /// </summary>
        /// <value>
        /// The modified data.
        /// </value>
        public List<T> ModifiedData { get; set; }

        /// <summary>
        /// Gets or sets the get key.
        /// </summary>
        /// <value>
        /// The get key.
        /// </value>
        public Func<T, string> GetKey { get; set; }

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public Expression<Func<T, Boolean>> Filter { get; set; }

        /// <summary>
        /// Gets or sets the order by.
        /// </summary>
        /// <value>
        /// The order by.
        /// </value>
        public OrderBy OrderBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [latest caching not used].
        /// </summary>
        /// <value>
        /// <c>true</c> if [latest caching not used]; otherwise, <c>false</c>.
        /// </value>
        public bool LatestCachingNotUsed { get; set; }

    }
}
