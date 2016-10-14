using System;
namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    public interface IEnumerableResponse
    {
        int CachedListCount { get; set; }

        System.Collections.Generic.List<EntityError> Errors { get; set; }

        System.Collections.Generic.IEnumerable<object> Items { get; set; }

        int TotalResultsCount { get; set; }
    }
}
