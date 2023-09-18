using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using compiler.Types.Tokens.Enumerations;

namespace compiler.Types.Tokens
{//Класс закрывающих скобок
    class CloseBraceToken : BraceToken
    {
        public CloseBraceToken(string content): base(content)
        {
            switch (content)
            {
                case ")":
                    BraceType = BraceType.Round;
                    break;
                case "]":
                    BraceType = BraceType.Square;
                    break;
                case "}":
                    BraceType = BraceType.Curly;
                    break;
                default:
                    throw new ArgumentException("Содержимое без закрывающей скобки!", "content");
            }
        }
    }
}
