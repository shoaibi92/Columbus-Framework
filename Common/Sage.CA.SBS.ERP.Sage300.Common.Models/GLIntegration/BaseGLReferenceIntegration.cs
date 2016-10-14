// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. 

#region

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.GLIntegration;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.GLIntegration
{
    /// <summary>
    /// Class for Base G/L Reference Integration
    /// </summary>
    public partial class BaseGLReferenceIntegration : ModelBase
    {
        /// <summary>
        /// constructor for Base G/L Reference Integration
        /// </summary>
        public BaseGLReferenceIntegration()
        {
            SegmentList = new List<Dictionary<string, object>>();
            GLTransactionFields = new List<Dictionary<string, object>>();
            SelectedSegment = new List<Dictionary<string, object>>();
        }
        
        /// <summary>
        /// constructor for Base G/L Reference Integration with default values
        /// </summary>
        /// <param name="transactionFields">G/L Transaction Fields List</param>
        /// <param name="defaultTransactionField">G/L Transaction Field</param>
        public BaseGLReferenceIntegration(List<Dictionary<string, object>> transactionFields, GLTransactionField defaultTransactionField)
        {
            SegmentList = new List<Dictionary<string, object>>();
            GLTransactionFields = transactionFields;
            SelectedSegment = new List<Dictionary<string, object>>();
            GLTransactionField = defaultTransactionField;
        }

        /// <summary>
        /// Gets or sets GL Transaction Field 
        /// </summary>
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Key]
        [Display(Name = "GLTransactionField", ResourceType = typeof(GLIntegrationResx))]
        public GLTransactionField GLTransactionField { get; set; }
        /// <summary>
        /// Gets or sets Separator 
        /// </summary>
        [Display(Name = "SegmentSeparator", ResourceType = typeof(GLIntegrationResx))]
        public Separator Separator { get; set; }
        /// <summary>
        /// Gets or sets Example 
        /// </summary>
        [StringLength(250, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Example", ResourceType = typeof(GLIntegrationResx))]
        public string Example { get; set; }

        #region overridable UI properties
        //The following properties don't have display attribute as it is not mapped to UI controls directly
        /// <summary>
        /// Gets or sets Source Transaction Type Value
        /// </summary>
        public virtual int SourceTransactionTypeValue { get; set; }

        /// <summary>
        /// Gets or sets Included Segment 1 Value 
        /// </summary>
        public virtual int IncludedSegment1Value { get; set; }

        /// <summary>
        /// Gets or sets Included Segment 2 Value 
        /// </summary>
        public virtual int IncludedSegment2Value { get; set; }

        /// <summary>
        /// Gets or sets Included Segment 3 Value 
        /// </summary>
        public virtual int IncludedSegment3Value { get; set; }

        /// <summary>
        /// Gets or sets Included Segment 4 Value 
        /// </summary>
        public virtual int IncludedSegment4Value { get; set; }

        /// <summary>
        /// Gets or sets Included Segment 5 Value 
        /// </summary>
        public virtual int IncludedSegment5Value { get; set; }

        /// <summary>
        /// Gets or sets selected active segment
        /// </summary>
        public List<Dictionary<string, object>> SelectedSegment { get; set; }

        /// <summary>
        /// Gets or sets Segment List
        /// </summary>
        /// <remarks>G/L Transaction Segment's presentation list</remarks>
        public List<Dictionary<string, object>> SegmentList { get; set; }

        /// <summary>
        /// Gets or sets G/L Transaction Fields
        /// </summary>
        /// <remarks>G/L Transaction field's presentation list</remarks>
        public List<Dictionary<string, object>> GLTransactionFields { get; set; }

        #endregion

    }
}
