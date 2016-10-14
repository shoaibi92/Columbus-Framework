// Copyright (c) 2015 Sage Software, Inc.  All rights reserved.

using System;
using System.Security.Cryptography;
using System.Text;

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Security
{
    /// <summary>
    /// Helper methods for working with <see cref="Guid"/>.
    /// </summary>
    public static class DeterministicGuid
    {
        /// <summary>
        /// Creates a UUID using the RFC 4122 algorithm
        /// </summary>
        /// <param name="key">The input string to map into a UUID</param>
        /// <remarks>See <a href="http://code.logos.com/blog/2011/04/generating_a_deterministic_guid.html">Generating a deterministic GUID</a>.</remarks>
        public static Guid CreateFrom(string key)
        {
            if (key == null)
                throw new ArgumentNullException("key");

            // convert the name to a sequence of octets (as defined by the standard or conventions of its namespace) (step 3)
            var nameBytes = Encoding.UTF8.GetBytes(key); // ASSUME: UTF-8 encoding is always appropriate

            // convert the namespace UUID to network order (step 3)
            var namespaceBytes = Namespace.ToByteArray();
            SwapByteOrder(namespaceBytes);

            // comput the hash of the name space ID concatenated with the name (step 4)
            byte[] hash;
            using (HashAlgorithm algorithm = SHA1.Create())
            {
                algorithm.TransformBlock(namespaceBytes, 0, namespaceBytes.Length, null, 0);
                algorithm.TransformFinalBlock(nameBytes, 0, nameBytes.Length);
                hash = algorithm.Hash;
            }

            // most bytes from the hash are copied straight to the bytes of the new GUID (steps 5-7, 9, 11-12)
            var newGuid = new byte[16];
            Array.Copy(hash, 0, newGuid, 0, 16);

            // set the four most significant bits (bits 12 through 15) of the time_hi_and_version field to the appropriate 4-bit version number from Section 4.1.3 (step 8)
            newGuid[6] = (byte) ((newGuid[6] & 0x0F) | 0x50);

            // set the two most significant bits (bits 6 and 7) of the clock_seq_hi_and_reserved to zero and one, respectively (step 10)
            newGuid[8] = (byte)((newGuid[8] & 0x3F) | 0x80);

            // convert the resulting UUID to local byte order (step 13)
            SwapByteOrder(newGuid);
            return new Guid(newGuid);
        }

        /// <summary>
        /// The namespace for ISO OIDs (from RFC 4122, Appendix C).
        /// </summary>
        private static readonly Guid Namespace = new Guid("6ba7b812-9dad-11d1-80b4-00c04fd430c8");

        /// <summary>
        /// Converts a GUID (expressed as a byte array) to/from network order (MSB-first).
        /// </summary>
        internal static void SwapByteOrder(byte[] guid)
        {
            SwapBytes(guid, 0, 3);
            SwapBytes(guid, 1, 2);
            SwapBytes(guid, 4, 5);
            SwapBytes(guid, 6, 7);
        }

        /// <summary>
        /// Swaps two bytes of a byte array for the specified indexes
        /// </summary>
        private static void SwapBytes(byte[] guid, int left, int right)
        {
            var temp = guid[left];
            guid[left] = guid[right];
            guid[right] = temp;
        }
    }
}
