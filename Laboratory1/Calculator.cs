using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory1
{
    public class Calculator
    {
        private DataGridView DGV;
        public Calculator(DataGridView DGV) 
        {
            this.DGV = DGV;
        }

        public ExpressionCell NameCurentCell { get; set; }
        public double Evaluate(string expression)
        {
            var lexer = new CalculatorBNFLexer(new AntlrInputStream(expression));
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new ThrowExceptionErrorListener());

            var tokens = new CommonTokenStream(lexer);
            var parser = new CalculatorBNFParser(tokens);

            var tree = parser.compileUnit();

            var visitor = new Laboratory1Visitor(DGV, NameCurentCell);

            return visitor.Visit(tree);
        }
    }
}
