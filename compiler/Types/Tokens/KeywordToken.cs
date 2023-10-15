
using compiler.Types.Tokens.Enumerations;

namespace compiler.Types.Tokens
{
    //Класс ключевых слов
    class KeywordToken : Token
    {
        //cловарь ключевых слов
        private static readonly Dictionary<string, KeywordType> validKeywords = new Dictionary<string, KeywordType>()
        {
             { "if", KeywordType.If },
            { "Integer", KeywordType.Integer},
             { "return", KeywordType.Return },
             { "void", KeywordType.Void },
            { "while", KeywordType.While },
            { "Begin", KeywordType.Begin },
            { "End", KeywordType.End },
            { "Var", KeywordType.Var },
            { "Program", KeywordType.Program },

        };
        //словарь для определния типа ключевых слов
        private static readonly Dictionary<KeywordType, VariableType> keywordTypeToVariableType = new Dictionary<KeywordType, VariableType>
        {
            { KeywordType.Integer, VariableType.Integer },
           // { KeywordType.Void, VariableType.Void },
        };

        public KeywordType KeywordType { get; private set; }

        /// <summary>
        /// Возвращает true, если это KeywordType является ключевым словом
        /// в противном случае — false.
        /// </summary>
        public bool IsTypeKeyword
        {
            get { return keywordTypeToVariableType.ContainsKey(KeywordType); }
        }
        //конструктор который наследует базовый конструктор
        public KeywordToken(string content): base(content)
        {
            if (!validKeywords.ContainsKey(content))
                throw new ArgumentException("В содержимом нет допустимого ключевого слова.", "content");

            KeywordType = validKeywords[content];
        }

        /// <summary>
        /// Возвращает true, если данная строка является известной
        /// Вернет ключевое слово, в противном случае false.
        /// </summary>
        public static bool IsKeyword(string s)
        {
            return validKeywords.ContainsKey(s);
        }

        /// <summary>
        /// Возвращает ассоциированный тип переменной для этого ключевого слова,
        /// если это ключевое слово представляет тип переменной.
        /// В противном случае выдает исключение.
        /// </summary>
        public VariableType ToVariableType()
        {
            return keywordTypeToVariableType[KeywordType];
        }
    }
}
