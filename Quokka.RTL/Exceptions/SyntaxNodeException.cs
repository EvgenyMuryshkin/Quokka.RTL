using Microsoft.CodeAnalysis;
using System;

namespace Quokka.RTL
{
    public class SyntaxNodeException : Exception
    {
        SyntaxNode _syntaxNode;
        public SyntaxNodeException(SyntaxNode syntaxNode, Exception ex) : base(syntaxNode?.ToString() ?? "{null}", ex)
        {
            _syntaxNode = syntaxNode;
        }
    }
}
