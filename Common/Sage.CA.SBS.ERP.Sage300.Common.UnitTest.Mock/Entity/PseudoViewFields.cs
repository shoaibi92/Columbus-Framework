/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using ACCPAC.Advantage;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Entity
{
    /// <summary>
    /// Class that implements PseudoViewFields
    /// </summary>
    public class PseudoViewFields : IViewFieldsComInterop
    {
        /// <summary>
        /// List of FieldValues
        /// </summary>
        public List<JToken> FieldValues = new List<JToken>();

        /// <summary>
        /// PseudoViewFields constructor
        /// </summary>
        /// <param name="view"></param>
        public PseudoViewFields(IViewComInterop view)
        {
            ParentView = view;
        }

        /// <summary>
        /// Count
        /// </summary>
        public int Count
        {
            get { return FieldValues.Count; }
        }

        /// <summary>
        /// FieldByID
        /// </summary>
        /// <param name="fieldID">fieldID</param>
        /// <returns>ViewField</returns>
        public ViewField FieldByID(int fieldID)
        {
             throw new NotImplementedException();
        }

        /// <summary>
        /// FieldByName
        /// </summary>
        /// <param name="fieldName">fieldName</param>
        /// <returns>ViewField</returns>
        public ViewField FieldByName(string fieldName)
        {
             throw new NotImplementedException();
        }

        /// <summary>
        /// ParentView
        /// </summary>
        public IViewComInterop ParentView
        {
            get;
            set;
        }

        /// <summary>
        /// Parent
        /// </summary>
        public View Parent
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// ViewField
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public ViewField this[int i]
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
        }
    }
}
