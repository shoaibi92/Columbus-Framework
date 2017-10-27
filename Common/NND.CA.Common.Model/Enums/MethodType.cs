using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NND.CA.Common.Model.Enums
{
    /// <summary>
    /// Security types
    /// </summary>
    [Flags]
    public enum MethodType
    {
        /// <summary>
        /// None
        /// </summary>
        //[EnumValue("SecurityType_None", typeof(EnumerationsResx))]
        Home = 1,

        /// <summary>
        /// Add
        /// </summary>
        //[EnumValue("SecurityType_Add", typeof(EnumerationsResx))]
        Index = 2,

        /// <summary>
        /// Delete
        /// </summary>
        //[EnumValue("SecurityType_Delete", typeof(EnumerationsResx))]
        Dashbord = 4,

        /// <summary>
        /// Inquire
        /// </summary>
        //[EnumValue("SecurityType_Inquire", typeof(EnumerationsResx))]
        Login = 8,

        /// <summary>
        /// Modify
        /// </summary>
        //[EnumValue("SecurityType_Modify", typeof(EnumerationsResx))]
        Modify = 16,

        /// <summary>
        /// Post
        /// </summary>
        //[EnumValue("SecurityType_Post", typeof(EnumerationsResx))]
        Post = 32,

        /// <summary>
        /// Report Print
        /// </summary>
        Print = 64,

        /// <summary>
        /// Access to Export menu
        /// </summary>
        Export = 128,

        /// <summary>
        /// Access to Import menu
        /// </summary>
        Import = 256,

        /// <summary>
        /// Ready To Post
        /// </summary>
        ReadyToPost = 512,

        /// <summary>
        /// Security Check for Edit Credit Limit
        /// </summary>
        ARCredit = 1024,

        /// <summary>
        /// Security check for Printing Check
        /// </summary>
        APPrintCheck = 2048,

        /// <summary>
        /// Security Check for Credit Card
        /// </summary>
        CreditSecurity = 4096,

        /// <summary>
        /// Security Check for OE Credit
        /// </summary>
        OECredit = 8192,

        /// <summary>
        /// Security Check for OE Credit Debit Note Entry Rights
        /// </summary>
        OECrdDbtSalesHistory = 16384,

        /// <summary>
        /// Security Check for OE Transaction Optional Field Rights
        /// </summary>
        OETransOptField = 32768,

        /// <summary>
        /// Security Check for OE Credit Debit Note Print
        /// </summary>
        OECreditDebitNotePrint = 65536,

        /// <summary>
        /// Security Check for OE Credit Debit Note Cost
        /// </summary>
        OECreditDebitNoteCost = 131072,

        /// <summary>
        /// Security Check for OE Credit Debit Note Price Check Approval
        /// </summary>
        OECreditDebitNotePriceCheckApproval = 262144,

        /// <summary>
        /// Security Check for OE Credit Debit Note Price editability
        /// </summary>
        OECreditDebitNotePriceEditability = 524288,

        /// <summary>
        /// Security check for Admin User
        /// </summary>
        Admin = 1048576,
    }
}
