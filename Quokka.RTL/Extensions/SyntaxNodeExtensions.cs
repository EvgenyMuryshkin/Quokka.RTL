using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Microsoft.CodeAnalysis
{
    public static class SyntaxNodeExtensions
    {
        public static bool IsConst(this LocalDeclarationStatementSyntax node)
        {
            return node.Modifiers.Any(m => m.ValueText == "const");
        }

        public static bool IsStatic(this BaseMethodDeclarationSyntax node)
        {
            return node.Modifiers.IsStatic();
        }

        public static bool IsStatic(this ClassDeclarationSyntax node)
        {
            return node.Modifiers.IsStatic();
        }

        public static bool IsStatic(this SyntaxTokenList node)
        {
            return node.Any(m => m.ValueText == "static");
        }

        public static bool IsPublic(this BaseMethodDeclarationSyntax node)
        {
            return node.Modifiers.IsPublic();
        }

        public static bool IsPublic(this FieldDeclarationSyntax node)
        {
            return node.Modifiers.IsPublic();
        }

        public static bool IsPublic(this SyntaxTokenList node)
        {
            return node.Any(m => m.ValueText == "public");
        }

        public static bool IsOut(this ParameterSyntax node)
        {
            return node.Modifiers.Any(m => m.ValueText == "out");
        }

        public static bool IsRef(this ParameterSyntax node)
        {
            return node.Modifiers.Any(m => m.ValueText == "ref");
        }

        public static T RecursiveParent<T>(this SyntaxNode node) where T : SyntaxNode
        {
            if (node == null || node.Parent == null)
                return null;

            if (node.Parent is T)
                return node.Parent as T;

            return RecursiveParent<T>(node.Parent);
        }

        public static string CallerStackDump(this SyntaxNode node)
        {
            var stack = node.CallerStack();

            return string.Join(Environment.NewLine, stack.Select(s => $" at {s}"));
        }

        public static List<string> CallerStack(this SyntaxNode node)
        {
            var result = new List<string>();

            if (node == null)
                return result;

            switch (node)
            {
                case ClassDeclarationSyntax cds:
                    result.Add(cds.Identifier.ValueText);
                    break;
                case MethodDeclarationSyntax mds:
                    result.Add(mds.Identifier.ValueText);
                    break;
            }

            result.AddRange(CallerStack(node.Parent));

            return result;
        }

        public static IEnumerable<SyntaxNode> SelfWithChildren(this SyntaxNode node)
        {
            var items = new List<SyntaxNode>();
            if (node == null)
                return items;

            items.Add(node);

            foreach (var child in node.ChildNodes())
            {
                items.Add(child);
                items.AddRange(SelfWithChildren(child).Skip(1));
            }

            return items;
        }

        public static bool Contains<T>(this SyntaxNode parent) 
            where T : SyntaxNode
        {
            return SelfWithChildren(parent).OfType<T>().Any();
        }

        public static T FirstChild<T>(this SyntaxNode node)
        {
            var all = SelfWithChildren(node).OfType<T>();
            if (!all.Any())
            {
                throw new Exception($"No children on type {typeof(T)} ere found in node {node}");
            }

            return all.First();
        }


        public static T Parent<T>(this SyntaxNode node)
            where T : SyntaxNode
        {
            if (node == null)
                return null;

            if (node.Parent is T)
                return node.Parent as T;

            return Parent<T>(node.Parent);
        }

        public static IEnumerable<T> SelfWithChildren<T>(this SyntaxNode node)
        {
            return SelfWithChildren(node).OfType<T>();
        }

        public static T FirstOrDefaultChild<T>(this SyntaxNode node)
        {
            return SelfWithChildren(node).OfType<T>().FirstOrDefault();
        }
    }
}
