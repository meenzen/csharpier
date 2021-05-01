using System;
using CSharpier.DocTypes;
using CSharpier.SyntaxPrinter;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSharpier
{
    public partial class Printer
    {
        private Doc PrintFixedStatementSyntax(FixedStatementSyntax node)
        {
            var groupId = Guid.NewGuid().ToString();

            return Doc.Concat(
                ExtraNewLines.Print(node),
                this.PrintSyntaxToken(
                    node.FixedKeyword,
                    afterTokenIfNoTrailing: " "
                ),
                Token.Print(node.OpenParenToken),
                Doc.GroupWithId(
                    groupId,
                    Doc.Indent(Doc.SoftLine, Node.Print(node.Declaration)),
                    Doc.SoftLine
                ),
                Token.Print(node.CloseParenToken),
                node.Statement is BlockSyntax blockSyntax
                    ? this.PrintBlockSyntaxWithConditionalSpace(
                            blockSyntax,
                            groupId
                        )
                    : this.Print(node.Statement)
            );
        }
    }
}
