using CSharpier.DocTypes;
using CSharpier.SyntaxPrinter;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSharpier
{
    public partial class Printer
    {
        private Doc PrintVariableDeclarationSyntax(
            VariableDeclarationSyntax node
        ) {
            var docs = Doc.Concat(
                SeparatedSyntaxList.Print(
                    node.Variables,
                    this.PrintVariableDeclaratorSyntax,
                    node.Parent is ForStatementSyntax ? Doc.Line : Doc.HardLine
                )
            );

            return Doc.Concat(
                this.Print(node.Type),
                " ",
                node.Variables.Count > 1 ? Doc.Indent(docs) : docs
            );
        }
    }
}
