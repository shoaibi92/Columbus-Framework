// Guids.cs
// MUST match guids.h
using System;

namespace Sage.ClassGen
{
    static class GuidList
    {
        public const string guidClassGenPkgString = "5eedf53a-a075-46bf-ae14-e44bd6d00d75";
        public const string guidClassGenCmdSetString = "946e6856-f238-47d3-8fe6-a59103367cc5";

        public static readonly Guid guidClassGenCmdSet = new Guid(guidClassGenCmdSetString);
    };
}