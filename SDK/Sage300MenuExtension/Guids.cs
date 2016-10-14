// Guids.cs
// MUST match guids.h
using System;

namespace Sage.Sage300MenuExtension
{
    static class GuidList
    {
        public const string guidSage300MenuExtensionPkgString = "01147425-4520-45ad-8f04-52c37b853567";
        public const string guidSage300MenuExtensionCmdSetString = "efcb2057-f513-4b39-ae85-cccc9b644875";

        public static readonly Guid guidSage300MenuExtensionCmdSet = new Guid(guidSage300MenuExtensionCmdSetString);
    };
}