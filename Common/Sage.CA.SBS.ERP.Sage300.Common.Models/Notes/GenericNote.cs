/* Copyright (c) 2016 Sage Software, Inc.  All rights reserved. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

// This set of classes are main for mock the yet to be generated KN controller
// and they will be replace when the KN controller is available in the note repository.

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Notes
{
    /// <summary>
    /// The Generic Note model to satisfy the unity binding
    /// </summary>
    public class GenericNote : Note
    {
    }

    /// <summary>
    /// Note Options
    /// </summary>
    public class NoteIdValuePair
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string value { get; set; }
    }

    /// <summary>
    /// Note Options
    /// </summary>
    public class NoteOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid NoteUniq { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid NextNoteUniquifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<NoteIdValuePair> NoteTypes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<NoteIdValuePair> NoteStates { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<NoteIdValuePair> NoteLinkTo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<NoteIdValuePair> NoteDissmissOptions { get; set; }
    }

    /// <summary>
    /// Notes Catagory
    /// </summary>
    public class NoteCatagory
    {
        /// <summary>
        /// 
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AppID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SingluarResourceNameID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid SingularName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid PluralResourceNameID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid PluralName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid ViewIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid ViewKeyFieldName { get; set; }

    }

    /// <summary>
    /// dismissed notes
    /// </summary>
    public class NoteDismissal
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid NoteUniq { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid DismissedBy { get; set; }
    }

    /// <summary>
    /// The actual notes
    /// </summary>
    public class NoteComponent
    {
        /// <summary>
        /// Note Token
        /// </summary>
        public Guid NoteUniq { get; set; }

        /// <summary>
        /// Note Token
        /// </summary>
        public int ComponentSequence { get; set; }

        /// <summary>
        /// Note Token
        /// </summary>
        public int ComponentSize { get; set; }

        /// <summary>
        /// Note Token
        /// </summary>
        public DateTime ComponentDate { get; set; }

    }

    /// <summary>
    /// Note token
    /// </summary>
    public class Note
    {
        /// <summary>
        /// id for data binding
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Note Token
        /// </summary>
        public Guid NoteUniq { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EntityID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EntityKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime LastMaintainDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String LastMaintainBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime NoteStartDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime NoteEndDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Importance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Tags { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// 
        public String Preview { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 
        /// </summary> 
        public int Status { get; set; }

        /// <summary>
        /// 
        /// </summary> 
        public int Color { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int validDateCheck { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int TotalContentSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IsDismissed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public NoteOptions Options { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<NoteCatagory> Catagories { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<NoteComponent> NoteComponents { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<NoteDismissal> NoteDismissals { get; set; }
    }

}



