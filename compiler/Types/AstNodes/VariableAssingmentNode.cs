using compiler.CodeGeneration;
using compiler.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  compiler.Types.AstNodes
{
    class VariableAssingmentNode : AstNode
    {
        public override void EmitCode(CodeEmitter emitter)
        {
            throw new NotImplementedException();
        }
        public string VariableName { get; private set; }
        public ExpressionNode ValueExpression { get; private set; }

        public VariableAssingmentNode(string name, ExpressionNode expr)
        {
            if (expr == null)
                throw new ParsingException("The assinged expression may not be null!");

            VariableName = name;
            ValueExpression = expr;
        }
    }
}
