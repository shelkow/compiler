using compiler.CodeGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler.Types.AstNodes
{
    class NumberLiteralNode : ExpressionNode
    {
        public override void EmitCode(CodeEmitter emitter)
        {
            throw new NotImplementedException();
        }
        public int Value { get; private set; }

        public NumberLiteralNode(int value)
        {
            Value = value;
        }
    }
}
