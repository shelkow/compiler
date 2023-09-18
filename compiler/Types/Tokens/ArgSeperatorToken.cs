

namespace compiler.Types.Tokens
{
    //Класс разделитель ,
    class ArgSeperatorToken : Token
    {
        //base(content) вызывает конструктор базового класса, передавая ему значение content
        public ArgSeperatorToken(string content): base(content)
        {
            if (content != ",")
                throw new ArgumentException("Cодержимое не является разделителем!", "content");
        }
    }
}
