﻿using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Utilities;
using Microsoft.Web.Editor;
using Microsoft.Web.Core.ContentTypes;

namespace MadsKristensen.EditorExtensions.Html
{
    [Export(typeof(IPeekableItemSourceProvider))]
    [ContentType(HtmlContentTypeDefinition.HtmlContentType)]
    [Name("HTML Class Peekable Item Provider")]
    [SupportsStandaloneFiles(false)]
    class ClassPeekItemProvider : IPeekableItemSourceProvider
    {
#pragma warning disable 649 // "field never assigned to" -- field is set by MEF.
        [Import]
        private IPeekResultFactory _peekResultFactory;
#pragma warning restore 649

        public IPeekableItemSource TryCreatePeekableItemSource(ITextBuffer textBuffer)
        {
            return textBuffer.Properties.GetOrCreateSingletonProperty(() => new ClassPeekItemSource(textBuffer, _peekResultFactory));
        }
    }
}