using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Lex_Translator
{
    public partial class Lex : Form
    {
        public Lex()
        {
            InitializeComponent();
        }

        string[] Code;

        private void buttonLexAnalisys_Click(object sender, EventArgs e)
        {
            string Code = string.Empty;
            foreach (string s in this.Code)
            {
                Code += s;
            }
            Parsing parsing = new Parsing(new LexAnalysis(Code));
            parsing.ParseProgram();
            foreach(var i in LexAnalysis.separators)
            {
                dataGridViewDiv.Rows.Add(i); 
            }
            foreach (var i in LexAnalysis.operators)
            {
                dataGridViewOpers.Rows.Add(i);
            }
            foreach (var i in parsing.dimvars)
            {
                dataGridViewIdenList.Rows.Add(i);
            }
            foreach (var i in LexAnalysis.Const)
            {
                dataGridViewConst.Rows.Add(i);
            }
            listBoxErrors.Items.Add("Если в ходе проги ничего не вылезло, значит все прошло ок");
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            string FileName = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Text|*.txt",
                Title = "Открыть файл с кодом"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog.FileName;
            }
            Code = File.ReadAllLines(FileName);
            foreach(string s in Code)
            {
                listBoxCode.Items.Add(s);
            }
        }
    }
    public class Parsing
    {
        LexAnalysis lexer;
        public string textError;
        public List<string> dimvars;

        public Parsing(LexAnalysis lexer)
        {
            this.lexer = lexer;
            textError = string.Empty;
            dimvars = new List<string>();
        }
        
        LexAnalysis.TypeLex Next(bool IgnEndStr = false) // получаем тип следующего символа
        {
            while (true)
            {
                LexAnalysis.TypeLex type = lexer.Next();
                if (!IgnEndStr || lexer.Value != "\n")
                    return type;
            }
        }


        public Node ParseProgram() // разбор программы
        {
            LexAnalysis.TypeLex lexem = Next(true);
            {
                Block block = new Block();
                if (lexem == LexAnalysis.TypeLex.Operator && lexer.Value == "dim") // если dim или оператор
                {
                    bool flag = false;
                    while (true)
                    {
                        Next(true);
                        if (lexer.Value == "dim")
                        {
                            flag = false;
                            continue;
                        }
                        if (lexer.Type == LexAnalysis.TypeLex.Ident && !flag) // если идентификтор
                        {
                            block.Append(ParseTypeVar()); // определяем тип идентификаторп
                        }
                        else
                        {
                            block.Append(ParseInstruct());
                            return new Prg(block, string.Empty);
                        }
                        flag = true;
                    }
                }
                else
                    throw new Error("Отсутствует dim или оператор");
            }
        }

        public Node ParseInstructs() // разбор операторов
        {
            Block block = new Block();
            while (true)
            {
                if (lexer.Type == LexAnalysis.TypeLex.Ident)
                    block.Append(ParseVarEqually());
                else if (lexer.Value == "for")
                    block.Append(ParseFor());
                else if (lexer.Value == "while")
                    block.Append(ParseWhile());
                else if (lexer.Value == "if")
                    block.Append(ParseIf());
                else if (lexer.Value == "read")
                    block.Append(ParseRead());
                else if (lexer.Value == "write")
                    block.Append(ParseWrite());
                else if (lexer.Value == "end")
                {
                    return block;
                }
                else if (lexer.Value == ":")
                {
                    Next();
                }
                else if (lexer.Value == "\n")
                {
                    Next(true);
                    return block;
                }
                else if (lexer.Type == LexAnalysis.TypeLex.Operator)
                    return block;
                else
                    break;
            }
            throw new Error("Нет конца программы");
        }

        public Node ParseInstruct() // разбор end
        {
            Block block = new Block();
            while (true)
            {
                Node node = ParseInstructs();
                block.Append(node);
                if (lexer.Value == "end")
                {
                    Next(true);
                    break;
                }
            }
            return block;
        }

        public Node ParseBlock() // разбор блоков операторов
        {

            return ParseInstructs();
        }

        public Node ParseVarEqually() // проверка объявлена ли переменная раннее
        {
            string name = lexer.Value;
            if (dimvars.IndexOf(name) < 0)
                throw new Error("Переменная " + name + " не объявлена");
            LexAnalysis.TypeLex lexem = Next();
            if (lexer.Value == "ass")
            {
                Next();
                Node expr = ParseExpr();
                return new Var(name, expr);
            }
            else
                throw new Error("Ожидался ass, встретился " + lexer.Value);
        }

        public Node ParseTypeVar() // разбор переменной по типам
        {
            List<string> vars = new List<string>();
            if (dimvars.IndexOf(lexer.Value) > 0) throw new Error("Переменная " + lexer.Value + " уже объявлена ");
            vars.Add(lexer.Value);
            LexAnalysis.TypeLex lexem = Next(true);
            while (lexer.Value == ",")
            {

                lexem = Next(true);
                if (lexem == LexAnalysis.TypeLex.Ident)
                {
                    if (dimvars.IndexOf(lexer.Value) > 0)
                        throw new Error("Переменная " + lexer.Value + " уже объявлена ");
                    vars.Add(lexer.Value);

                }
                else
                    throw new Error("Ожидался идентификатор, встретился " + lexer.Value);
                lexem = Next();
            }
            if (lexem == LexAnalysis.TypeLex.Operator && (lexer.Value == "%" || lexer.Value == "!" || lexer.Value == "$"))
            {
                string typeName = lexer.Value;
                Next(true);
                dimvars.AddRange(vars);
                return new TypeVar(typeName, vars);
            }
            else if (lexer.Value == "ass") return ParseVarEqually();
            else
                throw new Error("Тип переменной " +
                lexer.Value + "неизвестен");
        }

        public Node ParseFor() // разбор оператора for
        {
            Next();
            Node from = ParseVarEqually();
            if (lexer.Value == "to")
            {
                Next(true);
                Node to = ParseExpr();
                if (lexer.Value == "do")
                {
                    Next(true);
                    Node block = ParseBlock();
                    return new For(from, to, block);
                }
                else
                    throw new Error("Отсутствует do в цикле for ");
            }
            else
                throw new Error("Отсутствует to в цикле for ");
        }

        public Node ParseWhile() // разбор оператора while
        {
            Next();
            Node expr = ParseExpr();
            if (lexer.Value == "do")
            {
                Next(true);
                Node block = ParseBlock();
                return new OpWhile(expr, block);
            }
            else
                throw new Error("Отсутствует do в цикле while ");
        }

        public Node ParseIf() // разбор оператора if
        {
            Next();
            Node expr = ParseExpr();
            if (lexer.Value == "then")
            {
                Next(true);
                Node blockThen = ParseBlock();
                Node blockElse = null;
                if (lexer.Value == "else")
                {
                    Next(true);
                    blockElse = ParseBlock();
                }
                return new OpIf(expr, blockThen, blockElse);
            }
            else
                throw new Error("Отсутствует then в цикле if ");
        }

        public Node ParseRead() // разбор оператора read
        {
            Next();
            List<string> vars = new List<string>();
            if (lexer.Value == "(")
            {
                while (Next() == LexAnalysis.TypeLex.Ident)
                {
                    vars.Add(lexer.Value);
                    if (Next() == LexAnalysis.TypeLex.Separator)
                    {
                        if (lexer.Value == ")") break;
                        if (lexer.Value != ",")
                            throw new Error("Отсутствует ',' в операторе read");
                    }
                }
                Next();
                return new OpRead(vars);
            }
            else
                throw new Error("Отсутствует ',' в операторе read");
        }

        public Node ParseWrite() // разбор оператора write
        {
            Next();
            List<Node> vars = new List<Node>();
            if (lexer.Value == "(")
            {
                while (true)
                {
                    Next();
                    vars.Add(ParseExpr());
                    if (lexer.Type == LexAnalysis.TypeLex.Separator)
                    {
                        if (lexer.Value == ")")
                        {
                            break;
                        }
                        if (lexer.Value == ",")
                        {
                        }
                        else
                            throw new Error("Отсутствует ')' в операторе write");
                    }
                }
                Next();
                return new OpWrite(vars);
            }
            else
                throw new Error("Отсутствует '(' в операторе write");
        }

        int OpOrder(string op) // опеределение порядка
        {
            switch (op)
            {
                case "<>":
                case "=":
                case "<":
                case "<=":
                case ">":
                case ">=":
                    return 0;
                case "+":
                case "-":
                case "or":
                    return 1;
                case "*":
                case "/":
                case "and":
                    return 2;
            }
            throw new Error("Неизвестная операция " + op);
        }


        public Node ParseExpr() // разбор операций с переменными
        {
            Expr expr = new Expr();
            Stack<int> opOrder = new Stack<int>();
            Stack<string> opName = new Stack<string>();
            while (true)
            {
                if (lexer.Type == LexAnalysis.TypeLex.Constant)
                {
                    string type = "!";
                    if (lexer.Value.IndexOf('.') >= 0)
                        type = "%";
                    expr.Append(1, lexer.Value, double.Parse(lexer.Value, CultureInfo.InvariantCulture.NumberFormat), type);
                }
                else if (lexer.Type == LexAnalysis.TypeLex.Ident)
                {
                    int i = dimvars.IndexOf(lexer.Value);
                    if (i < 0)
                        throw new Error("Переменная " + lexer.Value + " не объявлена");
                    expr.Append(2, lexer.Value, 0, string.Empty);
                }
                else if (lexer.Value == "not")
                {
                    string op = lexer.Value;
                    Next();
                    if (lexer.Type == LexAnalysis.TypeLex.Constant)
                        expr.Append(1, lexer.Value, double.Parse(lexer.Value), "%");
                    else if (lexer.Type == LexAnalysis.TypeLex.Ident)
                    {
                        if (dimvars.IndexOf(lexer.Value) < 0)
                            throw new Error("Переменная " + lexer.Value + " не объявлена");
                        expr.Append(2, lexer.Value, 0, string.Empty);
                    }
                    else
                        throw new Error("Ожидалось число или идентификатор, вместо " + lexer.Value);
                    expr.Append(3, op, 0, string.Empty);
                }
                else if (lexer.Value == "(")
                {
                    opOrder.Push(-1);
                    opName.Push(lexer.Value);
                    Next();
                    continue;
                }
                else
                    throw new Error("Ожидалось число или идентификатор, вместо " + lexer.Value);
                Next();
                if (lexer.Type == LexAnalysis.TypeLex.Separator)
                {
                    if (lexer.Value == ":" || lexer.Value == "\n" || lexer.Value == ",")
                    {
                        break;
                    }
                    else if (lexer.Value == ")")
                    {
                        bool LP = false;
                        while (opOrder.Count > 0)
                        {
                            int o = opOrder.Pop();
                            string name = opName.Pop();
                            if (o == -1)
                            {
                                LP = true;
                                break;
                            }
                            expr.Append(0, name, 0, string.Empty);
                        }
                        if (!LP) break;
                        Next();
                    }
                    if (lexer.Type == LexAnalysis.TypeLex.Separator)
                    {
                        int o = OpOrder(lexer.Value);
                        if (opOrder.Count > 0 && opOrder.Peek() >= o)
                        {
                            opOrder.Pop();
                            expr.Append(0, opName.Pop(), 0, string.Empty);
                        }
                        opOrder.Push(o);
                        opName.Push(lexer.Value);
                    }
                    else
                    if (lexer.Type == LexAnalysis.TypeLex.Operator)
                        break;
                    else
                        throw new Error("Ожидалась операция , вместо " + lexer.Value);
                }
                else
                if (lexer.Type == LexAnalysis.TypeLex.Operator)
                    break;
                else
                    throw new Error("Ожидалась операция или разделитель, вместо " + lexer.Value);
                Next();
            }
            while (opName.Count > 0)
                expr.Append(0, opName.Pop(), 0, string.Empty);
            return expr;
        }
    }


    abstract public class Node
    {
    }

    public class Prg : Node
    {
        Node block;
        string name;

        public Prg(Node block, string name)
        {
            this.block = block;
            this.name = name;
        }
    }

    public class Block : Node
    {
        List<Node> nodes;

        public Block()
        {
            nodes = new List<Node>();
        }


        public void Append(Node node)
        {
            nodes.Add(node);
        }
    }

    public class TypeVar : Node
    {
        List<string> vars;
        string type;

        // Таблица идентификаторов
        public TypeVar(string type, List<string> vars)
        {
            this.type = type;
            this.vars = vars;
        }

    }

    public class Var : Node
    {
        string name;
        Node expr;

        public Var(string name, Node expr)
        {
            this.name = name;
            this.expr = expr;
        }


    }

    public class For : Node
    {
        Node from;
        Node to;
        Node block;
        public For(Node from, Node to, Node block)
        {
            this.from = from;
            this.to = to;
            this.block = block;
        }

    }

    public class OpWhile : Node
    {
        Node expr;
        Node block;

        public OpWhile(Node expr, Node block)
        {
            this.expr = expr;
            this.block = block;
        }
    }

    public class OpIf : Node
    {
        Node expr;
        Node blockThen;
        Node blockElse;

        public OpIf(Node expr, Node blockThen, Node blockElse)
        {
            this.expr = expr;
            this.blockThen = blockThen;
            this.blockElse = blockElse;
        }


    }
    public class OpRead : Node
    {
        List<string> vars;

        public OpRead(List<string> vars)
        {
            this.vars = vars;
        }
    }

    public class OpWrite : Node
    {
        List<Node> nodes;
        public OpWrite(List<Node> vars)
        {
            this.nodes = vars;
        }
    }

    public class Expr : Node
    {
        class Item
        {
            public int type;
            public string name;
            public double num;
            public string typeVar;
        }
        List<Item> items;
        public Expr()
        {
            items = new List<Item>();
        }
        public void Append(int type, string name, double num, string typeVar)
        {
            Item item = new Item();
            item.type = type;
            item.name = name;
            item.num = num;
            item.typeVar = typeVar;
            items.Add(item);
        }
    }
}
