
using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// This enum is used in AP Invoice Entry. 
    /// This is created for display of Tax Reporting Type.
    /// </summary>
    public enum InvoiceTaxReportingType
    {

        /// <summary>
        /// Gets or sets None 
        /// </summary>	
        [EnumValue("None", typeof (InvoiceResx))] 
        None = 0,

        /// <summary>
        /// Gets or sets Num1099 
        /// </summary>	
        [EnumValue("Num1099", typeof (InvoiceResx))] 
        Num1099 = 1,

        /// <summary>
        /// Gets or sets CPRS 
        /// </summary>	
        [EnumValue("CPRS", typeof (InvoiceResx))] 
        CPRS = 2
    }
}

