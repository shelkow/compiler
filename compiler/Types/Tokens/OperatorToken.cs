﻿
using compiler.Types.Tokens.Enumerations;

namespace compiler.Types.Tokens
{
    //Класс операторов
    class OperatorToken : Token
    {
        static readonly Dictionary<string, OperatorType> validOperators = new Dictionary<string, OperatorType>()
        {
            { "+", OperatorType.Add },
            { "-", OperatorType.SubstractNegate },
            { "&", OperatorType.And },
            { "=", OperatorType.Assignment },
            { "=-", OperatorType.NegativeDeclaration },
            { "=+", OperatorType.PlusDeclaration },
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
            { ":", OperatorType.DoublePoint },
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
