/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using ACCPAC.Advantage;
using System;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Entity
{
    /// <summary>
    /// Class that implements 
    /// </summary>
    public class PseudoViewField : IViewFieldComInterop
    {
        //TODO : this property will be used later

        // ReSharper disable once NotAccessedField.Local
        private readonly string _name;

        /// <summary>
        /// Value
        /// </summary>
        private string _value;

        /// <summary>
        /// PseudoViewField constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public PseudoViewField(string name, string value)
        {
            _name = name;
            _value = value;
        }

        /// <summary>
        /// Gets Attributes
        /// </summary>
        public ViewFieldAttributes Attributes
        {
            get {
                return ViewFieldAttributes.Editable;
            }
        }

        /// <summary>
        /// Gets Description
        /// </summary>
        public string Description
        {
            get {
                return Name;
            }
        }

        /// <summary>
        /// Gets ID
        /// </summary>
        public int ID
        {
            get { 
                return 0;
            }
        }

        /// <summary>
        /// Gets and sets Index
        /// </summary>
        public int Index
        {
            get;
            set;
        }

        /// <summary>
        /// MaxValue
        /// </summary>
        public object MaxValue
        {
            get {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// MinValue
        /// </summary>
        public object MinValue
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets and sets Name
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Precision
        /// </summary>
        public short Precision
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// PresentationList
        /// </summary>
        public ViewFieldPresentationList PresentationList
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets PresentationMask
        /// </summary>
        public string PresentationMask
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// Gets PresentationType
        /// </summary>
        public ViewFieldPresentationType PresentationType
        {
            get { return ViewFieldPresentationType.None; }
        }

        /// <summary>
        /// Method to SetToMax
        /// </summary>
        public void SetToMax()
        {

        }

        /// <summary>
        /// Method to SetToMin
        /// </summary>
        public void SetToMin()
        {

        }

        /// <summary>
        /// Method to SetValue
        /// </summary>
        /// <param name="newValue"></param>
        /// <param name="verify"></param>
        public void SetValue(object newValue, bool verify)
        {
            _value = newValue.ToString();
        }

        /// <summary>
        /// Gets Size
        /// </summary>
        public short Size
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets Type
        /// </summary>
        public ViewFieldType Type
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets Value
        /// </summary>
        public object Value
        {
            get { return _value; }
        }
    }
}
