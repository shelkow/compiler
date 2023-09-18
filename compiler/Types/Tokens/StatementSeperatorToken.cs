using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler.Types.Tokens
{
   //Разделитель ;
    class StatementSeperatorToken : Token
    {
        public StatementSeperatorToken(string content): base(content)
        {
            if (content != ";")
                throw new ArgumentException("Содержимое не содержит разделителя ;", "content");
        }
    }
}
