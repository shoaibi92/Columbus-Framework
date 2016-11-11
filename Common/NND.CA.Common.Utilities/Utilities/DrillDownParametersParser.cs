/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Collections.Generic;

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Utilities
{
    /// <summary>
    /// Parses parameter string returned by Drill Down business views (GLDRDN, ARDDDR, ARDLDN, ICDDDR, ICDLDN etc)
    /// </summary>
    public class DrillDownParametersParser
    {
        #region Constants
        /// <summary>
        /// Parameters separator
        /// </summary>
        private const char ParameterSeparator = '\n';

        /// <summary>
        /// Parameter value separator. Separates parameter name from value
        /// </summary>
        private const char ParameterValueSeparator = '=';

        /// <summary>
        /// Batch parameter name
        /// </summary>
        private const string BatchParameterName = "BATCH";

        /// <summary>
        /// Batch Entry parameter name
        /// </summary>
        private const string BatchEntryParameterName = "ENTRY";

        /// <summary>
        /// Sequence number parameter name
        /// </summary>
        private const string SequenceNumberParameterName = "SEQUENCENO";

        /// <summary>
        /// InquiryMode parameter name
        /// </summary>
        private const string InquiryMode = "INQUIRYMODE";

        /// <summary>
        /// Mode parameter name
        /// </summary>
        private const string Mode = "MODE";

        /// <summary>
        /// Inquiry parameter name
        /// </summary>
        private const string Inquiry = "Inquiry";

        /// <summary>
        /// Key parameter name
        /// </summary>
        private const string Key = "KEY";

        /// <summary>
        /// Posting Sequence parameter name
        /// </summary>
        private const string PostingSequence = "POSTSEQ";

        /// <summary>
        /// Bank Sequence parameter name
        /// </summary>
        private const string BankSequence = "BANKSEQ";

        /// <summary>
        /// Sequence Key parameter name
        /// </summary>
        private const string SequenceKey = "KEYSEQ";

        /// <summary>
        /// Type parameter name
        /// </summary>
        private const string Type = "TYPE";

        #endregion

        #region Private members

        /// <summary>
        /// Parsed parameters
        /// </summary>
        private readonly Dictionary<string, string> _parameters;

        /// <summary>
        /// Parses parameters string
        /// </summary>
        /// <param name="parameterString">parameters string</param>
        /// <returns>parsed parameters</returns>
        private Dictionary<string, string> ParseParameterString(string parameterString)
        {
            var result = new Dictionary<string, string>();
            if (parameterString != null)
            {
                var parameters = parameterString.Split(ParameterSeparator);
                foreach (var parameter in parameters)
                {
                    var parameterParts = parameter.Split(ParameterValueSeparator);
                    if (parameterParts.Length == 2)
                        result.Add(parameterParts[0], parameterParts[1]);
                }
            }
            return result;
        }

        #endregion

        /// <summary>
        /// Instantiates a new instance of DrillDownParametersParser class
        /// </summary>
        /// <param name="parametersString">Parameters string to parse</param>
        public DrillDownParametersParser(string parametersString)
        {
            _parameters = ParseParameterString(parametersString);
        }

        /// <summary>
        /// Gets batch parameter value
        /// </summary>
        /// <returns>Batch parameter value</returns>
        public string GetBatchNumber()
        {
            return _parameters[BatchParameterName];
        }

        /// <summary>
        /// Gets batch entry parameter value
        /// </summary>
        /// <returns>Batch Entry parameter value</returns>
        public string GetBatchEntryNumber()
        {
            return _parameters[BatchEntryParameterName];
        }

        /// <summary>
        /// Gets sequence number parameter value
        /// </summary>
        /// <returns>Batch sequence parameter value</returns>
        public string GetSequenceNumber()
        {
            return _parameters[SequenceNumberParameterName];
        }

        /// <summary>
        /// Gets InquiryMode parameter value
        /// </summary>
        /// <returns>InquiryMode parameter value</returns>
        public bool GetInquiryMode()
        {
            return _parameters[InquiryMode] == "1";
        }

        /// <summary>
        /// Gets Mode parameter value for Inquiry
        /// </summary>
        /// <returns>Mode parameter value</returns>
        public string GetMode()
        {
            return _parameters[Mode] = Inquiry;
        }

        /// <summary>
        /// Gets Key parameter value
        /// </summary>
        /// <returns>Key parameter value</returns>
        public string GetKey()
        {
            return _parameters[Key];
        }
        
        /// <summary>
        /// Gets sequence number parameter value
        /// </summary>
        /// <returns>Batch sequence parameter value</returns>
        public string GetPostingSequence()
        {
            return _parameters[PostingSequence];
        }
        
        /// <summary>
        /// Gets sequence number parameter value
        /// </summary>
        /// <returns>Bank sequence parameter value</returns>
        public string GetBankSequence()
        {
            return _parameters[BankSequence];
        }

        /// <summary>
        /// Gets sequence number parameter value
        /// </summary>
        /// <returns>Batch sequence parameter value</returns>
        public string GetSequenceKey()
        {
            return _parameters[SequenceKey];
        }

        /// <summary>
        /// Gets sequence number parameter value
        /// </summary>
        /// <returns>Batch sequence parameter value</returns>
        public string GetTypeParameter()
        {
            return _parameters[Type];
        }
    }
}
