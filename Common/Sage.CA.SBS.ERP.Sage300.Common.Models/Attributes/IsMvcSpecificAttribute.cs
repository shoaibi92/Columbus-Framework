using System;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes
{
    /// <summary>
    /// When applied to the member of a type, specifies that the member is MVC-specific
    /// and thus should not be exposed as part of the Web API.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class IsMvcSpecificAttribute : Attribute
    {
    }
}