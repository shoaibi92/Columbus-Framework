using System.Web.UI.WebControls;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System.Web.Mvc;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Utilities
{
    /// <summary>
    /// Footer type enum
    /// </summary>
    public enum FooterType
    {
        /// <summary>
        /// None
        /// </summary>
        None,
        /// <summary>
        /// With some empty space
        /// </summary>
        Space,
        /// <summary>
        /// Using a line
        /// </summary>
        LineSeparator
    }

    /// <summary>
    /// Static class to provide utilies to return partial view parameters
    /// </summary>
    public static class ViewParameters
    {
        #region Report
        /// <summary>
        /// Return partial view parameter for BatchListing
        /// </summary>
        public static ViewDataDictionary BatchListingViewParameter
        {
            get
            {
                return new ViewDataDictionary { {ViewItemSemantic.FooterType, FooterType.None} }
                    .AddButtonParameters(ViewItemSemantic.OptionalButtonProperties.Instance, isRequired:true, @value:CommonResx.Back, koParameter:new { @disable = "BackDisable", @visible = "BackVisible" });

                
            }
        }
        #endregion

        #region Setup
        /// <summary>
        /// Return partial view paramter for OptinalFields
        /// </summary>
        public static ViewDataDictionary OptionalFieldsViewParameter
        {
            get
            {
                return new ViewDataDictionary { {ViewItemSemantic.FooterType, FooterType.LineSeparator} }
                    .AddButtonParameters(ViewItemSemantic.SaveButtonProperties.Instance, koParameter: new {@value = "IsAddOrSaveBtnValue"})
                    .AddButtonParameters(ViewItemSemantic.DeleteButtonProperties.Instance, koParameter: new {@value = "IsDeleteBtnValue", @disable = "IsDeleteBtnDisable"}, @class:string.Format("{0} {1}", ViewItemSemantic.ButtonClassPrimary, ViewItemSemantic.ButtonClassRight));
            }
        }

        /// <summary>
        /// Return partial view parameter for Options
        /// </summary>
        public static ViewDataDictionary OptionsViewParameter
        {
            get
            {
                return new ViewDataDictionary()
                    .AddButtonParameters(ViewItemSemantic.DeleteButtonProperties.Instance, isRequired:false)
                    .AddButtonParameters(ViewItemSemantic.SaveButtonProperties.Instance, @class:string.Format(("{0} {1}"), ViewItemSemantic.ButtonClassPrimary, ViewItemSemantic.ButtonClassRight));
            }
        }

        /// <summary>
        /// Return partial view parameter for AccountGroups
        /// </summary>
        public static ViewDataDictionary AccountGroupsViewParameter
        {
            get
            {
                return new ViewDataDictionary()
                    .AddButtonParameters(ViewItemSemantic.SaveButtonProperties.Instance, name:"Save")
                    .AddButtonParameters(ViewItemSemantic.DeleteButtonProperties.Instance, name:"Delete", koParameter:new { @value = "Data.IsDeleteBtnValue" })
                    .AddButtonParameters(ViewItemSemantic.OptionalButtonProperties.Instance, isRequired:true, name:"ChangeSortCodes", @class:ViewItemSemantic.ButtonClassSecondary);
            }
        }

        /// <summary>
        /// Return partial view paramter for SegmentCodes
        /// </summary>
        public static ViewDataDictionary SegmentCodesViewParameter
        {
            get
            {
                return new ViewDataDictionary().AddButtonParameters(ViewItemSemantic.DeleteButtonProperties.Instance, isRequired:false);
            }
        }

        /// <summary>
        /// Return partial view parameter for AccountStructures
        /// </summary>
        public static ViewDataDictionary AccountStructuresViewParameter
        {
            get
            {
                return new ViewDataDictionary()
                    .AddButtonParameters(ViewItemSemantic.SaveButtonProperties.Instance, koParameter:new { @value = "IsAddOrSaveBtnValue" })
                    .AddButtonParameters(ViewItemSemantic.DeleteButtonProperties.Instance, koParameter:new { @value = "IsDeleteBtnValue" });
            }
        }

        /// <summary>
        /// Return partial view parameter for RecurringEntries
        /// </summary>
        public static ViewDataDictionary RecurringEntriesViewParameter
        {
            get
            {
                return new ViewDataDictionary()
                    .AddButtonParameters(ViewItemSemantic.OptionalButtonProperties.Instance, isRequired:true, @value:CommonResx.Clear, @class:string.Format(("{0} {1}"), ViewItemSemantic.ButtonClassSecondary, ViewItemSemantic.ButtonClassRight))
                    .AddButtonParameters(ViewItemSemantic.SaveButtonProperties.Instance, @class:string.Format(("{0} {1}"), ViewItemSemantic.ButtonClassPrimary, ViewItemSemantic.ButtonClassRight))
                    .AddButtonParameters(ViewItemSemantic.DeleteButtonProperties.Instance, @class:string.Format(("{0} {1}"), ViewItemSemantic.ButtonClassPrimary, ViewItemSemantic.ButtonClassRight));
            }
        }

        #endregion

        #region Processing
        /// <summary>
        /// Return partial view parameter for CreateNewYear
        /// </summary>
        public static ViewDataDictionary CreateNewYearViewParameter
        {
            get
            {
                return new ViewDataDictionary{{ ViewItemSemantic.FooterType, FooterType.Space}}
                    .AddButtonParameters(ViewItemSemantic.ProceedButtonProperties.Instance, @class:string.Format("{0} {1}", ViewItemSemantic.ButtonClassPrimary, ViewItemSemantic.ButtonClassRight));
            }
        }

        /// <summary>
        /// Return partial view parameter for PeriodEndMaintenance
        /// </summary>
        public static ViewDataDictionary PeriodEndMaintenanceViewParameter
        {
            get
            {
                return new ViewDataDictionary { { ViewItemSemantic.FooterType, FooterType.Space } }
                    .AddButtonParameters(ViewItemSemantic.ProceedButtonProperties.Instance, @class:string.Format("{0} {1}", ViewItemSemantic.ButtonClassPrimary, ViewItemSemantic.ButtonClassRight), koParameter:new { @disable = "showProcessButton" });
            }
        }

        /// <summary>
        /// Return partial view parameter for CreateRecurringEntries
        /// </summary>
        public static ViewDataDictionary CreateRecurringEntriesViewParameter
        {
            get
            {
                return new ViewDataDictionary
                {
                    { ViewItemSemantic.FooterType, FooterType.LineSeparator}
                };
            }
        } 
        #endregion

        #region Grid action buttons

        /// <summary>
        /// Return partial view parameter for Recurring Entry grid buttons
        /// </summary>
        public static ViewDataDictionary RecurringEntryGridButtonParameter
        {
            get
            {
                return new ViewDataDictionary
                {
                    {ViewItemSemantic.AddLineButtonProperties.Instance.KoParameter, new {@disable = "Data.IAddLineDisable"}}
                };
            }
        }

        /// <summary>
        /// Return partial view parameter for Journal Detail grid buttons
        /// </summary>
        public static ViewDataDictionary JournalDetailGridButtonParameter
        {
            get
            {
                return new ViewDataDictionary()
                    .AddButtonParameters(ViewItemSemantic.AddLineButtonProperties.Instance, koParameter:new { @disable = "Data.IsAddDetailBtnDisabled" }, isDiable:true)
                    .AddButtonParameters(ViewItemSemantic.DeleteLineButtonProperties.Instance, koParameter:new { @disable = "Data.IsDeleteDetailBtnDisabled" }, isDiable:true);
            }
        }

        /// <summary>
        /// Return partial view parameter for Chart of account grid buttons
        /// </summary>
        public static ViewDataDictionary ChartOfAccountGridButtonParameter
        {
            get
            {
                return new ViewDataDictionary()
                    .AddButtonParameters(ViewItemSemantic.AddLineButtonProperties.Instance, koParameter: new { @disable = "Data.IsOptionFieldAddLineDisable" })
                    .AddButtonParameters(ViewItemSemantic.DeleteLineButtonProperties.Instance, koParameter: new { @disable = "Data.IsOptionFieldDeleteLineDisable" });
            }
        }

        /// <summary>
        /// Return partial view parameter for Trial Balance grid buttons
        /// </summary>
        public static ViewDataDictionary TrailBalanceGridButtonParameter
        {
            get
            {
                return new ViewDataDictionary()
                    .AddButtonParameters(ViewItemSemantic.AddLineButtonProperties.Instance, koParameter: new { @disable = "Data.IsOptionFieldAddLineDisable" })
                    .AddButtonParameters(ViewItemSemantic.DeleteLineButtonProperties.Instance, koParameter: new { @disable = "Data.IsOptionFieldDeleteLineDisable" });
            }
        }

        /// <summary>
        /// Return partial view parameter for Transaction Listing grid buttons
        /// </summary>
        public static ViewDataDictionary TransactionListingGridButtonParameter
        {
            get
            {
                return new ViewDataDictionary()
                    .AddButtonParameters(ViewItemSemantic.AddLineButtonProperties.Instance, koParameter: new { @disable = "Data.IsOptionFieldAddLineDisable" })
                    .AddButtonParameters(ViewItemSemantic.DeleteLineButtonProperties.Instance, koParameter: new { @disable = "Data.IsOptionFieldDeleteLineDisable" });
            }
        }

        /// <summary>
        /// Return partial view parameter for Transaction Details Optional Field grid buttons
        /// </summary>
        public static ViewDataDictionary TransactionDetailsOptionalFieldGridButtonParameter
        {
            get
            {
                return new ViewDataDictionary()
                    .AddButtonParameters(ViewItemSemantic.AddLineButtonProperties.Instance, name:"btnTransOptionCreateNew", id:"btnTransOptionCreateNew", koParameter:new {@disable = "Data.IsTransOptionFieldAddLineDisable"})
                    .AddButtonParameters(ViewItemSemantic.DeleteLineButtonProperties.Instance, name:"btnDeleteTransLine", id:"btnDeleteTransLine", koParameter:new {@disable = "Data.IsTransOptionFieldDeleteLineDisable"});
            }
        }

        /// <summary>
        /// Return partial view parameter for Transaction Details Optional Account Field grid buttons
        /// </summary>
        public static ViewDataDictionary TransactionDetailsOptionalAccountFieldGridButtonParameter
        {
            get
            {
                return new ViewDataDictionary()
                    .AddButtonParameters(ViewItemSemantic.AddLineButtonProperties.Instance, name: "btnOptionCreateNew", id: "btnOptionCreateNew", koParameter: new { @disable = "Data.IsOptionFieldAddLineDisable" })
                    .AddButtonParameters(ViewItemSemantic.DeleteLineButtonProperties.Instance, name: "btnDeleteOptinalFieldLine", id: "btnDeleteOptinalFieldLine", koParameter: new { @disable = "Data.IsOptionFieldDeleteLineDisable" });
            }
        }

        #endregion

        #region extension functions

        /// <summary>
        /// Extension Methods for ViewDataDictionary to help add generic button parameters
        /// </summary>
        /// <param name="theDictionary"></param>
        /// <param name="identifier"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="koParameter"></param>
        /// <param name="class"></param>
        /// <param name="isRequired"></param>
        /// <param name="isDiable"></param>
        /// <param name="securityType"></param>
        /// <param name="jsName"></param>
        /// <returns></returns>
        public static ViewDataDictionary AddGenericButtonParameters(this ViewDataDictionary theDictionary,
            string identifier = "", string id = null, string name = null, string @value = null,
            object koParameter = null, string @class = null, bool? isRequired = null, bool? isDiable = null,
            SecurityType? securityType = null, string jsName = null)
        {
            return theDictionary.AddButtonParameters(ViewItemSemantic.GenericButtonProperties.Instance, identifier,
                id, name, @value, koParameter, @class, isRequired, isDiable, securityType, jsName);
        }

        /// <summary>
        /// Extension Methods for ViewDataDictionary to help add button parameters
        /// </summary>
        /// <param name="theDictionary"></param>
        /// <param name="bProperties"></param>
        /// <param name="identifier"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="koParameter"></param>
        /// <param name="class"></param>
        /// <param name="isRequired"></param>
        /// <param name="isDiable"></param>
        /// <param name="securityType"></param>
        /// <param name="jsName"></param>
        /// <returns></returns>
        public static ViewDataDictionary AddButtonParameters(this ViewDataDictionary theDictionary, IButtonProperties bProperties, 
            string identifier = "", string id = null, string name = null, string @value = null, object koParameter = null, string @class = null,
            bool? isRequired = null, bool? isDiable = null, SecurityType? securityType = null, string jsName = null)
        {
            if (!string.IsNullOrEmpty(id)) {theDictionary.Add(bProperties.Id + identifier, id);}
            if (!string.IsNullOrEmpty(name)) {theDictionary.Add(bProperties.Name + identifier, name);}
            if (!string.IsNullOrEmpty(@value)) {theDictionary.Add(bProperties.Value + identifier, @value);}
            if (koParameter != null) {theDictionary.Add(bProperties.KoParameter + identifier, koParameter);}
            if (!string.IsNullOrEmpty(@class)) {theDictionary.Add(bProperties.Class + identifier, @class);}
            if (isRequired.HasValue) {theDictionary.Add(bProperties.IsRequired + identifier, isRequired.Value);}
            if (isDiable.HasValue) {theDictionary.Add(bProperties.Disabled + identifier, isDiable.Value);}
            if (securityType.HasValue) {theDictionary.Add(bProperties.SecurityLevel + identifier, securityType.Value);}
            if (!string.IsNullOrEmpty(jsName)) {theDictionary.Add(bProperties.JsName + identifier, jsName);}

            return theDictionary;
        }
        #endregion
    }
}
