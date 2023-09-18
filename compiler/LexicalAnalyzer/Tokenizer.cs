using System.Globalization; //для UnicodeCategory
using System.Text;//для StringBuilder
using compiler.Types.Tokens;
using compiler.Types;
//Лексический анализатор
namespace compiler.LexicalTokenizer
{
    /// Tokenizer превращает исходный текст в набор токенов
    class Tokenizer
    {
        void FileCheck(char symbol)
        {
            FileStream fs1;
            if (!File.Exists(@"C:\Users\shelk\source\repos\compiler\Errors.txt"))
            {
                fs1 = File.Create(@"C:\Users\shelk\source\repos\compiler\Errors.txt");
                Console.WriteLine("\nErrors файл создан!");
                fs1.Close();
            }
            Console.WriteLine("\nПроизошла ошибка, проверьте файл Erorrs!");
            fs1 = File.Open(@"C:\Users\shelk\source\repos\compiler\Errors.txt", FileMode.Open, FileAccess.ReadWrite);
            fs1.SetLength(0);
            fs1.Close();

            StreamWriter file3 = new StreamWriter(@"C:\Users\shelk\source\repos\compiler\Errors.txt", true);
            file3.Write("Ошибка! Обнаружен неопознанный символ = "+symbol);
            file3.Close();
            fs1 = File.Open(@"C:\Users\shelk\source\repos\compiler\OutputFile.txt", FileMode.Open, FileAccess.ReadWrite);
            fs1.SetLength(0);
            fs1.Close();
            Console.WriteLine("OutputFile очищен!");
        }
        //cвойство с текстом
        public string Code { get; private set; }
        // текущая позиция
        private int readingPosition;

        //конструктор
        public Tokenizer(string code)
        {
            this.Code = code;

            readingPosition = 0;
        }
        //метод возвращающий массив токенов
       public Token[] Tokenize()
        {
            var tokens = new List<Token>();

            var builder = new StringBuilder();

            while (!eof_code()) //пока не конец строки
            {
                skip(CharType.WhiteSpace); //whitespace=linespace|newline
                switch (TypeOfCurrSymbol())
                {
                    case CharType.Alpha:
                        // readToken() - пока не конец строки и тип символа либо Alpha либо Numeric
                        readToken(builder, CharType.AlphaNumeric);//считываем слово из букв и чисел
                        string s = builder.ToString();//записали неизвестное слово в строку
                        if (KeywordToken.IsKeyword(s)) //либо ключевое слово либо идентификатор
                            tokens.Add(new KeywordToken(s));
                        else
                            tokens.Add(new IdentifierToken(s));//похоже на ключевое слово но им не является
                        builder.Clear();
                        break;
                    case CharType.Numeric: //число
                        readToken(builder, CharType.Numeric);
                        tokens.Add(new NumberLiteralToken(builder.ToString()));
                        builder.Clear();
                        break;
                    case CharType.Operator:
                        readToken(builder, CharType.Operator);
                        tokens.Add(new OperatorToken(builder.ToString()));
                        builder.Clear();
                        break;
                    case CharType.OpenBrace:
                        tokens.Add(new OpenBraceToken(next().ToString()));
                        break;
                    case CharType.CloseBrace:
                        tokens.Add(new CloseBraceToken(next().ToString()));
                        break;
                    case CharType.ArgSeperator:
                        tokens.Add(new ArgSeperatorToken(next().ToString())); //,
                        break;
                    case CharType.StatementSeperator:
                        tokens.Add(new StatementSeperatorToken(next().ToString())); //;
                        break;
                    default:
                        //throw new Exception("Лексический анализатор обнаружил неопознанный символ!");
                        //to do обработка исключения
                        //Если файл не существует то создать

                        FileCheck(curr_symbol());
                        Environment.Exit(0);
                        break;
                       
                }
            }
            return tokens.ToArray();
        }
        /// <summary>
        /// если текущий символ обработан, перейти к следующему
        /// </summary>
        private void readToken(StringBuilder builder, CharType typeToRead)
        {
            //пока не конец строки и тип текущего символа либо Alpha либо Numeric
            while (!eof_code() && TypeOfCurrSymbol().HasAnyFlag(typeToRead))
                builder.Append(next());
        }

        /// <summary>
        /// Функция, перенос каретки на следующий символ, пока тип символа есть в перечислении CharType
        /// </summary>
        private void skip(CharType typeToSkip)
        {
            //пока тип символа есть в перечислении CharType
            while (TypeOfCurrSymbol().HasAnyFlag(typeToSkip))
                next();
        }
        /// <summary>
        /// Функция, возвращает тип текущего символа 
        /// </summary>
        private CharType TypeOfCurrSymbol()
        {
            return charTypeOf(curr_symbol());
        }
        /// <summary>
        ///Функция определяет тип текущего символа и переносит каретку
        ///</summary>
        private CharType nextType()
        {
            return charTypeOf(next());
        }
        /// <summary>
        /// Возвращает тип текущего символа
        /// </summary>
        /// <returns>        
        /// Оператор, Откр. скобки, Закр. скобки, Разделитель аргументов, Разделитель строк, Переход на новую строку
        /// Число, новая строка, абзац, заглавные, строчные, пробел
        /// </returns>
        private CharType charTypeOf(char c)
        {

            switch (c)
            {
                case '+':
                case '-':
                case '*':
                case '/':
                case '%':
                case '&':
                case '|':
                case '=':
                    return CharType.Operator;
                case '(':
                case '[':
                case '{':
                    return CharType.OpenBrace;
                case ')':
                case ']':
                case '}':
                    return CharType.CloseBrace;
                case ',':
                    return CharType.ArgSeperator;
                case ';':
                    return CharType.StatementSeperator;
                case '\r': //\r and \n have UnicodeCategory.Control, not LineSeperator...
                case '\n':
                    return CharType.NewLine;
            }
            
            //Определяем категорию символа
            switch (char.GetUnicodeCategory(c))
            {
                case UnicodeCategory.DecimalDigitNumber:
                    return CharType.Numeric;//десятичное число
                case UnicodeCategory.LineSeparator: //новая строка
                    return CharType.NewLine;
                case UnicodeCategory.ParagraphSeparator://разделение абзацев
                case UnicodeCategory.LowercaseLetter://строчные буквы
                case UnicodeCategory.OtherLetter://остальные буквы
                case UnicodeCategory.UppercaseLetter://заглавные
                    return CharType.Alpha;
                case UnicodeCategory.SpaceSeparator://пробел
                    return CharType.LineSpace;
            }
           
            return CharType.Unknown; //Неопознанный тип
        }
            
        /// <summary>
        /// функция возвращающая текущий символ
        /// </summary>
        /// <returns>текущий символ</returns>
        private char curr_symbol()
        {
            return Code[readingPosition];
        }

        /// <summary>
        ///функция возвращает текущий символ и переносит каретку на след символ
        /// </summary>
        private char next()
        {
            var buff_symbol= curr_symbol(); 
            readingPosition++;
            return buff_symbol;
        }

        /// <summary>
        ///функция для проверки конца строки 
        /// </summary>
        /// <returns>true/false</returns>
        private bool eof_code()
        {
            return readingPosition >= Code.Length;
        }
    }
}
