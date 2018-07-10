// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Composition;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;

namespace Microsoft.AspNetCore.Mvc.Analyzers
{
    [ExportCodeFixProvider(LanguageNames.CSharp)]
    [Shared]
    public class ApiConvention_ExtractionToConventionCodeFixProvider : CodeFixProvider
    {
        private const string CodeFixTitle = "Extract to convention";

        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(
            DiagnosticDescriptors.MVC1004_ActionReturnsUndocumentedStatusCode.Id);


        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);

            var diagnostic = context.Diagnostics[0];
            var diagnosticSpan = diagnostic.Location.SourceSpan;

            var token = root.FindToken(diagnosticSpan.Start);
            SyntaxNode originalNode = token.GetAncestor<PropertyDeclarationSyntax>();

            if (originalNode == null)
            {
                originalNode = token.GetAncestor<MethodDeclarationSyntax>();
            }

            if (originalNode == null)
            {
                originalNode = token.GetAncestor<FieldDeclarationSyntax>();
            }

            if (originalNode == null)
            {
                return;
            }
        }
    }
}
