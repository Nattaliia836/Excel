using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory1
{
    class CheckRecursion
    {
        public static void Check(ExpressionCell currentCell, HashSet<ExpressionCell> previousCells)
        {
            //previousCells - де ми були, currentCell.Edges - куди ми можемо піти
            HashSet<ExpressionCell> copy = new HashSet<ExpressionCell>(currentCell.Edges);
            copy.IntersectWith(previousCells);
            if (copy.Count != 0)
            {
                throw new Exception("Увага! Рекурсія!! Переробити!");
            } else 
            {
                previousCells.Add(currentCell);
                foreach (ExpressionCell cell in currentCell.Edges)
                {
                    Check(cell, previousCells);
                }
            }
        } 
    }
}
