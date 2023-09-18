
using compiler.Types.Tokens.Enumerations;

namespace compiler.Types.Tokens
{
    //Класс скобок ({[ ]})
    abstract class BraceToken : Token
    {
        public BraceType BraceType { get; protected set; }

        public BraceToken(string content): base(content)
        { }
    }
}
