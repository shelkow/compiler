//using compiler.CodeGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using compiler.CodeGeneration;
namespace compiler.Types
{
    abstract class AstNode
    {
        public abstract void EmitCode(CodeEmitter emitter);
    }
}
