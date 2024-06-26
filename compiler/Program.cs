﻿using compiler.LexicalTokenizer;
using compiler.Parsing;
using compiler.Types;

namespace compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            string code;
            //Если файл не существует то создать
            FileStream fs;
            if (!File.Exists(@"C:\Users\shelk\source\repos\compiler_\InputFile.txt"))
            {
                fs = File.Create(@"C:\Users\shelk\source\repos\compiler_\InputFile.txt");
                Console.WriteLine("InputFile создан!");
                fs.Close();
            }
            
            //Считываем с файла текст в строку
            StreamReader file = new StreamReader(@"C:\Users\shelk\source\repos\compiler_\InputFile.txt");
            code = file.ReadToEnd();
            //вывод считанной из файла строки в консоль
            for (int i = 0; i < code.Length; i++)
            {
                Console.Write(code[i]);
            }
            file.Close();
            Console.WriteLine("");
            var lexer = new Tokenizer(code);
            var tokens = lexer.Tokenize();
            fs = File.Open(@"C:\Users\shelk\source\repos\compiler_\OutputFile.txt", FileMode.Open, FileAccess.ReadWrite);
            fs.SetLength(0);
            fs.Close();
            StreamWriter file2 = new StreamWriter(@"C:\Users\shelk\source\repos\compiler_\OutputFile.txt", true);
            List<Token> tree = new List<Token>();

            foreach (var token in tokens)
            {
                file2.Write(token + "\n");
                tree.Add(token);

            }
            file2.Close();

            var parser = new Parser(tree);
            parser.Analyze();


            // Console.ReadKey(false);

            /*  string code = @"
           int main()
           {   a+b;
           }";
                     
            // File.Create("C:\\Users\\shelk\\Desktop\\TestFile2.txt");
            var lexer = new Tokenizer(code);
            var tokens = lexer.Tokenize();
            StreamWriter file = new StreamWriter("C:\\Users\\shelk\\Desktop\\TestFile.txt");

            foreach (var token in tokens)
            {
                file.Write(token+"\n");
            }
            file.Close();

            Console.WriteLine();
            Console.WriteLine();
            */

        }
    }
}
