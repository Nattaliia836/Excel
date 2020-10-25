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

        public override object Clone()
        {
            var returnedObject = (ExpressionCell)base.Clone();
            returnedObject.Expression = Expression;
            return returnedObject;
        }
    }
}
