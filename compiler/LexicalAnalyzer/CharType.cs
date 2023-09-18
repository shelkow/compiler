
namespace compiler.LexicalTokenizer
{

    [Flags] //показывает что перечисление работает с битовыми полями
    enum CharType
    {
        /// <summary>
        /// Неизвестный. Это 0x00, поэтому его нельзя проверить с помощью HasFlag!
        /// (Символ может быть только неизвестным или чем-то еще)
        /// </summary>
        Unknown = 0x00, //0
        /// <summary>
        /// а-z,А-z,_. Все, что приемлемо для начала идентификатора.
        /// /// </summary>
        Alpha = 0x01, //1
        /// <summary>
        /// 0-9.
        /// </summary>
        Numeric = 0x02,//2
        /// <summary>
        /// Пробелы, табы. Пробелы, но нет новой строки.
        /// </summary>
        LineSpace = 0x04,//4
        /// <summary>
        /// Символ новой строки.
        /// </summary>
        NewLine = 0x08,//8
        /// <summary>
        /// +,-,*,/,%,&,|,=,&gt;,&lt;,!.
        /// </summary>
        Operator = 0x10,//16
        /// <summary>
        /// (,[,{.
        /// </summary>
        OpenBrace = 0x20,//32
        /// <summary>
        /// ),],}.
        /// </summary>
        CloseBrace = 0x40,//64
        /// <summary>
        /// ,. Запятая используется для разделения аргументов функций.
        /// </summary>
        ArgSeperator = 0x80,//128
        /// <summary>
        /// ;. Точка с запятой используется для разделения операторов.
        /// </summary>
        StatementSeperator = 0x100,//256

        //составные значения (побитовые операции)
        AlphaNumeric = Alpha | Numeric, //буквы + числа 0-9
        WhiteSpace = LineSpace | NewLine,//пробел+новая строка
        Brace = OpenBrace | CloseBrace, //{}
        /// <summary>
        /// Символы, которые «имеют особое значение
        /// </summary>
        MetaChar = Operator | Brace |ArgSeperator | StatementSeperator, //Оператор  Скобки  ,  ;

        All = AlphaNumeric | WhiteSpace | MetaChar, //идентификатор + числа пробел+новая строка MetaChar
    }
}
