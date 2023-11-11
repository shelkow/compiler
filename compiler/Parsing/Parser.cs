using compiler.Types;
using compiler.Types.AstNodes;
using compiler.Types.Tokens;
using compiler.Types.Tokens.Enumerations;
using compiler.LexicalTokenizer;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler.Parsing
{
    /// <summary>
    /// Parser for the compiler language.
    /// </summary>

    class Parser
    {
        private List<Token> tokens;
        private int currentTokenIndex;

        public Parser(List<Token> tokens)
        {
            this.tokens = tokens;
            this.currentTokenIndex = 0;
        }

        public void Analyze()
        {
            R1_ProgramBlock();
            R2_VariableDeclaration();
            R4_CheckBrackets();

        }
        //IdentifierToken OperatorToken NumberLiteralToken

        public Token NextToken(int id)
        {
            for (int i = 0; i < 1; i++)
            {
                tokens[i] = tokens[i + 1];
            }
            return tokens[currentTokenIndex];
        }
        //(Program)Keyword (first)Identifier
        //(Var)Keyword (a)Identifier,(,)ArgSeparator,(b)Identifier
        //(a)Identifier (=)Operator (3)Number
        //(c)Identifier (=)Operator (a)Identifier (+)Operator (b)Identifier c=a+b;
        //(write)Identifier BraceLeft BraceRight

        //Блок Program
        public void R1_ProgramBlock()
        {
            Console.WriteLine("Начало блока Program");
            int bufferindex = 0;

            for (var i = 0; i < 2; i++)
            {
                bufferindex++;
                //Можно lab lab1, нельзя 1lab и 1
                if (tokens[0].Content == "Program")
                {
                    if (tokens[i].GetType().Name == "IdentifierToken")
                    {
                        Console.WriteLine("Название программы " + tokens[1].Content);

                        if (tokens[i + 1].GetType().Name == "StatementSeperatorToken")
                        {
                            Console.WriteLine("Конец блока Program");
                        }
                        else
                        {
                            Console.WriteLine("Ожидалcя cимвол ;");
                        }
                    }
                    else
                    {
                        if (i == 1)
                        {
                            Console.WriteLine("Название программы должно быть идентификатором, например Exercize1");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ожидалось ключевое слово Program");
                }
            }
        }
        //Блок Var
        public int buff, bufferindex2;
        public void R2_VariableDeclaration()
        {
            Console.WriteLine("Начало блока Var");

            for (var i = 3; i < tokens.Count; i++)
            {
                bufferindex2++;
                //Можно lab lab1, нельзя 1lab и 1
                if (tokens[3].Content == "Var")
                {

                    //Console.WriteLine(tokens[i].Content);
                    if (tokens[i].GetType().Name == "IdentifierToken")
                    {
                        if (tokens[i + 1].GetType().Name == "ArgSeperatorToken")
                        {
                            Console.WriteLine("Переменная " + tokens[i].Content);
                        }
                        else
                        {
                            Console.WriteLine("Переменная " + tokens[i].Content);
                            if (tokens[i + 1].Content == ":" && tokens[i+2].Content == "Integer")
                            {
                                Console.WriteLine("Тип данных " + tokens[i + 2].Content);
                                if (tokens[i + 3].GetType().Name == "StatementSeperatorToken")
                                {
                                    Console.WriteLine("Конец блока Var");
                                    buff = i + 4;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Ожидалось перечисление переменных или тип данных");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Синтаксическая ошибка, укажите тип данных!");
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (tokens[i].GetType().Name == "NumberLiteralToken")
                        {

                            Console.WriteLine("Название переменной должно быть идентификатором, например v2");
                        }
                        else
                        {
                            if ((tokens[i].Content == "="))
                            {
                                Console.WriteLine("Cинтаксическая ошибка");
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ожидалось ключевое слово Var");
                    break;
                }
            }
            // Console.WriteLine(tokens.Count());
        }
        public void NumberLine(Token token)
        {
            var Lines = File.ReadAllLines("C:/Users/shelk/source/repos/compiler_/InputFile.txt");
            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].Contains(token.Content))
                {
                    i++;
                    Console.Write("Ошибка в строке номер" + " " + i);
                }
            }
        }
        Stack<string> brackets = new Stack<string>();
        public void R3_BeginEnd(Token token)
        {
            if (token.Content == "End")
            {
                Console.WriteLine("Конец блока Begin");
            }
            if (token.Content == "Begin")
            {
                Console.WriteLine("Начало блока Begin");
            }
            if ((token is OperatorToken && token.Content == "=") || (token is OperatorToken && token.Content == "=-"))
            {
                Console.WriteLine("Присваивание переменной");
            }
        }

        public void R4_CheckBrackets()
        {         
            for (int i = 0; i < tokens.Count; i++)
            {
                R3_BeginEnd(tokens[i]);
                if (tokens[i] is OpenBraceToken)
                {
                    Console.WriteLine("Скобка открыта");
                    brackets.Push(tokens[i].Content);

                }
                else
                    if (tokens[i] is CloseBraceToken)
                {
                    if (brackets.Count > 0)
                    {
                        Console.WriteLine("Скобка успешно закрыта");
                        brackets.Pop();
                    }
                    else
                    {
                        Console.WriteLine("Ошибка со структурой скобок, недопустимый символ " + tokens[i].Content);
                        // NumberLine(tokens[i]);
                        break;
                    }
                }
            }
            if (brackets.Count > 0)
            {
                Console.WriteLine("Произошла ошибка со скобками, недопустимый символ " + brackets.Pop());
                Console.WriteLine("Ожидалось закрытие скобки");
            }

        } 
    } 
}
    