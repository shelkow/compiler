using compiler.CodeGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler.Types.AstNodes
{
    class VariableReferenceExpressionNode : ExpressionNode
    {
        public override void EmitCode(CodeEmitter emitter)
        {
            throw new NotImplementedException();
        }
        public string VariableName { get; private set; }

        public VariableReferenceExpressionNode(string varName)
        {
            VariableName = varName;
        }
    }
}
