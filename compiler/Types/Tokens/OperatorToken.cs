using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using compiler.Types.Tokens.Enumerations;

namespace compiler.Types.Tokens
{
    //Класс операторов
    class OperatorToken : Token
    {
        static readonly Dictionary<string, OperatorType> validOperators = new Dictionary<string, OperatorType>()
        {
            { "+", OperatorType.Add },
            { "&", OperatorType.And },
            { "=", OperatorType.Assignment },
            { "/", OperatorType.Divide },
            { "==", OperatorType.Equals },
            { ">=", OperatorType.GreaterEquals },
            { ">", OperatorType.GreaterThan },
            { "<=", OperatorType.LessEquals },
            { "<", OperatorType.LessThan },
            { "%", OperatorType.Modulo },
            { "*", OperatorType.Multiply },
            { "!", OperatorType.Not },
            { "!=", OperatorType.NotEquals },
            { "|", OperatorType.Or },
            { "-", OperatorType.SubstractNegate },
        };

        public OperatorType OperatorType { get; private set; }
        //Конструктор rк класса
        public OperatorToken(string content): base(content)
        {
            if (!validOperators.ContainsKey(content))
                throw new ArgumentException("Содержимое не содержит операторов!", "content");

            OperatorType = validOperators[content];
        }
    }
}
