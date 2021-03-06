using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    class CellularAutomata
    {
        public int[,] field;
        public CellularAutomata(int n)
        {
            field = new int[n, n];
        }

        public virtual int Analyze(int x, int y,int n)
        {
            return 0;
        }
        public virtual void TransitionRule(int n)
        {
           
        }

    }
}
