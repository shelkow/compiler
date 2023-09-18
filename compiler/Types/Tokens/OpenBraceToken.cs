
using compiler.Types.Tokens.Enumerations;

namespace compiler.Types.Tokens
{//класс открывающих скобок
    class OpenBraceToken : BraceToken
    {
        public OpenBraceToken(string content): base(content)
        {
            switch (content)
            {
                case "(":
                    BraceType = BraceType.Round;
                    break;
                case "[":
                    BraceType = BraceType.Square;
                    break;
                case "{":
                    BraceType = BraceType.Curly;
                    break;
                default:
                    throw new ArgumentException("Содержимое не содержит открывающую скобку!", "content");
            }
        }
    }
}
