using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
namespace Laboratory1
{
    class Laboratory1Visitor : CalculatorBNFBaseVisitor<double>
    {
        private DataGridView DGV;
        public ExpressionCell NameCurentCell { get; set; }
        public Laboratory1Visitor(DataGridView DGV, ExpressionCell NameCurentCell)
        {
            this.NameCurentCell = NameCurentCell;
            this.DGV = DGV;
        }

        public override double VisitModDivExpr([NotNull] CalculatorBNFParser.ModDivExprContext context)
        {
            try
            {
                var left = WalkLeft(context);
                var right = WalkRight(context);
                if (right == 0)
                {
                    throw new Exception("Ділення на 0!");
                }
                else
                {
                    if (context.operatorToken.Type == CalculatorBNFLexer.MOD)
                    {
                        Debug.WriteLine("{0} mod {1}", left, right);
                        return left % right;
                    }
                    else
                    {
                        Debug.WriteLine("{0} div {1}", left, right);
                        return (left - (left % right)) / right;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return double.PositiveInfinity;
        }

        public override double VisitBoolExpr([NotNull] CalculatorBNFParser.BoolExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == CalculatorBNFLexer.EQUALS)
            {
                Debug.WriteLine("{0} == {1}", left, right);
                return Convert.ToDouble(left == right);
            }
            else if(context.operatorToken.Type == CalculatorBNFLexer.MOREOP)
            {
                Debug.WriteLine("{0} > {1}", left, right);
                return Convert.ToDouble(left > right);
            }
            else
            {
                Debug.WriteLine("{0} < {1}", left, right);
                return Convert.ToDouble(left < right);
            }
        }

        public override double VisitNotExpr([NotNull] CalculatorBNFParser.NotExprContext context)
        {
            var left = WalkLeft(context);
            if (left == 0.0)
            {
                return 1.0;
            }
            else
            {
                return 0.0;
            }
        }

        public override double VisitUnaryExpr([NotNull] CalculatorBNFParser.UnaryExprContext context)
        {
            var left = WalkLeft(context);

            if (context.operatorToken.Type == CalculatorBNFLexer.ADD)
            {
                Debug.WriteLine("+ {0}", left);
                return left;
            }
            else 
            {
                Debug.WriteLine("- {0}", left);
                return -left;
            }
        }

        public override double VisitCompileUnit(CalculatorBNFParser.CompileUnitContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitNumberExpr(CalculatorBNFParser.NumberExprContext context)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
            var result = double.Parse(context.GetText());
            Debug.WriteLine(result);

            return result;
        }

        //IdentifierExpr
        public override double VisitIdentifierExpr(CalculatorBNFParser.IdentifierExprContext context)
        {
            try
            {
                var result = context.GetText();
                Tuple<int, int> indexCell = NameGenerator.ConvertFromBase26(result);
                Calculator calculator = new Calculator(DGV);
                ((ExpressionCell)DGV.Rows[indexCell.Item1].Cells[indexCell.Item2]).Edges.Add(NameCurentCell);
                calculator.NameCurentCell = (ExpressionCell)DGV.Rows[indexCell.Item1].Cells[indexCell.Item2];
                CheckRecursion.Check(calculator.NameCurentCell, new HashSet<ExpressionCell>());
                return calculator.Evaluate(((ExpressionCell)DGV.Rows[indexCell.Item1].Cells[indexCell.Item2]).Expression);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0.0;
            }
        }

        public override double VisitParenthesizedExpr(CalculatorBNFParser.ParenthesizedExprContext context)
        {
            return Visit(context.expression());
        }

       
        public override double VisitAdditiveExpr(CalculatorBNFParser.AdditiveExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == CalculatorBNFLexer.ADD)
            {
                Debug.WriteLine("{0} + {1}", left, right);
                return left + right;
            }
            else //LabCalculatorLexer.SUBTRACT
            {
                Debug.WriteLine("{0} - {1}", left, right);
                return left - right;
            }
        }

        public override double VisitMultiplicativeExpr(CalculatorBNFParser.MultiplicativeExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == CalculatorBNFLexer.MULTIPLY)
            {
                Debug.WriteLine("{0} * {1}", left, right);
                return left * right;
            }
            else 
            {
                try
                {
                    if (right == 0)
                    {
                        throw new Exception("Ділення на 0!");
                    }
                    Debug.WriteLine("{0} / {1}", left, right);
                    return left / right;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return double.PositiveInfinity;
            }
        }

        private double WalkLeft(CalculatorBNFParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<CalculatorBNFParser.ExpressionContext>(0));
        }

        private double WalkRight(CalculatorBNFParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<CalculatorBNFParser.ExpressionContext>(1));
        }
    }
}
