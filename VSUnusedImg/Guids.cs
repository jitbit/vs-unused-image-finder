// Guids.cs
// MUST match guids.h
using System;

namespace JitbitSoftware.VSUnusedImg
{
    static class GuidList
    {
        public const string guidVSUnusedImgPkgString = "099ef6b8-8a88-4cf1-96fe-a585affdbd0c";
        public const string guidVSUnusedImgCmdSetString = "7988d9d7-71a3-4bc6-aeb1-8be3baad176c";

        public static readonly Guid guidVSUnusedImgCmdSet = new Guid(guidVSUnusedImgCmdSetString);
    };
}