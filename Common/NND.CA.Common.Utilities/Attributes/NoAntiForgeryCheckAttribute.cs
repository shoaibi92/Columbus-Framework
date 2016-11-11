using System;

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Attributes
{
    /// <summary>
    /// Class to By-passing AntiForgeryValidation for some actions
    /// </summary>
    public class NoAntiForgeryCheckAttribute : Attribute
    {
         //For some POST actions we may don't need the anti-forgery check and with the current implementation we can't achieve
         //that. To satisfy this, all we have to do is create a simple attribute and decorate the actions that doesn't need
         //security check with that. 
    }

}
