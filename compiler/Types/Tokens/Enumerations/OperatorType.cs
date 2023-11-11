using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler.Types.Tokens.Enumerations
{
    enum OperatorType
    {
        Add,
        NegativeDeclaration,
        PlusDeclaration,
        DoublePoint,
        SubstractNegate, //отрицание будет иметь то же строковое представление, что и вычитание
        Multiply,
        Divide,
        Modulo,
        Assignment,
        Equals,
        GreaterThan,
        LessThan,
        GreaterEquals,
        LessEquals,
        NotEquals,
        Not,
        And,
        Or,
    }
}
