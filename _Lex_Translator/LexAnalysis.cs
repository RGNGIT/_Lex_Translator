using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Lex_Translator
{
    public class Error : Exception
    {
        string text;

        public Error(string text)
        {
            this.text = text;
        }

        public string Text
        {
            get { return text; }
        }
    }

    public class LexAnalysis // лексический анализ
    {

        public enum TypeLex //типы лексем
        {
            Operator = 0,
            Separator = 1,
            Constant = 2,
            Ident = 3,
            Nothing,
            Err
        };

        public static string[] separators = new string[]
        {
"<>", "=", "<", "<=", ">", ">=", "+", "-","or", "/", "not", "\n", "*", ":", "ass", "and", "(", ")", ",", "{", "}"
        };

        public static string[] operators = new string[]
        {
"dim", "end", "%", "!", "$", "read", "write", "for", "to", "do", "while", "if", "then", "else" , "true", "false"
        };

        string prog;
        string value;
        TypeLex typeLex;
        int index;
        char ch;
        int pos;

        List<string> identif;
        public List<string> constants;

        public LexAnalysis(string program)
        {
            this.prog = program;
            identif = new List<string>();
            constants = new List<string>();
            Comment();
        }

        bool Comment() // проверка комментария
        {
            if (pos < prog.Length) // если меньше длины программы
            {
                ch = prog[pos]; // считываем символ
                if (ch == '{') // если начало комментария
                {
                    while (pos < prog.Length && prog[pos] != '}') pos++; // ищем конец комментария
                    pos++;
                    if (pos < prog.Length)
                        ch = prog[pos];
                    else
                    {
                        ch = (char)0;
                        return false; //если не закрыт то false
                    }

                }
                pos++;
                return true; // если закрыт true
            }
            else
            {
                ch = (char)0;
                return false;
            }
        }
        public TypeLex Next() // определение типа лексем
        {
            TypeLex ret = TypeLex.Nothing;
            value = "";
            typeLex = TypeLex.Nothing;
            while (ch != 0) // пока не 0
            {
                if (ch == ' ')
                    Comment();
                else if (char.IsDigit(ch)) // проверка на цифру
                {
                    value = string.Empty;
                    while (char.IsDigit(ch) || ch == '.') // проверка вещественного
                    {
                        value += ch;
                        Comment();
                    }
                    index = constants.IndexOf(value); // ищем вхождения
                    if (index < 0) // если нет, то добавляем в массив констант
                    {
                        index = constants.Count;
                        constants.Add(value);
                    }
                    ret = TypeLex.Constant;
                    break;
                }
                else if (char.IsLetterOrDigit(ch)) // проверка типа числа
                {
                    value = string.Empty;
                    while (char.IsLetterOrDigit(ch))
                    {
                        value += ch;
                        Comment();
                    }
                    index = IsSepar(value); // проверка на разделитель
                    if (index >= 0)
                        ret = TypeLex.Separator;
                    else
                    {
                        index = IsOper(value);
                        if (index >= 0)
                        {
                            ret = TypeLex.Operator; // проверка на оператор
                        }
                        else
                        {

                            index = identif.IndexOf(value);
                            if (index < 0)
                            {
                                index = identif.Count;
                                identif.Add(value);
                            }
                            ret = TypeLex.Ident;
                        }
                    }
                    break;
                }
                else
                {
                    value = String.Empty;
                    value = value + ch;
                    index = IsSepar(value);
                    if (index >= 0)
                        ret = TypeLex.Separator;
                    else
                    {
                        index = IsOper(value);
                        if (index >= 0)
                        {
                            ret = TypeLex.Operator;
                        }
                        else
                        {
                            ret = TypeLex.Err;
                            value = "неизвестный символ '" + ch + "'";
                            throw new Error(value);
                        }
                    }
                    Comment();
                    break;
                }
            }
            typeLex = ret;
            Const = constants;
            return ret;
        }

        public static List<string> Const;

        int IsSepar(string v)
        {

            for (int i = 0; i < separators.Length; i++)
                if (separators[i] == v)
                    return i;
            return -1;
        }

        int IsOper(string v)
        {
            for (int i = 0; i < operators.Length; i++)
                if (operators[i] == value)
                    return i;
            return -1;
        }

        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public int Index
        {
            get { return index; }
        }

        public List<string> Identif
        {
            get { return identif; }
        }
        public List<string> Numbers
        {
            get { return constants; }
        }

        public TypeLex Type
        {
            get { return typeLex; }
        }
    }
}
