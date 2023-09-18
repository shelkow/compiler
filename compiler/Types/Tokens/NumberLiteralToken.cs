
namespace compiler.Types.Tokens
{
    //Класс чисел 0-9
    class NumberLiteralToken:Token
    {
        public int Number
        {
            get
            {
                return number;
            }
        }
        private int number;
       //конструктор
        public NumberLiteralToken(string content):base(content)
        {
            if (!int.TryParse(content, out number))
                throw new ArgumentException("Содержимое не содержит число.", "content");
        }
    }
}
