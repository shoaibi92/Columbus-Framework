 
namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
	/// <summary>
    /// Enum for ProcessCommand 
    /// </summary>
	public enum ProcessCommand
	{
			/// <summary>
		/// Gets or sets Clear 
		/// </summary>	
        Clear = 0,
		/// <summary>
		/// Gets or sets Allocate 
		/// </summary>	
        Allocate = 1,
		/// <summary>
		/// Gets or sets ApplyInvoiceDocument 
		/// </summary>	
        ApplyInvoiceDocument = 10,
		/// <summary>
		/// Gets or sets WarnInvoiceDocument 
		/// </summary>	
        WarnInvoiceDocument = 11,
		/// <summary>
		/// Gets or sets ApplyWarnInvoiceDocument 
		/// </summary>	
        ApplyWarnInvoiceDocument = 12,
		/// <summary>
		/// Gets or sets ApplyMatchingDocument 
		/// </summary>	
        ApplyMatchingDocument = 13,
		/// <summary>
		/// Gets or sets WarnMatchingDocument 
		/// </summary>	
        WarnMatchingDocument = 14,
		/// <summary>
		/// Gets or sets ApplyWarnMatchingDocument 
		/// </summary>	
        ApplyWarnMatchingDocument = 15,
	}
}
