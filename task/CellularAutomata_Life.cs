using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    class CellularAutomata_Life : CellularAutomata
    {
        public CellularAutomata_Life(int n) : base(n)
        {

        }

        public enum cellType :int
        {
            empty = 0,
            live = 1
        }

        public void Generation(int n)
        {
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    switch (rnd.Next(2)) {
                        case 0: field[i, j] = (int)cellType.empty;
                                             break;
                        case 1: field[i, j] = (int)cellType.live;
                                            break;
                        default: break;
                    }
                }
            }
        }

        public override int Analyze(int x, int y, int n)
        {
            {
                if ((x == 0) && (y == 0))
                {
                    return field[x + 1, y] + field[x + 1, y + 1] + field[x, y + 1];
                }
                else
                {
                    if ((x == 0) && (y == n - 1))
                    {
                        return field[x + 1, y] + field[x + 1, y - 1] + field[x, y - 1];
                    }
                    else
                    {
                        if ((x == n - 1) && (y == n - 1))
                        {
                            return field[x - 1, y] + field[x - 1, y - 1] + field[x, y - 1];
                        }
                        else
                        {
                            if ((x == n - 1) && (y == 0))
                            {
                                return field[x - 1, y] + field[x - 1, y + 1] + field[x, y + 1];
                            }
                            else
                            {
                                if (y == 0)
                                {
                                    return field[x - 1, y] + field[x + 1, y] + field[x - 1, y + 1] + field[x, y + 1] + field[x + 1, y + 1];
                                }
                                else
                                {
                                    if (x == 0)
                                    {
                                        return field[x, y - 1] + field[x, y + 1] + field[x + 1, y] + field[x + 1, y + 1] + field[x + 1, y - 1];
                                    }
                                    else
                                    {
                                        if (x == n - 1)
                                        {
                                            return field[x, y - 1] + field[x, y + 1] + field[x - 1, y] + field[x - 1, y + 1] + field[x - 1, y - 1];
                                        }
                                        else
                                        {
                                            if (y == n - 1)
                                            {
                                                return field[x - 1, y] + field[x + 1, y] + field[x - 1, y - 1] + field[x, y - 1] + field[x + 1, y - 1];
                                            }
                                            else
                                            {
                                                return field[x - 1, y - 1] + field[x - 1, y] + field[x, y - 1] + field[x - 1, y + 1] + field[x + 1, y - 1] + field[x + 1, y + 1] + field[x, y + 1] + field[x + 1, y];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }
        public override void TransitionRule(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Analyze(i, j, n) == 3)
                    {
                        field[i, j] = (int)cellType.live;
                    }
                    else
                    {
                        field[i, j] = (int)cellType.empty;
                    }
                }
            }
        }

    }
}
