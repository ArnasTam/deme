using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L1
{
    public class Container
    {
        private char[,] Array = new char[20,70];
        private int N { get; set; }
        private int M { get; set; }

        public Container(int n, int m)
        {
            this.N = n;
            this.M = m;

            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    this.Array[i, j] = '.';
                }
            }
        }

        public char Get_Point(int x, int y)
        {
            return this.Array[x, y];
        }

        public void Set(int x, int y, char sign)
        {
            this.Array[x, y] = sign;
        }

        public int RowCount()
        {
            return this.N;
        }

        public int ColumnCount()
        {
            return this.M;
        }
    }
}