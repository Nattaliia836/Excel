using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory1
{
    public class ExpressionCell : DataGridViewTextBoxCell
    {
        public string Expression { get; set; }
        private HashSet<ExpressionCell> edges = new HashSet<ExpressionCell>();
        public HashSet<ExpressionCell> Edges { get { return edges; } set { edges = value; } }

        public void CleanEdges() 
        {
            edges = new HashSet<ExpressionCell>();
        }
        public override object Clone()
        {
            var returnedObject = (ExpressionCell)base.Clone();
            returnedObject.Expression = Expression;
            return returnedObject;
        }

    }
}
