// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

#region Namespaces
#endregion

namespace Sage.CA.SBS.ERP.Sage300.ClassGeneration
{
    /// <summary> BusinessField class to hold properties for a field </summary>
    public class BusinessField
    {
        #region Constructor
        /// <summary> Constructor setting defaults </summary>
        public BusinessField()
        {
            // Set defaults
            Id = 0;
            ServerFieldName = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
            Type = BusinessDataType.Double;
            Size = 0;
            IsReadOnly = false;
            IsCalculated = false;
            IsRequired = false;
            IsKey = false;
            IsUpperCase = false;
            IsAlphaNumeric = false;
            IsNumeric = false;
            IsDynamicEnablement = false;
        }
        #endregion

        #region Public Properties
        /// <summary> Id is the ordinal value for the field </summary>
        public int Id { get; set; }
        /// <summary> ServerFieldName is the field name on the server </summary>
        public string ServerFieldName { get; set; }
        /// <summary> Name is the field name </summary>
        public string Name { get; set; }
        /// <summary> Description of the field </summary>
        public string Description { get; set; }
        /// <summary> Type is the field type </summary>
        public BusinessDataType Type { get; set; }
        /// <summary> Size is number of characters allowed for the field</summary>
        public int Size { get; set; }
        /// <summary> IsReadOnly is true if field is read only otherwise false </summary>
        public bool IsReadOnly { get; set; }
        /// <summary> IsCalculated is true if calculated field otherwise false </summary>
        public bool IsCalculated { get; set; }
        /// <summary> IsRequired is true if field is required otherwise false </summary>
        public bool IsRequired { get; set; }
        /// <summary> IsKey is true if field is a key otherwise false </summary>
        public bool IsKey { get; set; }
        /// <summary> IsUpperCase is true if field requires uppecase otherwise false </summary>
        public bool IsUpperCase { get; set; }
        /// <summary> IsAlphaNumeric is true if field accepts alpha numeric characters otherwise false </summary>
        public bool IsAlphaNumeric { get; set; }
        /// <summary> IsNumeric is true if field accepts numeric characters otherwise false </summary>
        public bool IsNumeric { get; set; }
        /// <summary> IsDynamicEnablement is true if field attribute contains 'X' otherwise false </summary>
        public bool IsDynamicEnablement { get; set; }
        #endregion

    }

}
