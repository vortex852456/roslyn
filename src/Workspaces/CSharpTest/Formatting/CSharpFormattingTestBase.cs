﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Options;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.UnitTests.Formatting;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.UnitTests.Formatting
{
    public class CSharpFormattingTestBase : FormattingTestBase
    {
        private Workspace _ws;

        protected Workspace DefaultWorkspace
            => _ws ?? (_ws = new AdhocWorkspace());

        protected override SyntaxNode ParseCompilation(string text, ParseOptions parseOptions)
        {
            return SyntaxFactory.ParseCompilationUnit(text, options: (CSharpParseOptions)parseOptions);
        }

        protected Task AssertFormatAsync(
            string expected,
            string code,
            bool debugMode = false,
            Dictionary<OptionKey, object> changedOptionSet = null,
            bool testWithTransformation = true,
            ParseOptions parseOptions = null)
        {
            return AssertFormatAsync(expected, code, SpecializedCollections.SingletonEnumerable(new TextSpan(0, code.Length)), debugMode, changedOptionSet, testWithTransformation, parseOptions);
        }

        protected Task AssertFormatAsync(
            string expected,
            string code,
            IEnumerable<TextSpan> spans,
            bool debugMode = false,
            Dictionary<OptionKey, object> changedOptionSet = null,
            bool testWithTransformation = true,
            ParseOptions parseOptions = null)
        {
            return AssertFormatAsync(expected, code, spans, LanguageNames.CSharp, debugMode, changedOptionSet, testWithTransformation, parseOptions);
        }
    }
}
