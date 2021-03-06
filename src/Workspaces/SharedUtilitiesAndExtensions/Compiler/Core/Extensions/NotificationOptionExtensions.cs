﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CodeAnalysis.Diagnostics;

#if CODE_STYLE
namespace Microsoft.CodeAnalysis.Internal.Options
#else
namespace Microsoft.CodeAnalysis.CodeStyle
#endif
{
    internal static class NotificationOptionExtensions
    {
        public static string ToEditorConfigString(this NotificationOption notificationOption)
            => notificationOption.Severity.ToEditorConfigString();
    }
}
