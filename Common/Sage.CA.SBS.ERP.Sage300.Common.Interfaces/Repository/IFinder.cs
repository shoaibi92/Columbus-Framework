/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Finder;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository
{
    /// <summary>
    /// Interface for Finder
    /// </summary>
    public interface IFinder
    {
        /// <summary>
        /// User Preferences Key
        /// </summary>
        string UserPreferencesKey { get; }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ModelBase.</returns>
        ModelBase Get(string id);

        /// <summary>
        /// Gets the data from service
        /// </summary>
        /// <param name="finderOptions">Finder Options</param>
        /// <returns>ModelBase</returns>
        ModelBase Get(FinderOption finderOptions);

        /// <summary>
        /// Gets the specified finder options.
        /// </summary>
        /// <param name="finderOptions">The finder options.</param>
        /// <param name="totalResultsCount">The total results count.</param>
        /// <returns>IEnumerable&lt;ModelBase&gt;.</returns>
        IEnumerable<ModelBase> Get(FinderOption finderOptions, out int totalResultsCount);

        /// <summary>
        /// Gets the columns.
        /// </summary>
        /// <returns>IEnumerable&lt;ModelBase&gt;.</returns>
        IEnumerable<ModelBase> GetColumns();

        /// <summary>
        /// Gets all the columns.
        /// </summary>
        /// <returns>IEnumerable&lt;ModelBase&gt;.</returns>
        IEnumerable<ModelBase> GetAllColumns();

        /// <summary>
        /// Gets the schema model fields.
        /// </summary>
        /// <returns>IEnumerable&lt;ModelBase&gt;.</returns>
        IEnumerable<ModelBase> GetSchemaModelFields();

        /// <summary>
        /// Save User Preferences
        /// </summary>
        /// <param name="columnPreferences">list of columns </param>
        void SaveUserPreferences(List<GridColumn> columnPreferences);

        /// <summary>
        /// Delete User Preferences
        /// </summary>
        void DeleteUserPreferences();

        /// <summary>
        /// Get all available columns of finder grid for display "Edit Columns" list
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetEditableColumns();

        /// <summary>
        /// Reorder grid preferences
        /// </summary>
        /// <param name="fieldFrom">field which is reordered.</param>
        /// <param name="fieldTo">field is reordered after this field.</param>
        void ReorderUserPreferences(string fieldFrom, string fieldTo);
    }
}